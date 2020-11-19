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
    [Authorize]
    public class CategoryController : Controller
    {
        RestsharpHelper restsharp;
        public CategoryController()
        {
            restsharp = new RestsharpHelper();
        } 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllList(int Page = 1,int PageSize = 20)
        {
            string resource = "api/category?Page=" + Page + "&PageSize=" + PageSize;
            var json = restsharp.CallApi(resource, Method.GET);  //gọi hàm CallApi => trả về object string
            //chuyển Json --> kiểu .NET object 
            ListViewModel<CategoryViewModel> data = JsonConvert.DeserializeObject<ListViewModel<CategoryViewModel>>(json);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult _FormPartitalCategory()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult CreateUpdate(CategoryViewModel md)
        {
            if (ModelState.IsValid)
            {
                string resource = "api/category/createupdate";
                string dataBody = $"Id={md.Id}&Name={md.Name}";
                var obj = restsharp.CallApi(resource, Method.POST, false, dataBody);
                if (bool.Parse(obj))
                {
                    return RedirectToAction("Index");
                }

                //$.get  $.post

            //service --> $http({})
            }
            else
            {
                ModelState.AddModelError("error","validate data fail");
            }

            

            return View();


        }



    }
}