using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class VetAppointment
    {
        public string VetID { get; set; }
        public string PetID { get; set; }
        public string VetApptTime { get; set; }
        public string VetApptNote { get; set; }
        public string VetApptPrice { get; set; }
        public VetAppointment(string vetid, string petid, string appttime, string apptnote, string apptprice)
        {
            VetID = vetid;
            PetID = petid;
            VetApptTime = appttime;
            VetApptNote = apptnote;
            VetApptPrice = apptprice;

        }
    }

    
}