using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.Web.Areas.Admin.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}