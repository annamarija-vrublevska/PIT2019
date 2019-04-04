using PIT_2019.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIT_2019.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult List()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\sqlite\\PIT.db;");
            try
            {
                conn.Open();
                SQLiteCommand selectCommand = new SQLiteCommand("SELECT * FROM Workers", conn);
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    string t = reader["Title"].ToString();
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return View();
        }

        public ActionResult Get(int id)
        {
            ViewBag.CurrentUser = Session["currentUser"] as UserModel;
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }
    }
}