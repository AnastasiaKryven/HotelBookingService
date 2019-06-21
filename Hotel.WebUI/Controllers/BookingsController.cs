using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel.DBManager.Data;
using Hotel.DBManager.Repository;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;

namespace Hotel.WebUI.Controllers
{
    public class BookingsController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        //IBookingRepository bookingRepository = new BookingRepository();

        //private HotelContext db = new HotelContext();

        public BookingsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public BookingsController()
        {
        }

        // GET: Bookings
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = unitOfWork.Rooms.GetRoomById(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }


        public ActionResult GetAll()
        {
            return View(unitOfWork.Bookings.Bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = unitOfWork.Bookings.GetBookingById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,Price,DateEntry,DateExit")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Bookings.Create(booking);
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = unitOfWork.Bookings.GetBookingById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,Price,DateEntry,DateExit")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Bookings.Edit(booking);
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = unitOfWork.Bookings.GetBookingById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.Bookings.Delete(id);
            return RedirectToAction("Index");
        }


    }

}