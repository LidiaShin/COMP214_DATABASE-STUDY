using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class ViewPresc
    {
        public string PNumber { get; set; }
        public DataTable Prescription { get; set; }

        public ViewPresc(string pnum, DataTable presc)
        {
            PNumber = pnum;
            Prescription = presc;
        }
    }
}