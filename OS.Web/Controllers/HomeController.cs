using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Test()
        {
            var sql = "Select * from Hello Where id=1";
            string err = string.Empty;
            var result = string.Empty;
            using (var dr = GetDataReader(out err, sql))
            {
                if (dr.Read())
                {
                    var obj = new Object();
                    obj = dr["Text"];
                    if (obj != DBNull.Value)
                        result = (string)obj;
                }
            }
            return result;
        }

        private static MySqlDataReader GetDataReader(out string error, string sql)
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            MySqlDataReader dr = null;
            error = string.Empty;
            try
            {
                var conn = new MySqlConnection(ConnectionString);
                var comm = new MySqlCommand(sql, conn);
                conn.Open();
                dr = comm.ExecuteReader();

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return dr;
        }
    }
}
