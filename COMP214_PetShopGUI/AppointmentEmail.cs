using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP214_PetShopGUI
{
    public class AppointmentEmail
    {
        public string EmailSubject { get; set; }
        public string EmailContent {get;set;}
        public string CustomerEmail { get; set; }

        public AppointmentEmail(string subject,string content,string cusemail)
        {
            EmailSubject = subject;
            EmailContent = content;
            CustomerEmail = cusemail;
        }

    }
}