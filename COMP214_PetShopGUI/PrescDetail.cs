using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class PrescDetail
    {
        public string[] PrescID { get; set; }
        


        public string[] MedID { get; set; }
        public string[] MedQty { get; set; }
        public PrescDetail(string[] preid,string[] medid,string[] medqty)
        {
            PrescID = preid;
            MedID = medid;
            MedQty = medqty;
        }
    }
}