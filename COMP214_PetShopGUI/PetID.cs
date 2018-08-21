using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class PetID
    {
        public DataTable PetIDs { get; set; }
        public PetID(DataTable pid)
        {
            PetIDs = pid;
        }
    }
}