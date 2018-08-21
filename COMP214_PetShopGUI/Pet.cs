using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class Pet
    {
        public string OwnerID { get; set; }
        public string PetName { get; set; }
        public string PetBirthDay { get; set; }

        public Pet(string oID,string pname,string pbirthday)
        {
            OwnerID = oID;
            PetName = pname;
            PetBirthDay = pbirthday;
        }

    }
}