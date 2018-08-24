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
            NewAppt.Visible = false;

        }

        protected void CusBtn_Click(object sender, EventArgs e)
        {
            NewPresc.Visible = false;
            RePresc.Visible = false;
            Register.Visible = true;
            NewAppt.Visible = true;
        }
    }
}