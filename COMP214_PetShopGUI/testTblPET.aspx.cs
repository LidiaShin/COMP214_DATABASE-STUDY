using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        string petID { get; set; }
        string ownerID { get; set; }
        string petName { get; set; }
        string petBirthday { get; set; }

       

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        protected void check_Click(object sender, EventArgs e)
        {
            petID = petid.Text;

            TestTablePET newInfo = new TestTablePET(petID,ownerID,petName,petBirthday);

            
            using (OracleConnection cn = new OracleConnection(cs))

            {
                string tQuery = string.Format("select * from PET where ID={0}",petID);
                OracleCommand cmd = new OracleCommand(tQuery, cn);
                cn.Open();

                OracleDataReader reader1 = cmd.ExecuteReader();

                try
                {
                    while (reader1.Read())
                    {
                        pname.Text = reader1["NAME"].ToString();
                       
                    }
                }

                finally
                {
                    cn.Close();
                }
            }





        }
    }
}