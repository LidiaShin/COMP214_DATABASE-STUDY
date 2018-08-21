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
    public partial class MedicationRegister : System.Web.UI.Page
    {

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        string petID;
        string prescriptionID; 
        protected void Page_Load(object sender, EventArgs e)
        {
            using (OracleConnection cn = new OracleConnection(cs)) // C#
            {
                string queryA = string.Format("select PRE_ID from PRESCRIPTION where PetID= 3001 and status ='Active'");
                OracleCommand cmd = new OracleCommand(queryA, cn);
                cn.Open();

                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prescriptionID = reader["ID"].ToString();
                }
            } //1 


            using (OracleConnection cn = new OracleConnection(cs)) // C#
            {
                string queryB = string.Format("select * from PRE_MED where PREID = '{0}'",prescriptionID);
                OracleCommand cmd = new OracleCommand(queryB, cn);
                cn.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            //2


            using (OracleConnection cn = new OracleConnection(cs)) // C#
            {
                string query = string.Format("select * from MED_EXAM_REC where PET_ID=3001 ");
                OracleCommand cmd = new OracleCommand(query, cn);
                cn.Open();
                GridView2.DataSource = cmd.ExecuteReader();
                GridView2.DataBind();
            }
        }

       


        protected void Button1_Click(object sender, EventArgs e)
        {


            string medid = DropDownList1.SelectedValue.ToString();
        

            using (OracleConnection cn = new OracleConnection(cs)) // C#
            {
                cn.Open();
                string queryD = string.Format("Insert into PRE_MED (PREID,MEDID,QUANTITY) values ({0},{1},1)", prescriptionID, medid);
                OracleCommand cmd = new OracleCommand(queryD, cn);

                         
            }


        }   
    }
}