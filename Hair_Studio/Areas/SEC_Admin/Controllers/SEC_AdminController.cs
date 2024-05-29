using System;
using System.Data;
using System.Data.SqlClient;
using Hair_Studio.BAL;
using Microsoft.AspNetCore.Mvc;

namespace Hair_Studio.Areas.SEC_Admin.Controllers
{
    [Area("SEC_Admin")]
    [Route("SEC_Admin/[controller]/[action]")]
    [CheckAccess]
    public class SEC_AdminController : Controller
	{
        private readonly IConfiguration Configuration;

        public SEC_AdminController(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }

  //      public IActionResult Index()
		//{
		//	return View();
  //      }

        public IActionResult Index()
        {
            string connectionStr = this.Configuration.GetConnectionString("ConnectionString");
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand objCmd = connection.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CountRecords]";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            dt.Load(objSDR);
            Console.WriteLine(dt.Rows.Count);
            return View(dt);
        }

    }
    
}

