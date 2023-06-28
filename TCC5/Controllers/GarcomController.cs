using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC5.Models;

namespace TCC5.Controllers
{
    public class GarcomController : Controller
    {
        // GET: Garcom
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Couvert()
        {
            var couvert = Models.Couvert.GetCouvert();
            ViewBag.Couvert = couvert;
            return View();
        }

        public ActionResult CouvertAdc()
        {
            var couvert = Models.Couvert.GetCouvert();
            ViewBag.Couvert = couvert;
            return View();
        }

        public ActionResult CouvertAlterar(int id)
        {
            var couvert = new Couvert();
            couvert.GetCouvert(id);
            ViewBag.Couvert = couvert;
            return View();
        }

        public ActionResult CouvertExcluir(int id)
        {
            var couvert = new Couvert();
            couvert.GetCouvert(id);
            ViewBag.Couvert = couvert;
            return View();
        }

        public ActionResult Comanda()
        {
            var comanda = Models.Comanda.GetComanda();
            ViewBag.Comanda = comanda;
            return View();
        }

        public ActionResult ComandaAdc()
        {
            var comanda = Models.Comanda.GetComanda();
            ViewBag.Comanda = comanda;
            return View();
        }

        public ActionResult ComandaAlterar(int id)
        {
            var comanda = new Comanda();
            comanda.GetComanda(id);
            ViewBag.Comanda = comanda;
            return View();
        }

        public ActionResult ComandaExcluir(int id)
        {
            var comanda = new Comanda();
            comanda.GetComanda(id);
            ViewBag.Comanda = comanda;
            return View();
        }

        public ActionResult PedidoAdc()
        {
            var pedido = Models.Pedido.GetPedido();
            ViewBag.Pedido = pedido;
            return View();
        }

        public ActionResult Pedido()
        {
            var pedido = Models.Pedido.GetPedido();
            ViewBag.Pedido = pedido;
            return View();
        }

        public ActionResult PedidoAlterar(int id)
        {
            var pedido = new Pedido();
            pedido.GetPedido(id);
            ViewBag.Pedido = pedido;
            return View();
        }

        public ActionResult PedidoExcluir(int id)
        {
            var pedido = new Pedido();
            pedido.GetPedido(id);
            ViewBag.Pedido = pedido;
            return View();
        }

        [HttpPost]
        public void SalvarCouvert()
        {
            var salvar = new Couvert();
            salvar.Id = Convert.ToInt32("0" + Request["id"]);
            salvar.Valor = Convert.ToDecimal(Request["valor"]);
            salvar.Data = Convert.ToDateTime(Request["data"]);

            salvar.Salvar();
            Response.Redirect("/Garcom/Couvert");
        }

        [HttpPost]
        public void ExcluirCouvert()
        {
            var couvert = new Couvert();
            couvert.Id = Convert.ToInt32("0" + Request["id"]);

            couvert.Excluir();
            Response.Redirect("/Adm/Central");
        }

        [HttpPost]
        public void SalvarComanda()
        {
            var salvar = new Comanda();
            salvar.Id = Convert.ToInt32("0" + Request["id"]);
            salvar.Mesa_id = Convert.ToInt32(Request["mesa_id"]);
            salvar.Id_couvert = Convert.ToInt32(Request["id_couvert"]);
            salvar.Data = Convert.ToDateTime(Request["data"]);
            salvar.Valor_comanda = Convert.ToDecimal(Request["valor_comanda"]);
            salvar.Lei_da_gorjeta = Convert.ToDecimal(Request["lei_da_gorjeta"]);
            salvar.Desconto = Convert.ToDecimal(Request["desconto"]);
            salvar.Justificativa_desconto = Convert.ToString(Request["justificativa_desconto"]);

            salvar.Salvar();
            Response.Redirect("/Garcom/Comanda");
        }

        [HttpPost]
        public void ExcluirComanda()
        {
            var comanda = new Comanda();
            comanda.Id = Convert.ToInt32("0" + Request["id"]);

            comanda.Excluir();
            Response.Redirect("/Garcom/Comanda");
        }

        [HttpPost]
        public void SalvarPedido()
        {
            var salvar = new Pedido();
            salvar.Id = Convert.ToInt32("0" + Request["id"]);
            salvar.Comanda_id = Convert.ToInt32(Request["comanda_id"]);
            salvar.Data = Convert.ToDateTime(Request["datetime"]);

            salvar.Salvar();
            Response.Redirect("/Garcom/Pedido");
        }

        [HttpPost]
        public void ExcluirPedido()
        {
            var pedido = new Pedido();
            pedido.Id = Convert.ToInt32("0" + Request["id"]);

            pedido.Excluir();
            Response.Redirect("/Garcom/Comanda");
        }
    }
}