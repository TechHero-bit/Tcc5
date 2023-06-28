using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCC5.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Cardapio()
        {
            var cardapio = Models.Menu.GetCardapio();
            ViewBag.Cardapio = cardapio;
            return View();
        }
    }
}