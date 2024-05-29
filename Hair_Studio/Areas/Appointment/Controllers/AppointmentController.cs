using System;
using System.Data;
using Hair_Studio.Areas.Appointment.Models;
using Hair_Studio.BAL;
using Hair_Studio.DAL.Appointment;
using Hair_Studio.DAL.Stylist;
using Microsoft.AspNetCore.Mvc;

namespace Hair_Studio.Areas.Appointment.Controllers
{
    [Area("Appointment")]
    [Route("Appointment/[controller]/[action]")]
    [CheckAccess]
    public class AppointmentController:Controller
	{
            AppointmentDAL appointmentDAL = new AppointmentDAL();
        //CategoryDAL categoryDAL = new CategoryDAL();

        #region Appointment List (Active)
        public IActionResult AppointmentList()
            {
                DataTable dataTable = appointmentDAL.AppointmentSelectAll();
                ViewBag.Save = TempData["Save"];
                ViewBag.Delete = TempData["Delete"];
                ViewBag.Update = TempData["Update"];
                return View(dataTable);
            }
        #endregion

        //#region Product List (In Active)
        //public IActionResult DeletedProductList()
        //{
        //    DataTable dataTable = productDAL.ProductDeletedSelectAll();
        //    ViewBag.Retrive = TempData["Retrive"];
        //    return View(dataTable);
        //}
        //#endregion

        //#region Product List (User Side)
        //public IActionResult ShoppingProductList()
        //{
        //    DataTable dataTable = productDAL.ProductSelectAll();
        //    ViewBag.CategoryList = productDAL.CategoryDropDown();
        //    return View(dataTable);
        //}
        //#endregion

        //#region Product List By ID (User Side)
        //public IActionResult ShoppingProductByID(int ProductID)
        //{
        //    DataTable dataTable = productDAL.ShoppingProductByID(ProductID);
        //    return View(dataTable);
        //}
        //#endregion

        #region Appointment Save
        public IActionResult AppointmentSave(AppointmentModel appointmentModel)
            {
            StylistDAL stylistDAL = new StylistDAL();


                    if (appointmentDAL.AppointmentSave(appointmentModel))
                    {
                        TempData["Save"] = "Appointment Saved Successfully";
                        return RedirectToAction("AppointmentList");
                    }
                    else
                    {
                        return RedirectToAction("AppointmentList");
                    }
            ViewBag.ServiceList = stylistDAL.ServiceDropdownModel();

            return View("AppointmentAddEdit");
            }
        #endregion

        #region Appointment By ID
        public IActionResult AppointmentAdd(int AppointmentID)
        {
            StylistDAL stylistDAL = new StylistDAL();
            if (AppointmentID != 0)
            {
                ViewBag.ServiceList = stylistDAL.ServiceDropdownModel();
                DataTable appointmentModel = appointmentDAL.AppointmentByID(AppointmentID);

                //ViewBag.CategoryList = appointmentDAL.CategoryDropDown();
                // return View("AppointmentAddEdit", appointmentModel);
                return View();
            }
            else
            {
                ViewBag.ServiceList = stylistDAL.ServiceDropdownModel();
                //ViewBag.CategoryList = productDAL.CategoryDropDown();
                return View("AppointmentAddEdit");
            }
        }
        #endregion

        #region Appointment Delete
        public IActionResult AppointmentDelete(int AppointmentID)
            {
                bool isSuccess = appointmentDAL.AppointmentDelete(AppointmentID);
                if (isSuccess)
                {
                    TempData["Delete"] = "Appointment Deleted Successfully";
                    return RedirectToAction("AppointmentList");
                }
                return RedirectToAction("AppointmentList");
            }
            #endregion

            //#region Product Retrive
            //public IActionResult ProductRetrive(int ProductID)
            //{
            //    bool isSuccess = productDAL.ProductRetrive(ProductID);
            //    if (isSuccess)
            //    {
            //        TempData["Retrive"] = "Product Retrived Successfully";
            //        return RedirectToAction("DeletedProductList");
            //    }
            //    return RedirectToAction("DeletedProductList");
            //}
            //#endregion

            //#region Multiple Product Delete 
            //public IActionResult DeleteMultipleProducts(int[] ProductIDs)
            //{
            //    Console.WriteLine(ProductIDs[0]);
            //    bool isSuccess = productDAL.DeleteMultipleProducts(ProductIDs);
            //    if (isSuccess)
            //    {
            //        TempData["Delete"] = "Selected Product Deleted Successfully";
            //        return RedirectToAction("ProductList");
            //    }
            //    else
            //    {
            //        return RedirectToAction("ProductList");
            //    }
            //}
            //#endregion

            //#region Category Filter
            //public IActionResult ProductFilter(ProductFilterModel productFilterModel)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        DataTable dataTable = productDAL.ProductFilter(productFilterModel);
            //        ViewBag.CategoryList = productDAL.CategoryDropDown();
            //        ModelState.Clear();
            //        return View("ShoppingProductList", dataTable);
            //    }
            //    else
            //    {
            //        // Handle invalid model state if needed
            //        return View("ShoppingProductList");
            //    }
            //}
            //#endregion
    }
}

