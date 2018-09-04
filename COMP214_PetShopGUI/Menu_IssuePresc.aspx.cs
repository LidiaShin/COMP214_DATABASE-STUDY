using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace COMP214_PetShopGUI
{
    public partial class Menu_IssuePresc : System.Web.UI.Page
    {
        // pet information (ID)
        DataTable ids { get; set; }

        //medication information (ID, NAME)
        DataTable mitems { get; set; }
       

        // Prescription Issue (1) : Prescription ID (SQ), Pet ID (DROPBOX LIST), ORDER DATE (SYSDATE)
        string PrescID { get; set; }
        string PetID { get; set; }
        string PrescOrderDate { get; set; }


        // linkedlist for medication items for prescriptoin
       LinkedList<string> medilist
        {
            get { return (LinkedList<string>)Session["mediitemlist"]; }
            set { Session["mediitemlist"] = value; }
        }

        // linkedlist for quantity of medication items for prescriptoin
        // each variable (=linked list) has a different session name
        LinkedList<string> mediqtylist
        {
            get { return (LinkedList<string>)Session["mediitemqtylist"]; }
            set { Session["mediitemqtylist"] = value; }
        }

        LinkedList<string> mediidlist
        {
            get { return (LinkedList<string>)Session["mediitemidlist"]; }
            set { Session["mediitemidlist"] = value; }
        }

        // arrays for inserting values into DB
        string[] MediArray
        {
            get
            {
                /*if (Session["medarr"] == null)
                {
                    Session["medarr"] = new string[] { };
                } */
                return (string[])Session["medarr"];
            }
            set
            {
                Session["medarr"] = value;
            }
        }

        string[] MediQtyArray
        {
            get
            {
                /*if (Session["medqtyarr"] == null)
                {
                    Session["medqtyarr"] = new string[] { };
                } */
                return (string[])Session["medqtyarr"];
            }
            set
            {
                Session["medqtyarr"] = value;
            }
        }

        string[] MediIDArray
        {
            get
            {
                /*if (Session["medidarr"] == null)
                {
                    Session["medidarr"] = new string[] { };
                } */
                return (string[])Session["medidarr"];
            }
            set
            {
                Session["medidarr"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
   

            if (!IsPostBack)
            {
                // store linkedlist items during the session
                //if (Session["mediitemlist"] == null && Session["mediitemqtylist"] == null && Session["mediitemidlist"] == null && Session["medarr"] == null && Session["medqtyarr"] == null && Session["medidarr"] == null)
                //{
                    Session["mediitemlist"] = new LinkedList<string>();
                    Session["mediitemqtylist"] = new LinkedList<string>();
                    Session["mediitemidlist"] = new LinkedList<string>();
                    Session["medarr"] = new string[] { };
                    Session["medqtyarr"] = new string[] { };
                    Session["medidarr"] = new string[] { };
                //}


               // Display dropdownlist with Pet ID 
              PetID Ids = new PetID(ids);

              
              MedList Meds = new MedList(mitems);
             
                try
                {
                    ConnectionClass.PetIDList(Ids);
                    PetIDList.DataSource = Ids.PetIDs;
                    PetIDList.DataTextField = Ids.PetIDs.Columns["NNAME"].ToString();
                    PetIDList.DataValueField = Ids.PetIDs.Columns["ID"].ToString();
                    PetIDList.DataBind();

                    ConnectionClass.MedicationList(Meds);
                    MedList.DataSource = Meds.MedItems;
                    MedList.DataTextField = Meds.MedItems.Columns["NAME"].ToString();
                    MedList.DataValueField = Meds.MedItems.Columns["ID"].ToString();
                    MedList.DataBind();
                }

                finally
                {

                }
                // Display Quantity Number

                for (int i = 1; i <= 100; i++)
                {
                    InputQtyNum.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }

        }

        protected void MedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        protected void StartIssue_Click(object sender, EventArgs e)
        {
            PetID = PetIDList.SelectedValue.ToString();

            PrescList newPresc = new PrescList(PrescID, PetID, PrescOrderDate);

            try
            {
                ConnectionClass.PrescriptionList(newPresc);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Success! ');</script>");
                displayPetID.Text = PetID;
                displayPrescID.Text = newPresc.PrescID;
                // This goes to prescriptionID and array
                
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('failed');</script>");
            }

            finally
            {

            }
            
        }

        string MedName;
        string MedNum;
        string MedQty;

        protected void AddMed_Click(object sender, EventArgs e)
        {
          
            if (lblmedilist.Text == "Please add new med item and quantity")
            {
                lblmedilist.Text = "";
                lblmediqtylist.Text = "";
                lblmediidlist.Text = "";


                fillPresc();
            }
            else
            {
                fillPresc();
            } 
        } 
        
       
        public void fillPresc()
        {

            MedName = MedList.SelectedItem.ToString();
            MedNum = MedList.SelectedValue.ToString();
            MedQty = InputQtyNum.SelectedItem.ToString();
            //add linkedlist & display on the label (Med Items)


            //add med item to linkedlist (1 by 1)  & display on the label (Med Item Name)
            medilist.AddLast(MedName);
    
            MediArray = medilist.ToArray();
            // convert linkedlist to array
            // or, string medlinkedlist = string.Join("<br>", medilist.ToArray());

            string medlinkedlist = string.Join("<br>", MediArray);
            // convert array to string to display on the label
            // 첫번째 array[0] 에선 발생하지 않음
            // 두번째 element 부터 join 시작

            lblmedilist.Text = medlinkedlist;
            // Display on the label (rendering)


            //Add linkedlist & display on the label (Med Item ID)
            mediidlist.AddLast(MedNum);       
            MediIDArray = mediidlist.ToArray();
            string medidlinkedlist = string.Join("<br>", MediIDArray);
            lblmediidlist.Text = medidlinkedlist;
        
            //Add linkedlist & display on the label (Med Item Quantity)
            mediqtylist.AddLast(MedQty);
            MediQtyArray = mediqtylist.ToArray();
            string medqtylinkedlist = string.Join("<br>", MediQtyArray);      
            lblmediqtylist.Text = medqtylinkedlist;
 

            // Display Table's header 
            medqtyheader.Visible = true;
            mednameheader.Visible = true;
            medidheader.Visible = true;

          
            // for hidden div (for printing values)
            string MedItems;
            MedItems = "<br>" + MedName + "(" + MedQty + ")";
            mlists.Text += MedItems;

        } 
       
        protected void DelMed_Click(object sender, EventArgs e)
        {
            try
            {
               
                //remove linkedlist on the label (1 by 1, from the very last one)
                medilist.RemoveLast();
                MediArray = medilist.ToArray();
                string medlinkedlist = string.Join("<br>", MediArray);
                lblmedilist.Text = medlinkedlist;



                mediidlist.RemoveLast();
                MediIDArray = mediidlist.ToArray();
                string medidlinkedlist = string.Join("<br>", MediIDArray);
                lblmediidlist.Text = medidlinkedlist;




                mediqtylist.RemoveLast();
                MediQtyArray = mediqtylist.ToArray();
                string medqtylinkedlist = string.Join("<br>", MediQtyArray);
                lblmediqtylist.Text = medqtylinkedlist;

                mlists.Text= mlists.Text.Remove(mlists.Text.LastIndexOf("<br>"));
            }

            catch
            {
                lblmedilist.Text = "Please add new med item and quantity";
            } 
           
        }

       
        protected void save(object sender, EventArgs e)
        {
            
            // Populating array of Prescription ID, same length of Medication IDs and Medication Quantities
            string TPrescID = displayPrescID.Text;
                string[] PrescID = new string[MediArray.Length];
                for (int i = 0; i < MediArray.Length; i++)
                {
                    PrescID[i] = TPrescID;
                }

                PrescDetail newPrescDetails = new PrescDetail(PrescID, MediIDArray, MediQtyArray);
                try
                {
                    ConnectionClass.SaveNewPresc(newPrescDetails);

                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Prescription saved successfully! ');</script>");
                }
                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Cancelled ');</script>");
                }
        }

    }
}

/* Backup & Testing code 1)
 * 
        string MedItems;
        string MedItemQtys; 

            MedItems = "  " + MedName + "<br>";        
            MedItemQtys = "  " + MedQty + "<br>";
            //"  " : space for indexing (for remove)

            meditemslist.Text += MedItems;
            meditemsqty.Text += MedItemQtys;
            */

/* meditemslist.Text = meditemslist.Text.Remove(meditemslist.Text.LastIndexOf("  "));
   meditemsqty.Text = meditemsqty.Text.Remove(meditemsqty.Text.LastIndexOf("  "));
  */

/* Backup & Testing code 2)
 * 
string cs = ConfigurationManager.ConnectionStrings["petshop2018"].ConnectionString;
using (OracleConnection cn = new OracleConnection(cs))
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "TESTSP_Presc";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.ArrayBindCount = PrescID.Length;

                cmd.Parameters.Add("@para_preid", OracleDbType.Varchar2).Value = newPrescDetails.PrescID;
                cmd.Parameters.Add("@para_medid", OracleDbType.Varchar2).Value = newPrescDetails.MedID;
                cmd.Parameters.Add("@para_medqty", OracleDbType.Varchar2).Value = newPrescDetails.MedQty;

                cmd.ExecuteNonQuery();
                cn.Close();
            } 
PrescDetail newPrescDetails = new PrescDetail(displayPrescID.Text, "3002", "4");
try
{
    //ConnectionClass.SaveNewPresc(newPrescDetails);

    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Success! ');</script>");
}

catch
{
    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert(' Failed! ');</script>");
}
finally
{
    test.Text = string.Join("", MediIDArray) + "<br>" + string.Join(" + ", MediQtyArray) + displayPrescID.Text;
} */



/* Backup & Testing Code 3) Check Array's element with displaying on the label
 * 
 * string testarray =  string.Join(" ",MediArray);
   string testqtyarray = string.Join(" ", MediQtyArray);
 */
