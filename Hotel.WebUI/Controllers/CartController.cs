using Hotel.DBManager.Repository;
using Hotel.Domain.Entities;
using Hotel.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WebUI.Controllers
{
    public class CartController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public CartController()
        {
        }

        public CartController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View( new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            }
                );
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


        public RedirectToRouteResult AddToCart(Cart cart, int roomId, string returnUrl)
        {
            Room room = unitOfWork.Rooms.Rooms
                .FirstOrDefault(g => g.RoomId == roomId);

            if (room != null)
            {
                cart.AddItem(room, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int roomId, string returnUrl)
        {
            Room room = unitOfWork.Rooms.Rooms
                .FirstOrDefault(g => g.RoomId == roomId);

            if (room != null)
            {
                cart.RemoveLine(room);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}