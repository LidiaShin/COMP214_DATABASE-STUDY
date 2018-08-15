using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace COMP214_PetShopGUI
{
    public class ConnectionClass
    {

        private static OracleConnection cntString;
        private static OracleCommand cmdString;

        static ConnectionClass()
        {
            cntString = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

 //using (OracleConnection cntstring = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)){
 //   }

        public static void testDisplay(TestTablePET petInfo)
        {
          

            //cmdString = new OracleCommand(tQuery, cntString);

          

            //cmd.CommandText = "select * from emp";

            try
            {
                //string tQuery = string.Format(@"select * from PET where ID= :{0}", petInfo.petID);
                 
                string tQuery = string.Format("select * from PET where ID={0}", petInfo.petID);
                OracleCommand cmd = new OracleCommand(tQuery, cntString);
                cntString.Open();


                OracleDataReader reader1 = cmd.ExecuteReader();



                while (reader1.Read())
                {
                    petInfo.petName=  reader1["NAME"].ToString();
                    
                }
            }
                //cmdString.ExecuteNonQuery();



                /*OracleDataAdapter da = new OracleDataAdapter(cmdString);

                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);

                if (dt.Rows.Count > 0)
                { petInfo.petName = "cc"; }

                else
                {
                    { petInfo.petName = "ccc"; }

                }

            }*/

            finally
            {
                cntString.Close();
            }



        }
    }
}