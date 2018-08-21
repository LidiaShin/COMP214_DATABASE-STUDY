using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class PrescList
    {
        public string PrescID { get; set; }
        public string PetID { get; set; }
        public string PrescOrderDate { get; set; }

        public PrescList(string preid, string pid, string podate)
        {
            PrescID = preid;
            PetID = pid;
            PrescOrderDate = podate;
        }
    }
}