using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace COMP214_PetShopGUI
{
    public partial class registerCustomer : System.Web.UI.Page
    {

        // Set customer properties
        string ownerID { get; set; }

        // also can be used to pet class
        string firstname { get; set; }
        string lastname { get; set; }

        string emailaddress {
            get;set;
          }




        string phonenum { get; set; }

        // Set property for ownerID dropboxlist
        DataTable ids { get; set; }

        // Set pet properties
        string PetName { get; set; }
        string PetBirthday { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
                 
            if (!IsPostBack)
            {
         
                // Display dropdownlist with Customer ID (=OwnerID)
                OwnerID Ids = new OwnerID(ids);
                try
                {
                    ConnectionClass.OnwerIDList(Ids);
                    OwnerID.DataSource = Ids.OwnerIDs;
                    OwnerID.DataTextField = Ids.OwnerIDs.Columns["NAME"].ToString();
                    OwnerID.DataValueField = Ids.OwnerIDs.Columns["ID"].ToString();
                    OwnerID.DataBind();
                }
                finally
                {

                }


                // Display Calendar with month, year and date
                for (int i = 1; i <= 12; i++)
                {
                    System.Globalization.DateTimeFormatInfo monthnum = new System.Globalization.DateTimeFormatInfo();
                    month.Items.Add(new ListItem(monthnum.GetAbbreviatedMonthName(i).ToString(), i.ToString()));
                }

                for(int i = 1980; i <= System.DateTime.Now.Year; i++)
                {
                    year.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }
        protected void selectmonth(object sender, EventArgs e)
        {
            day.Items.Clear();
            for (int i = 1; i < System.DateTime.DaysInMonth(int.Parse(year.SelectedValue), int.Parse(month.SelectedValue)); i++)
            {
                day.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        //string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void checkPnumEmail_Click(object sender, EventArgs e)
        {
            emailaddress = eMail.Text;
            phonenum = pNumber.Text;

            // checking phone number & email (1) validate phone number & email format with regex
            if (Regex.IsMatch(emailaddress, "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$") 
                && Regex.IsMatch(phonenum, "^[0][1-9]\\d{9}$|^[1-9]\\d{9}$"))
            {
                emailCheck.Text = " * Valid email address :)";
                emailCheck.ForeColor= System.Drawing.Color.Blue;
                emailCheck.Visible = true;

                pnumCheck.Text = " * Valid phone number :)";
                pnumCheck.ForeColor = System.Drawing.Color.Blue;
                pnumCheck.Visible = true;

                // checking email (2) avoid duplicate email in DB
                // Initialize Customer Class & connect to Oracle DB via ConnectionClass  


                Customer newCustomer = new Customer(ownerID, firstname, lastname, emailaddress, phonenum);
                ConnectionClass.AvoidDuplicateEmail(newCustomer);

                // if email is existing one,prompt user to use other email address
                if (newCustomer.emailAddress == "EXIST")
                {
                    // prompt user to use other email
                    emailCheck.Text = " * Already in use";
                    emailCheck.ForeColor = System.Drawing.Color.Red;
                    emailCheck.Visible = true;

                    Response.Write("<script type='text/javascript'>");
                    Response.Write("alert('This email address is already registered, Please use another email');");
                    Response.Write("</script>");
                }

                else
                {
                    emailCheck.Text = " * You can use this email address";
                    emailCheck.Visible = true;

                    Response.Write("<script type='text/javascript'>");
                    Response.Write("alert('Information check finished, Ready to register :) ');");
                    Response.Write("</script>");

                    fName.Enabled = false;
                    lName.Enabled = false;
                    pNumber.Enabled = false;
                    eMail.Enabled = false;

                    register.Visible = true;
                }
            }


            else if(Regex.IsMatch(emailaddress, "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
            {
            
                pnumCheck.Text = " * Please enter a valid phone number.";
                pnumCheck.ForeColor = System.Drawing.Color.Red;
                pnumCheck.Visible = true;

                emailCheck.Text = " * Valid email address :)";
                emailCheck.ForeColor = System.Drawing.Color.Blue;
                emailCheck.Visible = true;


            }

            else if (Regex.IsMatch(phonenum, "^[0][1-9]\\d{9}$|^[1-9]\\d{9}$"))
            {
                emailCheck.Text = " * Please enter a valid email address.";
                emailCheck.ForeColor = System.Drawing.Color.Red;
                emailCheck.Visible = true;

                pnumCheck.Text = " * Valid phone number :)";
                pnumCheck.ForeColor = System.Drawing.Color.Blue;
                pnumCheck.Visible = true;
            }

            else
            {
                pnumCheck.Text = " * Please enter a valid phone number.";
                pnumCheck.ForeColor = System.Drawing.Color.Red;
                pnumCheck.Visible = true;

                emailCheck.Text = " * Please enter a valid email address.";
                emailCheck.ForeColor = System.Drawing.Color.Red;
                emailCheck.Visible = true;
            }

        }

        protected void register_Click(object sender, EventArgs e)
        {
            firstname = fName.Text;
            lastname = lName.Text;         
            emailaddress = eMail.Text;
            phonenum = pNumber.Text;

           
             //Initialize Customer Class & connect to Oracle DB via ConnectionClass  
               Customer newCustomer = new Customer(ownerID,firstname, lastname, emailaddress, phonenum);
               
                    try
                    {
                        ConnectionClass.Register(newCustomer);
                        // phone # Converting Caution:Convert.ToInt32 not working. Check ConnectionClass. 
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Registered successfully!');</script>");
                    }

                    catch
                    {                    
                        Response.Write("<script type='text/javascript'>");
                        Response.Write("alert('Please make sure each information inserted properly ');");
                        Response.Write("</script>");                  
                    }

                    finally
                    {
                        //check.Text = newCustomer.phoneNumber;
                    }
              
        }
        protected void selectdate(object sender, EventArgs e)
        {
            
        }
        protected void registerPet_Click(object sender, EventArgs e)
        {
            ownerID = OwnerID.SelectedValue.ToString();
            PetName = pname.Text;
            PetBirthday = year.SelectedValue.ToString() + '-' + month.SelectedValue.ToString() + '-' + day.SelectedValue.ToString();
           

            try
            {
                Pet newPet = new Pet(ownerID,PetName,PetBirthday);
                ConnectionClass.RegisterPet(newPet);
                // phone # Converting Caution:Convert.ToInt32 not working. Check ConnectionClass. 
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New Pet Registered successfully!');</script>");
            }

            catch
            {
                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('please fill out all required fields ');");
                Response.Write("</script>");
            }

            finally
            {
                
            }
        }

       
    }
}