using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class VetID
    {
        public DataTable VetIDs { get; set; }

        public VetID(DataTable vid)
        {
            VetIDs = vid;
        }
    }
}