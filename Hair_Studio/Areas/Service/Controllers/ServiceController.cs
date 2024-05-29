using System;
using Hair_Studio.DAL.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Hair_Studio.Areas.Service.Models;
using Hair_Studio.BAL;

namespace Hair_Studio.Areas.Service.Controllers
{
    [Area("Service")]
    [Route("Service/[controller]/[action]")]
    [CheckAccess]
    public class ServiceController:Controller
	{
       
            ServiceDAL serviceDAL = new ServiceDAL();

            #region Service List
            public IActionResult ServiceList()
            {
                DataTable dataTable = serviceDAL.ServiceSelectAll();
                return View("ServiceList", dataTable);
            }
        #endregion

            #region Service Save
            public IActionResult ServiceSave(ServiceModel serviceModel)
            {

                if (serviceDAL.ServiceSave(serviceModel))
                    return RedirectToAction("ServiceList");
                return View("ServiceAddEdit");
            }
            #endregion

            #region Service By ID
            public IActionResult ServiceAdd(int ServiceID)
                {
                    ServiceModel serviceModel = serviceDAL.ServiceByID(ServiceID);
                    if (serviceModel != null)
                    {
                        return View("ServiceAddEdit", serviceModel);
                    }
                    else
                    {
                        return View("ServiceAddEdit");
                    }
                }
                #endregion

            #region Service Delete
            public IActionResult ServiceDelete(int ServiceID)
            {
                bool isSuccess = serviceDAL.ServiceDelete(ServiceID);
                if (isSuccess)
                {
                TempData["SuccessMessage"] = "Record deleted successfully";
                return RedirectToAction("ServiceList");
                }
                return RedirectToAction("ServiceList");
            }
            #endregion
        }
    }


