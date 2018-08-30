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
    public partial class reIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        string prescriptionID { get; set; }

        string cs = ConfigurationManager.ConnectionStrings["petshop2018"].ConnectionString;

        protected void checkPreID_Click(object sender, EventArgs e)
        {
            //prescriptionID = Convert.ToInt32(preID.Text);
            prescriptionID = preID.Text;

            using (OracleConnection cn = new OracleConnection(cs))
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "reissue_prescription";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@P_ID", OracleDbType.Int32).Value = Convert.ToInt32(prescriptionID);
                
                cmd.ExecuteNonQuery();

            
                cn.Close();


            }
        }

        protected void checkTable_Click(object sender, EventArgs e)
        {



            prescriptiontable.Visible = true;

        }
    }
}
