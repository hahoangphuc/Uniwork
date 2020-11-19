using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vehicle.Web.Models
{
    public class SelectListModel
    {
        public static List<SelectListItem> lsGener()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem (){Value = "0", Text = "Please select..."},
                new SelectListItem(){Value = "1",Text = "Male"},
                new SelectListItem (){Value = "2",Text = "Female" },
                new SelectListItem(){Value = "3",Text = "Other"}
            };
        }
    }
}