using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP214_PetShopGUI
{
    public partial class Menu_RegisterMedItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string ManuID { get; set; }
        
        string ManuRF { get; set; }
        string MedName { get; set; }
        string MedPrice { get; set; }
        protected void RegisterNewMed_Click(object sender, EventArgs e)
        {
            ManuID = NewManuID.Text;
            ManuRF = NewManuRF.Text;
            MedName = NewMedName.Text;
            MedPrice = NewMedPrice.Text;


            Medication NewMedItem = new Medication(ManuID, ManuRF, MedName, MedPrice);
            try
            {
                ConnectionClass.RegisterNewMed(NewMedItem);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Registered successfully!');</script>");
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Failed');</script>");

            }
        }
    }
}