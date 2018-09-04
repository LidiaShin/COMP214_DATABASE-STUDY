using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP214_PetShopGUI
{
    public partial class Menu_ChangeAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Display Calendar with month, year and date
                for (int i = 1; i <= 12; i++)
                {
                    System.Globalization.DateTimeFormatInfo monthnum = new System.Globalization.DateTimeFormatInfo();
                    month.Items.Add(new ListItem(monthnum.GetAbbreviatedMonthName(i).ToString(), i.ToString()));
                }

                for (int i = 2015; i <= System.DateTime.Now.Year + 1; i++)
                {
                    year.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }

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
        string ApptID { get; set; }
        string PetID { get; set; }

        string PetName { get; set; }
        string CusName { get; set; }
        string ApptDateTime { get; set; }

        DataTable ApptTable { get; set; }

       
        public void ApptListView()
        {
            CusName = cusNameInput.Text;
            ApptList appt = new ApptList(ApptID, PetID, PetName, CusName, ApptDateTime, ApptTable);
            try
            {
                ConnectionClass.GetApptList(appt);
                ApptListTable.DataSource = appt.ApptTable;
                ApptListTable.DataBind();
            }

            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Can't find any appointment for the customer! ');</script>");
            }
            finally
            {

            }
        }
        protected void searchAppt_Click(object sender, EventArgs e)
        {
            ApptListView();
        }

        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (ApptListTable.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            if (hdnText.Value != "")
            {
                string yourValue = hdnText.Value.ToString();
                if (yourValue == "Default")
                {
                    ApptListView();
                }
                else
                {
                    this.ApptListView();
                }
            }
            //else
            //{
            this.ApptListView();
            //}
        }



        protected void CancelAppt(object sender, EventArgs e)
        {

            try
            {
                Button btn = (Button)(sender);

                ApptID = btn.CommandArgument;
                // test CommandArgument 

              
                ApptList appt = new ApptList(ApptID, PetID, PetName, CusName, ApptDateTime, ApptTable);
                ConnectionClass.CancelAppointment(appt);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Cancelled Successfully! ');</script>");
               

            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Failed! ');</script>");
            }
        }

        protected void ChangeAppt(object sender, EventArgs e)
        {

            try
            {
                Button btn = (Button)(sender);
                ApptNo.Text = btn.CommandArgument;
                ApptNo.BackColor = System.Drawing.Color.Ivory;
                ApptNo.ForeColor = System.Drawing.Color.Crimson;
                ApptNo.Font.Bold = true;
               
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Failed! ');</script>");
            }
        }

        protected void ConfirmChange_Click(object sender, EventArgs e)
        {
            ApptID = ApptNo.Text;
            ApptDateTime = year.SelectedItem.ToString() + month.SelectedItem.ToString() + day.SelectedItem.ToString() + time.SelectedItem.ToString();
            ApptList cappt = new ApptList(ApptID, PetID, PetName, CusName, ApptDateTime, ApptTable);

            try
            {
                ConnectionClass.ChangeAppointment(cappt);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Appointment Changed Successfully! ');</script>");
            }

            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Please check required fields again.');</script>");
                
            }
            finally
            {
                check.Text = year.SelectedItem.ToString() + month.SelectedItem.ToString() + day.SelectedItem.ToString() + time.SelectedItem.ToString();
            }


        }
    }
}