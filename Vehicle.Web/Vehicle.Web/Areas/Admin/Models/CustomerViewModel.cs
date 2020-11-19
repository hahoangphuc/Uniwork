using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.Web.Areas.Admin.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Sex { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> RowNo { get; set; }
    }
}