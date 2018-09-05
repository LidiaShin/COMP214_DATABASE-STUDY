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

        string cname { get; set; }
        DataTable plisttable { get; set; }

        string PrescNum { get; set; }
        DataTable Prescription { get; set; }

        protected void searchPresc_Click(object sender, EventArgs e)
        {
            PrescListView();
        }

        public void PrescListView()
        {

            cname = cusNameInput.Text;
            SearchPresc presc = new SearchPresc(cname, plisttable);

            try
            {
                ConnectionClass.SearchPrescList(presc);
                PrescListTable.DataSource = presc.PrescTable;
                PrescListTable.DataBind();
            }

            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Error! ');</script>");
            }

            finally
            {


            }
        }

        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (PrescListTable.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            if (hdnText.Value != "")
            {
                string yourValue = hdnText.Value.ToString();
                if (yourValue == "Default")
                {
                    PrescListView();
                }
                else
                {
                    this.PrescListView();
                }
            }
            //else
            //{
            this.PrescListView();
            //}
        }

        protected void ViewPescription(object sender, EventArgs e)
        {
           


            try
            {
                Button btn = (Button)(sender);
                PrescNum = btn.CommandArgument;
                PrescID.Text = PrescNum;

                ViewPresc prescex = new ViewPresc(PrescNum, Prescription);
                ConnectionClass.ViewPrescription(prescex);
                SeePresc.DataSource = prescex.Prescription;
                SeePresc.DataBind();
            }

            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Error! ');</script>");
            }

        }
        /*protected void reIssuePresc(object sender, EventArgs e)
        {
            //prescriptionID = Convert.ToInt32(preID.Text);
            //prescriptionID = preID.Text;

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
        } */


    }
}
