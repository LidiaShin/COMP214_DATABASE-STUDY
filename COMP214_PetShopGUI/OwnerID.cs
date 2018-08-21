using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class OwnerID
    {
        public DataTable OwnerIDs { get; set; }
        public OwnerID(DataTable oid)
        {
            OwnerIDs = oid; 
        }

    }
}