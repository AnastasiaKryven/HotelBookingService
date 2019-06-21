using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Hotel.DBManager.Data;
using Hotel.DBManager.Repository;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using Hotel.WebUI.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel.WebUI.Controllers
{
    public class RoomsController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        //private IRoomRepository roomRepository = new RoomRepository();
        public int pageSize = 3;


        //public RoomsController(IRoomRepository roomRepository)
        //{
        //    this.roomRepository = roomRepository;
        //}

        public RoomsController()
        {
        }

        public RoomsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Rooms
        public ActionResult Index(int page=1)
        {
            RoomViewModel roomView = new RoomViewModel
            {
                Rooms = unitOfWork.Rooms.Rooms
                .OrderBy(room => room.RoomId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = unitOfWork.Rooms.Rooms.Count()
                }
            };
            return View(roomView);
        }

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

        
    }
}
