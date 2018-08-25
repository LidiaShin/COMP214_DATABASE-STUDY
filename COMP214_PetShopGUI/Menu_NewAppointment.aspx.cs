using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP214_PetShopGUI
{
    public partial class Menu_NewAppointment : System.Web.UI.Page
    {
        // vet information IDs
        DataTable vids { get; set; }

        // customer (owner) information IDs (DataTable)
        DataTable oids { get; set; }

        // customer (owner) ID (string)
        // 재활용 for email
        string Oid { get; set; }


        // New Appointment Info Details
        string VetID { get; set; }
        string PetID { get; set; }
        string VetApptTime { get; set; }
        string VetApptNote { get; set; }
        string VetApptPrice { get; set; }

        DataTable pids { get; set; } // 쓸수 있을까??
        DataTable pnames { get; set; } // 쓸수 있을까??

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                VetID Vids = new VetID(vids);
                OwnerID Oids = new OwnerID(oids);

                try
                {
                    // Display dropdownlist with Vet ID 
                    ConnectionClass.VetIDList(Vids);
                    vetIDList.DataSource = Vids.VetIDs;
                    vetIDList.DataTextField = Vids.VetIDs.Columns["ID"].ToString();
                    vetIDList.DataValueField = Vids.VetIDs.Columns["ID"].ToString();
                    vetIDList.DataBind();

      
                    // Display dropdownlist with Customer(Pet Owner) ID 
                    ConnectionClass.OnwerIDList(Oids);
                    cusIDList.DataSource = Oids.OwnerIDs;
                    cusIDList.DataTextField = Oids.OwnerIDs.Columns["NAME"].ToString();
                    cusIDList.DataValueField = Oids.OwnerIDs.Columns["ID"].ToString();
                    cusIDList.DataBind();
                }

                finally
                {

                }
                // Display Calendar with month, year and date
                for (int i = 1; i <= 12; i++)
                {
                    System.Globalization.DateTimeFormatInfo monthnum = new System.Globalization.DateTimeFormatInfo();
                    month.Items.Add(new ListItem(monthnum.GetAbbreviatedMonthName(i).ToString(), i.ToString()));
                }

                for (int i = 2015; i <= System.DateTime.Now.Year +1; i++)
                {
                    year.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }

        // getting petID by selecting customerID
        protected void selectcustomer(object sender, EventArgs e)
        {

            petIDList.Items.Clear();

            Oid = cusIDList.SelectedValue.ToString();

            //check.Text = Oid;

            CustomerPets CPets = new CustomerPets(Oid, pids, pnames);

            try
            {
                ConnectionClass.GetPetIDList(CPets);
                petIDList.DataSource = CPets.PetIDs;
                petIDList.DataTextField = CPets.PetIDs.Columns["NAME"].ToString();
                petIDList.DataValueField = CPets.PetIDs.Columns["ID"].ToString();

                // IDs 지만 ID랑 NAME 둘다 있음 (첫번째 칼럼 : ID, 두번째칼럼: NAME)
                // 첫번째 칼럼 (ID) 는 DataValueField에, 두번째 칼럼 (NAME) 은 DataTextField에 넣어준다 
                petIDList.DataBind();
            }

            finally
            {



            }
        }

        /*protected void selectmonth(object sender, EventArgs e)
        {
            day.Items.Clear();

            for (int i = 1; i <= System.DateTime.DaysInMonth(int.Parse(year.SelectedValue), int.Parse(month.SelectedValue)); i++)
            {
                day.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }*/

        protected void selectmonth(object sender, EventArgs e)
        {
            day.Items.Clear();

            for (int i = 1; i <= System.DateTime.DaysInMonth(int.Parse(year.SelectedValue), int.Parse(month.SelectedValue)); i++)
            {
              
                day.Items.Add(new ListItem(i.ToString("D2"), i.ToString("D2")));
            }
        }

        protected void selectday(object sender, EventArgs e)
        {
            time.Items.Clear();
            DateTime BookTime = DateTime.ParseExact("09:00", "HH:mm", null);
            DateTime EndTime = DateTime.ParseExact("19:55", "HH:mm", null);
            TimeSpan Interval = new TimeSpan(1, 0, 0);

            while (BookTime <= EndTime)
            {
                //time.Items.Add(BookTime.ToShortTimeString());
                time.Items.Add(BookTime.ToString("HH:mm"));
                BookTime = BookTime.Add(Interval);
            }
        }

        protected void selecttime(object sender, EventArgs e)
        {
            
        }

        string MailMsg;
        string ApptDateTime;
        protected void seeDetail_Click(object sender, EventArgs e)
        {
            ApptDateTime = year.SelectedItem.ToString() + month.SelectedItem.ToString() + day.SelectedItem.ToString() + time.SelectedItem.ToString();

            check.Text = "Appointment for customer " + cusIDList.SelectedItem.ToString() + "<br>" +
                         "PetName" + petIDList.SelectedItem.ToString() + "<br>" +
                         "Appointment Date " + year.SelectedItem.ToString() + month.SelectedItem.ToString() + day.SelectedItem.ToString() + "<br>" +
                         "Appointment Time " + time.SelectedItem.ToString() + "<br>" +
                         "ApptDateTime: " + ApptDateTime;

            MailMsg = check.Text;
        }


        protected void saveAppointment_Click(object sender, EventArgs e)
        {
            VetID = vetIDList.SelectedValue.ToString();
            PetID = petIDList.SelectedValue.ToString();
            VetApptTime = year.SelectedItem.ToString() + month.SelectedItem.ToString() + day.SelectedItem.ToString() + time.SelectedItem.ToString();
            VetApptNote = note.Text;
            VetApptPrice = price.Text;

            VetAppointment newVetAppointment = new VetAppointment(VetID, PetID, VetApptTime, VetApptNote, VetApptPrice);
            try
            {
                ConnectionClass.ConfirmNewAppointment(newVetAppointment);
                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('New Appointment Saved Successfully! ');");
                Response.Write("</script>");

            }

            catch
            {
                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('Failed ');");
                Response.Write("</script>");
            }

            finally
            {
                check1.Text = VetID + PetID + VetApptTime + VetApptNote + VetApptPrice;
            }

        }
    }
}