using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class CustomerPets
    {
        public string CustomerID { get; set; }
        public DataTable PetIDs { get; set; }
        public DataTable PetNames { get; set; }

        public CustomerPets(string cid, DataTable pids, DataTable pnames)
        {
            CustomerID = cid;
            PetIDs = pids;
            PetNames = pnames;
        }

    }

    
}