using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.Web.Areas.Admin.Models;
using Vehicle.Web.Utility;

namespace Vehicle.Web.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        RestsharpHelper restsharp;
        public CustomerController()
        {
            restsharp = new RestsharpHelper();
        }
        public ActionResult Index()
        {
            var md = new CustomerViewModel();
            return View(md);
        }

        public ActionResult GetAllList(int Page = 1, int PageSize = 20)
        {
            string resource = "api/customer?Page=" + Page + "&PageSize=" + PageSize;
            var obj = restsharp.CallApi(resource,Method.GET);
            var data = JsonConvert.DeserializeObject<ListViewModel<CustomerViewModel>>(obj);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateUpdate()
        {
            var md = new CustomerViewModel();
            return View(md);
        }

        [HttpPost]
        public ActionResult CreateUpdate(CustomerViewModel md)
        {
            if (ModelState.IsValid)
            {
                if(md.Id == 0)
                {
                    var resource = "api/customer/createupdate";
                    var dataBody = $"Id={md.Id}&Code={md.Code}&Name={md.Name}&Phone={md.Phone}&Email={md.Email}&Address={md.Address}&Birthday={md.Birthday}&Sex={md.Sex}";
                    var obj = restsharp.CallApi(resource, Method.POST, false, dataBody);
                    if (bool.Parse(obj))
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("Error","Model IsValid");
            }
            return View();
        }

       
    }
}