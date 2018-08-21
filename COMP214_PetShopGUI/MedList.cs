using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class MedList
    {
        public DataTable MedItems { get; set; }
        //public DataTable MedsName { get; set; }

       

        public MedList(DataTable meditem)
        {
            MedItems = meditem;        
        }
    }
}