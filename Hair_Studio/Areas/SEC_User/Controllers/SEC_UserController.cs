using System;
using System.Data;
using Hair_Studio.Areas.SEC_User.Models;
using Hair_Studio.BAL;
using Hair_Studio.DAL.SEC_User;
using Microsoft.AspNetCore.Mvc;

namespace Hair_Studio.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("SEC_User/[controller]/[action]")]
    
    public class SEC_UserController:Controller
	{
        public IActionResult SEC_UserLogin()
        {
            return View("Login");
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(SEC_UserModel modelSEC_User)
        {
      
            SEC_UserDAL sEC_UserDAL = new SEC_UserDAL();
            if (modelSEC_User.UserName == null)
            {
                TempData["UserNameError"] = "User Name is Required!";
            }

            if (modelSEC_User.Password == null)
            {
                TempData["PasswordError"] = "Password is Required!";
            }

            //if (TempData["UserNameError"] != null || TempData["PasswordError"] != null)
            //{
            //    return RedirectToAction("SEC_UserSignIn", "SEC_User");
            //}
            else
            {
                DataTable dt = sEC_UserDAL.PR_User_SelectByUserNamePassword(modelSEC_User.UserName, modelSEC_User.Password);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());
                        HttpContext.Session.SetString("FirstName", dr["FirstName"].ToString());
                        HttpContext.Session.SetString("LastName", dr["LastName"].ToString());
                        HttpContext.Session.SetString("Email", dr["Email"].ToString());
                        HttpContext.Session.SetString("ImageURL", dr["ImageURL"].ToString());
                        HttpContext.Session.SetString("Phone", dr["Phone"].ToString());
                        HttpContext.Session.SetString("Address", dr["Address"].ToString());
                        HttpContext.Session.SetString("IsAdmin", dr["IsAdmin"].ToString());
                        break;
                    }
                }

                else
                {
                    TempData["Error"] = "UserName or Password is invalid!";
                    //return RedirectToAction("SEC_UserSignIn");
                }

                if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
                {
                    if (CV.IsAdmin())
                    {
                        return RedirectToAction("Index", "SEC_Admin", new { area = "SEC_Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "SEC_User", new { area = "SEC_User" });
                    }
                }

            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminLayout()
        {
            return View("~/Views/Shared/_Layout");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return new RedirectResult("~/Home/Index");

        }
    }
}

