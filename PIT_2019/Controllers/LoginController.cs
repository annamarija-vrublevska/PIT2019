using PIT_2019.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIT_2019.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            //SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\sqlite\\PIT.db;");
            //try
            //{
            //    conn.Open();
            //    SQLiteCommand inserCommand = new SQLiteCommand("SELECT * FROM USER_RIGHTS", conn);
            //    SQLiteDataReader reader = inserCommand.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        string t = reader["Title"].ToString();
            //    }
            //}
            //catch (SQLiteException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //}
            return View();
        }

        public ActionResult Login(string userName, string userPassword)
        {
            JsonActionResult res = new JsonActionResult();
            UserModel user = new UserModel();
            SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\sqlite\\PIT.db;");
            try
            {
                conn.Open();
                //SQLiteCommand selectCommand = new SQLiteCommand("SELECT * FROM WORKERS ", conn);
                SQLiteCommand selectCommand = new SQLiteCommand("SELECT * FROM WORKERS WHERE USERNAME = @UserName AND PASSWORD = @Password ", conn);
                selectCommand.Parameters.Add(new SQLiteParameter("@UserName", userName.ToLower()));
                selectCommand.Parameters.Add(new SQLiteParameter("@Password", userPassword));
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                
                while (reader.Read())
                {
                    user.Id = Int32.Parse(reader["ID"].ToString());
                    user.FirstName = reader["FIRSTNAME"].ToString();
                    user.Surname = reader["SURNAME"].ToString();
                    user.UserName = reader["USERNAME"].ToString();
                    user.Phome = reader["PHONE"].ToString();
                    user.Rights = (UserRights) Int32.Parse(reader["RIGHTSLEVEL"].ToString());
                }                
            }
            catch (SQLiteException)
            {
                res.Success = false;
                res.Message = "Notika kļūda datu ielādē";
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                res.Success = false;
                res.Message = "Pakalpojuma izmantošanas laikā notika kļūda";
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                conn.Close();
            }
            if (String.IsNullOrEmpty(user.UserName))
            {
                res.Success = false;
                res.Message = "Nepareizs lietotja vārds vai parole";
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            Session["currentUser"] = user;
            res.Success = true;
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserProfile()
        {
            return View();
        }
    }
}