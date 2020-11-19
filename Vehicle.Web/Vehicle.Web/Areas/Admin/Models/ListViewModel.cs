using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.Web.Areas.Admin.Models
{
    public class ListViewModel<T> where T : class
    {
        public List<T> data { get; set; }
        public int totalRecord { get; set; }
    }
}