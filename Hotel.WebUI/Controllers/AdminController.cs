using Hotel.DBManager.Data;
using Hotel.DBManager.Repository;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // private IRoomRepository roomRepository = new RoomRepository();

        UnitOfWork unitOfWork = new UnitOfWork();

        public AdminController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public AdminController()
        {
        }

        public ActionResult Index()
        {
            return View(unitOfWork.Rooms.Rooms.ToList());
        }

        // GET: Rooms/Details/5
        public ActionResult Details(int? id)
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

        // GET: Rooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomId,Price,CountOfPeople,RoomClass,RoomState")] Room room)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Rooms.Create(room);
                return RedirectToAction("Index");
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "RoomId,Price,CountOfPeople,RoomClass,RoomState")] Room room)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(room).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(room);
        //}

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room room, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    room.ImageMimeType = image.ContentType;
                    room.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(room.ImageData, 0, image.ContentLength);
                }
                unitOfWork.Rooms.SaveRoom(room);

                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(room);
            }
        }

        public FileContentResult GetImage(int roomId)
        {
            Room room = unitOfWork.Rooms.Rooms
                .FirstOrDefault(g => g.RoomId == roomId);

            if (room != null)
            {
                return File(room.ImageData, room.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.Rooms.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
