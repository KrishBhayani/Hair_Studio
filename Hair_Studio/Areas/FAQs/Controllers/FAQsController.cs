using System;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Hair_Studio.DAL.FAQs;
using Hair_Studio.Areas.FAQs.Models;
using Hair_Studio.BAL;

namespace Hair_Studio.Areas.FAQs.Controllers
{
    [Area("FAQs")]
    [Route("FAQs/[controller]/[action]")]
    [CheckAccess]
    public class FAQsController:Controller
	{

        FAQsDAL fAQsDAL = new FAQsDAL();

        #region FAQs List
        public IActionResult FAQsList()
            {
                DataTable dataTable = fAQsDAL.FAQsSelectAll();
                return View("FAQsList", dataTable);
            }
        #endregion

        #region FAQs Save
        public IActionResult FAQsSave(FAQsModel fAQsModel)
            {

                if (fAQsDAL.FAQsSave(fAQsModel))
                    return RedirectToAction("FAQsList");
                return View("FAQsAddEdit");
            }
        #endregion

        #region FAQs By ID
        public IActionResult FAQsAdd(int FAQID)
            {
                FAQsModel fAQseModel = fAQsDAL.FAQsByID(FAQID);
                if (fAQseModel != null)
                {
                    return View("FAQsAddEdit", fAQseModel);
                }
                else
                {
                    return View("FAQsAddEdit");
                }
            }
        #endregion

        #region FAQs Delete
        public IActionResult FAQsDelete(int FAQID)
            {
                bool isSuccess = fAQsDAL.FAQsDelete(FAQID);
                if (isSuccess)
                {
                TempData["SuccessMessage"] = "Record deleted successfully";
                return RedirectToAction("FAQsList");
                }
                return RedirectToAction("FAQsList");
            }
            #endregion
        
    }
}

