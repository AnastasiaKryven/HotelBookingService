using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Hotel.WebUI.Models;
using Hotel.WebUI.App_Start;

namespace Hotel.WebUI.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }
    }
}