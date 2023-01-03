using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpotifyProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace SpotifyProject.Controllers
{

    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("login");
        }

        static class MySqlConnect
        {
            private static MySqlConnection _Connection;
            public static MySqlConnection Connection
            {
                get
                {
                    if (_Connection == null)
                    {
                        string csb = @"server=127.0.0.1; user id=root; password=''; database=spotify";
                        _Connection = new MySqlConnection(csb);
                    }

                    if (_Connection.State == ConnectionState.Closed)
                        try
                        {
                            _Connection.Open();
                        }
                        catch (Exception)
                        {
                            //handle your exception here
                        }
                    return _Connection;
                }
            }
        }

        public bool LoginDetails(string username, string password)
        {
            {


                using (MySqlConnection con = MySqlConnect.Connection)
                {

                    MySqlCommand cmd = new MySqlCommand("select * from users where username = @username AND password = @Password", con);

                    MySqlParameter uName = new MySqlParameter("@username", MySqlDbType.VarChar);
                    MySqlParameter uPassword = new MySqlParameter("@Password", MySqlDbType.VarChar);

                    uName.Value = username;
                    uPassword.Value = password;

                    cmd.Parameters.Add(uName);
                    cmd.Parameters.Add(uPassword);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        AccountDetails account = new AccountDetails();
                        account.username = username;
                        username = string.Empty;
                        password = string.Empty;
                        reader.Close();
                        cmd.Dispose();
                        con.Close(); // always close connection
                        return true;

                    }
                    else
                    {
                        username = string.Empty;
                        password = string.Empty;
                        reader.Close();
                        cmd.Dispose();
                        con.Close(); // always close connection
                        return false;

                    }
                }
            }
        }

        public ActionResult LoginClick(string txtUsername, string txtPassword)
        {

            string username = txtUsername;
            string password = txtPassword;
            


            if (LoginDetails(username, password))
            {
                TempData["Username"] = username;
               
                return RedirectToAction("Index", "home");
            }
            else
            {
               return RedirectToAction("index");
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

