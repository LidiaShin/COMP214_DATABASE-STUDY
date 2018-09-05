using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class InquiryPet
    {
        public string customerName { get; set; }
        public string OwnerID { get; set; }
        public string PetName { get; set; }
        public string PetBirthDay { get; set; }

        public DataTable petList { get; set; }

        public InquiryPet(string cname, string oid, string pname,string pbday,DataTable plist)
        {
            customerName = cname;
            OwnerID = oid;
            PetName = pname;
            PetBirthDay = pbday;
            petList = plist;
        }
    }
}