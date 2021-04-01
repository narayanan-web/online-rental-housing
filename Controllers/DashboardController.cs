using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rental_housing.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            try
            {
                Session["email"] = null;
                Session["name"] = null;
                Session.Clear();
                Response.Cookies.Clear();
                Response.Cache.SetNoStore();
                Response.CacheControl = "no-cache";
                Debug.WriteLine("Logout Successfully");
                return View("LoginSignup");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}