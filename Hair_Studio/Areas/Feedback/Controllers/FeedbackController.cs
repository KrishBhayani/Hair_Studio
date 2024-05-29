using System;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Hair_Studio.DAL.Feedback;
using Hair_Studio.Areas.Feedback.Models;
using Hair_Studio.BAL;

namespace Hair_Studio.Areas.Feedback.Controllers
{
    [Area("Feedback")]
    [Route("Feedback/[controller]/[action]")]
    [CheckAccess]
    public class FeedbackController : Controller
    {

        FeedbackDAL feedbackDAL = new FeedbackDAL();

        #region  Feedback List
        public IActionResult FeedbackList()
        {
            DataTable dataTable = feedbackDAL.FeedbackSelectAll();
            return View("FeedbackList", dataTable);
        }
        #endregion

        #region Feedback Save
        public IActionResult FeedbackSave(FeedbackModel feedbackModel)
        {

            if (feedbackDAL.FeedbackSave(feedbackModel))
                return RedirectToAction("FeedbackList");
            return View("FeedbackAddEdit");
        }
        #endregion

        #region Feedback By ID
        public IActionResult FeedbackAdd(int FeedbackID)
        {
            FeedbackModel feedbackModel = feedbackDAL.FeedbackByID(FeedbackID);
            if (feedbackModel != null)
            {
                return View("FeedbackAddEdit", feedbackModel);
            }
            else
            {
                return View("FeedbackAddEdit");
            }
        }
        #endregion

        #region Feedback Delete
        public IActionResult FeedbackDelete(int FeedbackID)
        {
            bool isSuccess = feedbackDAL.FeedbackDelete(FeedbackID);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "Record deleted successfully";
                return RedirectToAction("FeedbackList");
            }
            return RedirectToAction("FeedbackList");
        }
        #endregion
    }
}

