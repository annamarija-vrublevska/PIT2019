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
            SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\sqlite\\PIT.db;");
            try
            {
                conn.Open();
                SQLiteCommand inserCommand = new SQLiteCommand("SELECT * FROM USER_RIGHTS", conn);
                SQLiteDataReader reader = inserCommand.ExecuteReader();
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

        public ActionResult Login(string userName, string userPassword)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\sqlite\\PIT.db;");
            try
            {
                conn.Open();
                //SQLiteCommand selectCommand = new SQLiteCommand("SELECT * FROM WORKERS ", conn);
                SQLiteCommand selectCommand = new SQLiteCommand("SELECT * FROM WORKERS WHERE USERNAME = ? AND PASSWORD = ? ", conn);
                selectCommand.Parameters.Add(new SQLiteParameter(DbType.String, userName.ToLower()));
                selectCommand.Parameters.Add(new SQLiteParameter(DbType.String, userPassword));
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    string t = reader["ID"].ToString();
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
            return null;
        }
    }
}