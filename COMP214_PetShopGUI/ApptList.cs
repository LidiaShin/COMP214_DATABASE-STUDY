using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class ApptList
    {
        public string ApptID { get; set; }
        public string PetID { get; set; }

        public string PetName { get; set; }
        public string CusName { get; set; }
        public string ApptDateTime { get; set; }

        public DataTable ApptTable { get; set; }

        public ApptList(string aptid,string pid,string pname,string cname,string aptdt,DataTable apttable)
        {
            ApptID = aptid;
            PetID = pid;
            PetName = pname;
            CusName = cname;
            ApptDateTime = aptdt;
            ApptTable = apttable;
        }
    }
}