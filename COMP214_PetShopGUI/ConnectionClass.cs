using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
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
            string aQuery = string.Format(@"SELECT * FROM CUSTOMER where EMAIL = ('{0}')", newInfo.emailAddress);
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
            //string bQuery = string.Format(@"INSERT INTO CUSTOMER (ID,FIRST_NAME,LAST_NAME,EMAIL,PHONE#) VALUES (CUSTOMERID_SEQ.nextval,'{0}','{1}','{2}',{3})", newInfo.firstName,newInfo.lastName,newInfo.emailAddress, Convert.ToInt64(newInfo.phoneNumber));
            // phone # Convert.ToInt64(newInfo.phoneNumber) caution! Convert.ToInt32 not working!

            string bQuery = string.Format(@"INSERT INTO CUSTOMER (ID,FIRST_NAME,LAST_NAME,EMAIL,PHONE#) VALUES (CUSTOMERID_SEQ.nextval,'{0}','{1}','{2}','{3}')", newInfo.firstName, newInfo.lastName, newInfo.emailAddress,newInfo.phoneNumber);
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
            string cQuery = string.Format(@"SELECT ID,(FIRST_NAME || ' ' || LAST_NAME || ', ID: ' || ID) AS NAME from CUSTOMER");
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
           string dQuery = string.Format(@"INSERT INTO PET (ID,OWNER_ID,NAME,BIRTHDAY) VALUES(petID_seq.nextval,'{0}','{1}',TO_DATE('{2}','YYYY-MM-DD'))",newPet.OwnerID,newPet.PetName,newPet.PetBirthDay);
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
            string eQuery = string.Format(@"SELECT ID,NAME from PET");
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
            // Convert.ToInt64 주의 

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


        public static void VetIDList(VetID ids)
        {
            string hQuery = string.Format(@"SELECT ID from VET");
            cmdString = new OracleCommand(hQuery, cntString);

            try
            {
                cntString.Open();
                OracleDataAdapter da = new OracleDataAdapter(cmdString);
                DataTable dt = new DataTable();

                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);

                //DataView dv = new DataView(dt);
                ids.VetIDs = ds.Tables[0];
            }

            finally
            {
                cntString.Close();
            }
        }


        // 다름!!!
        public static void GetPetIDList(CustomerPets CPets)
        {
            string iQuery = string.Format(@"SELECT ID,NAME FROM PET WHERE OWNER_ID={0}",CPets.CustomerID);
            cmdString = new OracleCommand(iQuery, cntString);

            try
            {
                cntString.Open();
                OracleDataAdapter da = new OracleDataAdapter(cmdString);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);

                // ID랑 NAME 둘다 있음 (첫번째 칼럼 : ID, 두번째칼럼: NAME)
                // 첫번째 칼럼 (ID) 는 DataValueField에, 두번째 칼럼 (NAME) 은 DataTextField에 넣어준다 
                CPets.PetIDs = ds.Tables[0];
               


                //ids.PetIDs = ds.Tables[0];

            }

            finally
            {
                cntString.Close();
            }
        }


        
        public static void ConfirmNewAppointment(VetAppointment newappt)
        {
            string jQuery = string.Format(@"INSERT INTO VET_APPOINTMENT (ID,VET_ID,PET_ID,DATE_TIME,NOTES,PRICE,DISCOUNT)
VALUES(VETAPPT_ID_SEQ.nextval,'{0}','{1}',TO_DATE('{2}','YYYYMONDDHH:MI'),'{3}','{4}',SEARCHDISCOUNT({1}))", newappt.VetID, newappt.PetID, newappt.VetApptTime, newappt.VetApptNote, newappt.VetApptPrice);
            // Convert.ToInt64 주의  
            // SEARCHDISCOUNT 는 펑션

            cmdString = new OracleCommand(jQuery, cntString);
            
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
        
        public static void GetApptDetail(Customer cus)
        {
            string kQuery = string.Format(@"SELECT * FROM CUSTOMER WHERE ID = '{0}'",cus.ownerId);
            cmdString = new OracleCommand(kQuery, cntString);
            try
            {
                cntString.Open();
                OracleDataAdapter da = new OracleDataAdapter(cmdString);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);
                //newInfo.emailAddress = dt.Rows[0]["LAST_NAME"].ToString();
                cus.emailAddress = dt.Rows[0]["EMAIL"].ToString();
                cus.firstName = dt.Rows[0]["FIRST_NAME"].ToString();
                cus.lastName = dt.Rows[0]["LAST_NAME"].ToString();
            }

            finally
            {
                cntString.Close();
            }
        }

        public static void SendConfirmEmail(AppointmentEmail newEmail)
        {
            MailMessage msg = new MailMessage();
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

            try
            {
                msg.Subject = newEmail.EmailSubject;
                msg.Body = newEmail.EmailContent;
                msg.From = new MailAddress("dodam.KGHS@gmail.com");
                msg.To.Add(newEmail.CustomerEmail);

                msg.IsBodyHtml = true;
                client.Host = "smtp.gmail.com";
                System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("dodam.KGHS@gmail.com", "1142311423");

                client.Port = int.Parse("587"); //if using SSL 465
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicauthenticationinfo;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(msg);
                
            }
            finally
            {
             
            }
        }

        public static void SaveNewPresc(PrescDetail newPresc)
        {
            //string lQuery = string.Format(@"INSERT INTO PRESCRIPTION_DETAIL (PRE_ID,MED_ID,QTY) VALUES({0},{1},{2})", newPresc.MedID,newPresc.MedID,newPresc.MedQty);
            

            cmdString = new OracleCommand();

            try
            {
                cntString.Open();

                cmdString.Connection = cntString;
                cmdString.CommandText = "TESTSP_PRESC";
                cmdString.CommandType = CommandType.StoredProcedure;

                cmdString.ArrayBindCount = newPresc.MedID.Length;


                cmdString.Parameters.Add("@PARA_PREID", OracleDbType.Varchar2).Value = newPresc.PrescID;

                //cmdString.Parameters.Add("@PARA_MEDID", OracleDbType.Varchar2);
                //cmdString.Parameters[0].Value = newPresc.MedID;
                cmdString.Parameters.Add("@PARA_MEDID", OracleDbType.Varchar2).Value = newPresc.MedID;


                //cmdString.Parameters.Add("@PARA_MEDQTY", OracleDbType.Varchar2);
                //cmdString.Parameters[1].Value = newPresc.MedQty;
                cmdString.Parameters.Add("@PARA_MEDQTY", OracleDbType.Varchar2).Value = newPresc.MedQty;

                cmdString.ExecuteNonQuery();
            }

            finally
            {
                cntString.Close();
            }
        }





    }
}
