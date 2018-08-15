using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class TestTablePET
    {

       
        public string petID { get; set; }
        public string ownerID { get; set; }
        public string petName { get; set; }

        public string petBirthday { get; set; }

        public TestTablePET(string pid, string oid, string pname,string pday)
        {
            pid = petID;
            oid = ownerID;
            pname = petName;
            pday = petBirthday;

        }



    }
}