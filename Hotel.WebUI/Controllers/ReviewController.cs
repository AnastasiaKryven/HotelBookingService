using Hotel.DBManager.Data;
using Hotel.DBManager.Repository;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using Hotel.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WebUI.Controllers
{
    public class ReviewController : Controller
    {
        //IReviewRepository reviewRepository = new ReviewRepository();

        UnitOfWork unitOfWork = new UnitOfWork();

        public ReviewController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ReviewController()
        {
        }

        public ActionResult Index(Review review)
        {
            ReviewViewModel reviewView = new ReviewViewModel
            {
                Reviews = unitOfWork.Reviews.Reviews
            };
            //ViewBag.R = unitOfWork.Reviews.Reviews;
            return View(reviewView);
        }

        [HttpGet]
        public ActionResult AddFeedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeedback(Review review)
        {
            unitOfWork.Reviews.Create(review);

            return RedirectToAction("Index");
        }

    }
}