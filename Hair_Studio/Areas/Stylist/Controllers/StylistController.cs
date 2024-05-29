using System;
using Hair_Studio.DAL.Stylist;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Hair_Studio.Areas.Stylist.Models;
using Hair_Studio.BAL;

namespace Hair_Studio.Areas.Stylist.Controllers
{
    [Area("Stylist")]
    [Route("Stylist/[controller]/[action]")]
    [CheckAccess]
    public class StylistController:Controller
	{

        StylistDAL stylistDAL = new StylistDAL();

        #region Stylist List
        public IActionResult StylistList()
        {
            DataTable dataTable = stylistDAL.StylistSelectAll();
            return View("StylistList", dataTable);
        }
        #endregion

        #region Stylist Save
        public IActionResult StylistSave(StylistModel stylistModel)
        {
            if (ModelState.IsValid)
            {
                if (stylistDAL.StylistSave(stylistModel))

                   return RedirectToAction("StylistList");

            }
            return View("StylistAddEdit");
        }
        #endregion

        #region Stylist By ID
        public IActionResult StylistAdd(int StylistID)
        {
            StylistModel stylistModel = stylistDAL.StylistByID(StylistID);
            if (stylistModel != null)
            {
                ViewBag.ServiceList = stylistDAL.ServiceDropdownModel();
                Console.WriteLine();
                return View("StylistAddEdit", stylistModel);
            }
            else
            {
                ViewBag.ServiceList  = stylistDAL.ServiceDropdownModel();
                return View("StylistAddEdit");
            }
        }
        #endregion

        #region Stylist Delete
        public IActionResult StylistDelete(int StylistID)
        {
            bool isSuccess = stylistDAL.StylistDelete(StylistID);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "Record deleted successfully";
                return RedirectToAction("StylistList");
            }
            return RedirectToAction("StylistList");
        }
        #endregion
    }
}

