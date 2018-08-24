using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP214_PetShopGUI
{
    public partial class Menu_IssuePresc : System.Web.UI.Page
    {
        // pet information (ID)
        DataTable ids { get; set; }

        //medication information (ID, NAME)
        DataTable mitems { get; set; }
       

        // Prescription Issue (1) : Prescription ID (SQ), Pet ID (DROPBOX LIST), ORDER DATE (SYSDATE)
        string PrescID { get; set; }
        string PetID { get; set; }
        string PrescOrderDate { get; set; }
      
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              // Display dropdownlist with Pet ID 
              PetID Ids = new PetID(ids);

              MedList Meds = new MedList(mitems);
             
                try
                {
                    ConnectionClass.PetIDList(Ids);
                    PetIDList.DataSource = Ids.PetIDs;
                    PetIDList.DataTextField = Ids.PetIDs.Columns["ID"].ToString();
                    PetIDList.DataValueField = Ids.PetIDs.Columns["ID"].ToString();
                    PetIDList.DataBind();

                    ConnectionClass.MedicationList(Meds);
                    MedList.DataSource = Meds.MedItems;
                    MedList.DataTextField = Meds.MedItems.Columns["NAME"].ToString();
                    MedList.DataValueField = Meds.MedItems.Columns["ID"].ToString();
                    MedList.DataBind();
                }

                finally
                {

                }

            }

        }

        protected void MedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // status2.Text = MedList.SelectedValue.ToString();
        }


        protected void StartIssue_Click(object sender, EventArgs e)
        {
            PetID = PetIDList.SelectedItem.ToString();

            PrescList newPresc = new PrescList(PrescID, PetID, PrescOrderDate);

            try
            {
                ConnectionClass.PrescriptionList(newPresc);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Success! ');</script>");
                status1.Text = PetID + " and " + newPresc.PrescID;
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('failed');</script>");
            }

            finally
            {

            }
            
        }

        string MedName;
        string MedQty;

        string MedItems;
        string MedItemQtys;
        
        protected void AddMed_Click(object sender, EventArgs e)
        {
          
            if (meditemslist.Text == "Please add new med item" && meditemsqty.Text == " and quantity")
            {
                meditemslist.Text = "";
                meditemsqty.Text = "";
                fillPresc();
            }
            else
            {
                fillPresc();
            } 
        } 
        
        public void fillPresc()
        {
            MedName = MedList.SelectedItem.ToString();
            MedQty = InputQty.Text;

            MedItems = "  " + MedName + "<br>";
            MedItemQtys = "  " + MedQty + "<br>";

            meditemslist.Text += MedItems;
            meditemsqty.Text += MedItemQtys;
        } 

        
        protected void DelMed_Click(object sender, EventArgs e)
        {
            try
            {
                meditemslist.Text = meditemslist.Text.Remove(meditemslist.Text.LastIndexOf("  "));
                meditemsqty.Text = meditemsqty.Text.Remove(meditemsqty.Text.LastIndexOf("  "));

            }

            catch
            {
                meditemslist.Text = "Please add new med item";
                meditemsqty.Text = " and quantity";
            } 
           
        } 
    }
}