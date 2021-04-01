using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using rental_housing.Models;

namespace rental_housing.Controllers
{
    public class LoginSignupController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: LoginSignup
        [HttpGet]
        public ActionResult LoginSignup()
        {
            return View();
        }
        public void ConnectionString()
        {
            con.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=RentalHousing;Integrated Security=True;Pooling=False";
        }
        [HttpPost]
        public ActionResult Verify(User login)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from UserProfile where ( email='" + login.email + "' or mobile='" + login.email + "' ) and password='" + login.password + "'";
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read() && login.password == dr.GetString(2))
                {
                    Debug.WriteLine("Login Successful");
                    Session["email"] = dr.GetString(1);
                    Session["name"] = dr.GetString(0);
                    Debug.WriteLine(dr.GetString(0)+" "+dr.GetString(1));
                    con.Close();
                    return View("Dashboard");
                }
                else
                {
                    Debug.WriteLine("email or password incorrect");
                    con.Close();
                    return View("LoginSignup");
                }
            }
            else
            {
                Debug.WriteLine("Check Database-No Rows");
                return View("LoginSignup");
            }
        }

        [HttpPost]
        public ActionResult Register(User reg)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "insert into UserProfile (name,email,password,mobile,category) values ('"+reg.name+"','"+reg.email+"','"+reg.password+"','"+reg.mobile+"','"+reg.category+"');";
            try
            {
                dr = com.ExecuteReader();
                Debug.WriteLine("Registered Successfully");
                con.Close();
                    return View("LoginSignup");
            }
            catch (Exception)
            {
                throw;
            }

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