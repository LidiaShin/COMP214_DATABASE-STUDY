using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace COMP214_PetShopGUI
{
    public class ConnectionClass
    {
        private static OracleConnection cntString;

        private static OracleCommand cmdString;
        private static OracleCommand cmeString;

        static ConnectionClass()
        {
            cntString = new OracleConnection(ConfigurationManager.ConnectionStrings["petshop2018"].ConnectionString);
        }

        public static void AvoidDuplicateEmail(Customer newInfo)
        {
            string aQuery = string.Format(@"select * from CUSTOMER where EMAIL = ('{0}')", newInfo.emailAddress);
            cmdString = new OracleCommand(aQuery, cntString);

            try
            {
                cntString.Open();

                OracleDataAdapter da = new OracleDataAdapter(cmdString);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);
                if (dt.Rows.Count > 0)
                {
                    //newInfo.emailAddress = dt.Rows[0]["LAST_NAME"].ToString();
                    newInfo.emailAddress = "EXIST";
                }

                else
                {
                    //newInfo.emailAddress = "NEW";
                }
            }

            finally
            {
                cntString.Close();
            }
        }


        public static void Register(Customer newInfo)
        {
            string bQuery = string.Format("insert into CUSTOMER (ID,FIRST_NAME,LAST_NAME,EMAIL,PHONE#) VALUES (CUSTOMERID_SEQ.nextval,'{0}','{1}','{2}',{3})", newInfo.firstName,newInfo.lastName,newInfo.emailAddress, Convert.ToInt64(newInfo.phoneNumber));
            // phone # Convert.ToInt64(newInfo.phoneNumber) caution! Convert.ToInt32 not working!
            cmdString = new OracleCommand(bQuery, cntString);

            try
            {
                cntString.Open();
                cmdString.ExecuteNonQuery();
            }

            finally
            {
                cntString.Close();
            }
        }


        public static void OnwerIDList(OwnerID ids)
        {
            string cQuery = string.Format(@"select ID from CUSTOMER");
            cmdString = new OracleCommand(cQuery, cntString);

            try
            {
                cntString.Open();
                OracleDataAdapter da = new OracleDataAdapter(cmdString);
                DataTable dt = new DataTable();

                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);

                //DataView dv = new DataView(dt);
                ids.OwnerIDs = ds.Tables[0];
            }

            finally
            {
                cntString.Close();
            }
        }
     
        public static void RegisterPet(Pet newPet)
        {
           string dQuery = string.Format("insert into PET (ID,OWNER_ID,NAME,BIRTHDAY) VALUES(petID_seq.nextval,{0},'{1}',TO_DATE('{2}','YYYY-MM-DD'))",newPet.OwnerID,newPet.PetName,newPet.PetBirthDay);
           cmdString = new OracleCommand(dQuery, cntString);
        
           try
           {
            cntString.Open();
            cmdString.ExecuteNonQuery();
            }

           finally
           {
           cntString.Close();
           }
        }



        public static void PetIDList(PetID ids)
        {
            string eQuery = string.Format(@"select ID from PET");
            cmdString = new OracleCommand(eQuery, cntString);

            try
            {
                cntString.Open();
                OracleDataAdapter da = new OracleDataAdapter(cmdString);
                DataTable dt = new DataTable();

                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);

                ids.PetIDs = ds.Tables[0];
            }

            finally
            {
                cntString.Close();
            }
        }


        public static void MedicationList(MedList mlist)
        {
            string fQuery = string.Format(@"SELECT ID,NAME FROM MEDICATION");
            cmdString = new OracleCommand(fQuery, cntString);

            try
            {
                cntString.Open();
                OracleDataAdapter da = new OracleDataAdapter(cmdString);
                DataTable dt = new DataTable();

                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);

                mlist.MedItems = ds.Tables[0];
               
            }

            finally{
                cntString.Close();
            }
        }


        public static void PrescriptionList(PrescList preitem)
        {
            string gQuery = string.Format(@"INSERT INTO PRESCRIPTION_LIST (PRE_ID,PET_ID,ORDER_DATE)
VALUES(PREID_SEQ.NEXTVAL,{0},SYSDATE)", Convert.ToInt64(preitem.PetID));

            string hQuery = string.Format(@"select PREID_SEQ.CURRVAL FROM DUAL");

            cmdString = new OracleCommand(gQuery, cntString);
            cmeString = new OracleCommand(hQuery, cntString);
            try
            {
                cntString.Open();
                cmdString.ExecuteNonQuery();

                cmeString.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmeString);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);

                preitem.PrescID = dt.Rows[0]["CURRVAL"].ToString();


            }

            finally
            {
                cntString.Close();
            }


        }



    }
}
