using Newtonsoft.Json;
using RestSharp;
using System;
using System.Web.Mvc;
using System.Web.Security;
using Vehicle.Web.Areas.Admin.Models;
using Vehicle.Web.Utility;

namespace Vehicle.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        RestsharpHelper restSharp;

        public LoginController()
        {
            restSharp = new RestsharpHelper();
        }

        public ActionResult Index()
        {
            var md = new LoginViewModel();
            return View(md);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel md)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string encodedBody = $"username={md.UserName}&password={md.Password}&grant_type=password";
                    //gọi hàm CallApi => trả về object 
                    var obj = restSharp.CallApi("token", Method.POST,true, encodedBody);
                    //chuyển object 
                    TokenModel token = JsonConvert.DeserializeObject<TokenModel>(obj);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                                                    "VEHICLE_COOKIE",   // tên cookie
                                                                    DateTime.Now,
                                                                    DateTime.Now.AddDays(2),
                                                                    false,
                                                                    token.access_token,
                                                                    FormsAuthentication.FormsCookiePath);

                    string cookie = FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, cookie));

                    return RedirectToAction("Index","Test");
                }
                catch (Exception Ex)
                {
                    
                }               
            }
            else
            {
                ModelState.AddModelError("Error","Username and Password incorrest");
            }
            return View("Index");
        }
    }
}