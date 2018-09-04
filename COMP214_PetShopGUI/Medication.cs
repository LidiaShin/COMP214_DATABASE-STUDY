using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class Medication
    {
        public string ManuID { get; set; }
        public string ManuRF { get; set; }
        public string MedName { get; set; }
        public string MedPrice{ get; set; }


        public Medication(string manuid,string manurf,string medname,string medprice)
        {
            ManuID = manuid;
            ManuRF = manurf;
            MedName = medname;
            MedPrice = medprice;
        }
    }
}