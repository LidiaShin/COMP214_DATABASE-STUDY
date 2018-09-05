using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP214_PetShopGUI
{
    public partial class testTblPET : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string customerName { get; set; }
        string ownerID { get; set; }
        string petName { get; set; }
        string petBirthday { get; set; }

        DataTable petList { get; set; }


        protected void check_Click(object sender, EventArgs e)
        {
            customerName = cusName.Text;
            InquiryPet pets = new InquiryPet(customerName, ownerID, petName, petBirthday,petList);
           
            try
            {
                ConnectionClass.PetLists(pets);
                petlisttable.DataSource = pets.petList;
                petlisttable.DataBind();
            }

            finally
            {


            }





        }
    }
}