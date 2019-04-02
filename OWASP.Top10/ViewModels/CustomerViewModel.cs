using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OWASP.Top10.ViewModels
{
    public class CustomerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CustomerId { get; internal set; }
    }
}