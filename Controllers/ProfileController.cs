using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rental_housing.Models;
using rental_housing.Controllers;
using System.Data.SqlClient;

namespace rental_housing.Controllers
{
    public class ProfileController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Profile
        [HttpGet]
        public new ActionResult Profile()
        {
            return View();
        }

        public void ConnectionString()
        {
            con.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=RentalHousing;Integrated Security=True;Pooling=False";
        }

        [HttpPost]
        public ActionResult EditName(User us)
        {
            string email = (string)Session["email"];
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "update UserProfile set name = '"+us.name+"'  where email = '"+email+"' ";
            try
            {
                dr = com.ExecuteReader();
                Debug.WriteLine("Username updated Successfully");
                con.Close();
                return View("Profile");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditPassword(User us)
        {
            string email = (string)Session["email"];
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "update UserProfile set password = '" + us.password + "'  where email = '" + email + "' ";
            try
            {
                dr = com.ExecuteReader();
                Debug.WriteLine("Password updated Successfully");
                con.Close();
                return View("Profile");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditMobile(User us)
        {
            string email = (string)Session["email"];
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "update UserProfile set mobile = '" + us.mobile + "'  where email = '" + email + "' ";
            try
            {
                dr = com.ExecuteReader();
                Debug.WriteLine("Mobile updated Successfully");
                con.Close();
                return View("Profile");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditEmail(User us)
        {
            string name = (string)Session["name"];
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "update UserProfile set email = '" + us.email + "'  where name = '" + name + "' ";
            try
            {
                dr = com.ExecuteReader();
                Debug.WriteLine("Email updated Successfully");
                con.Close();
                return View("Profile");
            }
            catch (Exception)
            {
                throw;
            }   
        }

    }
}