using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class SearchPresc
    {
        public string CusName { get; set; }
        public DataTable PrescTable { get; set; }

        public SearchPresc(string cname, DataTable prelist)
        {
            CusName = cname;
            PrescTable = prelist;
        }
    }
}