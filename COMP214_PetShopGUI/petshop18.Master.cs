using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP214_PetShopGUI
{
    public partial class petshop18 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PrescBtn_Click(object sender, EventArgs e)
        {
            NewPresc.Visible = true;
            RePresc.Visible = true;
            
            Register.Visible = false;
            ViewPet.Visible = false;

            NewAppt.Visible = false;
            ViewAppt.Visible = false;
           
            MedRegis.Visible = false;

        }

        protected void CusBtn_Click(object sender, EventArgs e)
        {
            Register.Visible = true;
            ViewPet.Visible = true;

            NewPresc.Visible = false; 
            RePresc.Visible = false; 
            
            NewAppt.Visible = false;
            ViewAppt.Visible = false;
            
            MedRegis.Visible = false;
        }

        protected void ApptBtn_Click(object sender, EventArgs e)
        {
            NewAppt.Visible = true;       
            ViewAppt.Visible = true;

            NewPresc.Visible = false;
            RePresc.Visible = false;

            Register.Visible = false;
            ViewPet.Visible = false;
           
            MedRegis.Visible = false;
        }



        protected void InvenBtn_Click(object sender, EventArgs e)
        {
            MedRegis.Visible = true;
           
            NewAppt.Visible = false;
            ViewAppt.Visible = false;
            NewPresc.Visible = false;
            RePresc.Visible = false;
            Register.Visible = false;
            ViewPet.Visible = false;
        }
    }
}