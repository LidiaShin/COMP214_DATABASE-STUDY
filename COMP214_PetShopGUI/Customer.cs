using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class Customer
    {
        public string ownerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }

        public string phoneNumber { get; set; }

        public Customer(string oid,string fname,string lname,string email,string pnum)
        {
            ownerId = oid;
            firstName = fname;
            lastName = lname;
            emailAddress = email;
            phoneNumber = pnum;
        }


    }
}