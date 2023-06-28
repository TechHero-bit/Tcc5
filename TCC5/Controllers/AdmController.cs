using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC5.Models;

namespace TCC5.Controllers
{
    public class AdmController : Controller
    {
        // GET: Adm
        public ActionResult Central()
        {
            return View();
        }

        public ActionResult ItemTipoLista()
        {
            var itemT = Models.ItemT.GetItemT();
            ViewBag.ItemT = itemT;
            return View();
        }

        public ActionResult ItemTipoAdc()
        {
            var itemT = Models.ItemT.GetItemT();
            ViewBag.ItemT = itemT;
            return View();
        }

        public ActionResult ItemTipoAlterar(int id)
        {
            var itemT = new ItemT();
            itemT.GetItemT(id);
            ViewBag.ItemT = itemT;
            return View();
        }

        public ActionResult ItemTipoExcluir(int id)
        {
            var itemT = new ItemT();
            itemT.GetItemT(id);
            ViewBag.ItemT = itemT;
            return View();
        }

        public ActionResult ItemLista()
        {
            var item = Models.Item.GetItem();
            ViewBag.Item = item;
            return View();
        }

        public ActionResult ItemAdc()
        {
            var item = Models.Item.GetItem();
            ViewBag.Item = item;
            return View();
        }

        public ActionResult ItemAlterar(int id)
        {
            var item = new Item();
            item.GetItem(id);
            ViewBag.Item = item;
            return View();
        }

        public ActionResult ItemExcluir(int id)
        {
            var item = new Item();
            item.GetItem(id);
            ViewBag.Item = item;
            return View();
        }

        public ActionResult AdcCardapio()
        {
            var cardapio = Models.Menu.GetCardapio();
            ViewBag.Cardapio = cardapio;
            return View();
        }

        public ActionResult AlterarCardapio(int id)
        {
            var cardapio = new Menu();
            cardapio.GetCardapio(id);
            ViewBag.Cardapio = cardapio;
            return View();
        }

        public ActionResult ExcluirCardapio(int id)
        {
            var cardapio = new Menu();
            cardapio.GetCardapio(id);
            ViewBag.Cardapio = cardapio;
            return View();
        }

        public ActionResult AdcSetor()
        {
            var setor = Models.Setor.GetSetor();
            ViewBag.Setor = setor;
            return View();
        }

        public ActionResult AlterarSetor(int id)
        {
            var setor = new Setor();
            setor.GetSetor(id);
            ViewBag.Setor = setor;
            return View();
        }

        public ActionResult ExcluirSetor(int id)
        {
            var setor = new Setor();
            setor.GetSetor(id);
            ViewBag.Setor = setor;
            return View();
        }

        public ActionResult Setores()
        {
            var setor = Models.Setor.GetSetor();
            ViewBag.Setor = setor;
            return View();
        }

        public ActionResult Cadastro()
        {
            var cadastro = Models.Login.GetLogin();
            ViewBag.login = cadastro;
            return View();
        }

        public ActionResult AlterarCadastro(int id)
        {
            var cadastro = new Login();
            cadastro.GetLogin(id);
            ViewBag.login = cadastro;
            return View();
        }

        public ActionResult ExcluirCadastro(int id)
        {
            var cadastro = new Login();
            cadastro.GetLogin(id);
            ViewBag.login = cadastro;
            return View();
        }

        public ActionResult CadastroLista()
        {
            var cadastro = Models.Login.GetLogin();
            ViewBag.login = cadastro;
            return View();
        }

        public ActionResult TipoFuncCad()
        {
            var cadastro = Models.Tpfc.GetTpfc();
            ViewBag.Tpfc = cadastro;
            return View();
        }

        public ActionResult TipoFuncAlterar(int id)
        {
            var cadastro = new Tpfc();
            cadastro.GetTpfc(id);
            ViewBag.Tpfc = cadastro;
            return View();
        }

        public ActionResult TipoFuncExcluir(int id)
        {
            var cadastro = new Tpfc();
            cadastro.GetTpfc(id);
            ViewBag.Tpfc = cadastro;
            return View();
        }

        public ActionResult TipoFunLista()
        {
            var cadastro = Models.Tpfc.GetTpfc();
            ViewBag.Tpfc = cadastro;
            return View();
        }

        public ActionResult SecaoAdc()
        {
            var secao = Models.Secao.GetSecao();
            ViewBag.Secao = secao;
            return View();
        }

        public ActionResult SecaoAlterar(int id)
        {
            var secao =  new Secao();
            secao.GetSecao(id);
            ViewBag.Secao = secao;
            return View();
        }

        public ActionResult SecaoExcluir(int id)
        {
            var secao = new Secao();
            secao.GetSecao(id);
            ViewBag.Secao = secao;
            return View();
        }

        public ActionResult SecaoLista()
        {
            var secao = Models.Secao.GetSecao();
            ViewBag.Secao = secao;
            return View();
        }

        public ActionResult MesaSecaoAdc()
        {
            var mesasecao = Models.MesaSecao.GetMesaSecao();
            ViewBag.MesaSecao = mesasecao;
            return View();
        }

        public ActionResult MesaSecaoAlterar(int id)
        {
            var mesasecao = new MesaSecao();
            mesasecao.GetMesaSecao(id);
            ViewBag.MesaSecao = mesasecao;
            return View();
        }

        public ActionResult MesaSecaoExcluir(int id)
        {
            var mesasecao = new MesaSecao();
            mesasecao.GetMesaSecao(id);
            ViewBag.MesaSecao = mesasecao;
            return View();
        }

        public ActionResult MesaSecaoLista()
        {
            var mesasecao = Models.MesaSecao.GetMesaSecao();
            ViewBag.MesaSecao = mesasecao;
            return View();
        }

        public ActionResult MesaAdc()
        {
            var mesas = Models.Mesa.GetMesas();
            ViewBag.Mesa = mesas;
            return View();
        }

        public ActionResult MesaAlterar(int id)
        {
            var mesas = new Mesa();
            mesas.GetMesas(id);
            ViewBag.Mesa = mesas;
            return View();
        }

        public ActionResult MesaExcluir(int id)
        {
            var mesas = new Mesa();
            mesas.GetMesas(id);
            ViewBag.Mesa = mesas;
            return View();
        }

        public ActionResult ListaMesas()
        {
            var mesas = Models.Mesa.GetMesas();
            ViewBag.Mesa = mesas;
            return View();
        }

        [HttpPost]
        public void SalvarItem()
        {
            var salvar = new Item();

            salvar.Id = Convert.ToInt32("0" + Request["id"]);
            salvar.Nome = Convert.ToString(Request["nome"]);
            salvar.Tipo_Id = Convert.ToInt32(Request["tipo_id"]);
            salvar.Descricao = Convert.ToString(Request["descricao"]);
            salvar.Valor = Convert.ToDecimal(Request["valor"]);
            salvar.Data = Convert.ToDateTime(Request["data"]);

            salvar.Salvar();
            Response.Redirect("/Adm/ItemLista");
        }

        [HttpPost]
        public void ExcluirItem()
        {
            var item = new Item();
            item.Id = Convert.ToInt32("0" + Request["id"]);

            item.Excluir();
            Response.Redirect("/Adm/Central");
        }

        [HttpPost]
        public void SalvarItemT()
        {
            var salvar = new ItemT();

            salvar.Id = Convert.ToInt32("0" + Request["id"]);
            salvar.Nome = Convert.ToString(Request["nome"]);

            salvar.Salvar();
            Response.Redirect("/Adm/ItemTipoLista");
        }

        [HttpPost]
        public void ExcluirItemT()
        {
            var itemT = new ItemT();
            itemT.Id = Convert.ToInt32("0" + Request["id"]);

            itemT.Excluir();
            Response.Redirect("/Adm/Central");
        }

        [HttpPost]
        public void SalvarCard()
        {
            var salvar = new Menu();
            salvar.Id = Convert.ToInt32("0" + Request["id"]);
            salvar.Item_Id = Convert.ToInt32(Request["item_id"]);
            salvar.Descricao = Convert.ToString(Request["descricao"]);
            salvar.Valor = Convert.ToDecimal(Request["valor"]);
            salvar.DataC = Convert.ToDateTime(Request["data"]);

            salvar.Salvar();
            Response.Redirect("/Cliente/Cardapio");
        }

        [HttpPost]
        public void ExcluirCard()
        {
            var menu = new Menu();
            menu.Id = Convert.ToInt32("0" + Request["id"]);

            menu.Excluir();
            Response.Redirect("/Adm/Central");
        }

        [HttpPost]
        public void SalvarSetor()
        {
            var salvar = new Setor();
            salvar.Id = Convert.ToInt32("0" + Request["id"]);
            salvar.Nome = Convert.ToString(Request["nome"]);

            salvar.Salvar();
            Response.Redirect("/Adm/Setores");
        }

        [HttpPost]
        public void ExcluirSetor()
        {
            var setor = new Setor();

            setor.Id = Convert.ToInt32("0" + Request["id"]);

            setor.Excluir();
            Response.Redirect("/Adm/Setores");
        }

        [HttpPost]
        public void SalvarLogin()
        {
            var salvar = new Login();
            salvar.Id = Convert.ToInt32("0" + Request["id"]);
            salvar.Id_tipofunc = Convert.ToInt32(Request["id_tipofunc"]);
            salvar.Id_secao = Convert.ToInt32(Request["id_secao"]);
            salvar.Cpf = Convert.ToString(Request["cpf"]);
            salvar.Nome = Convert.ToString(Request["nome"]);
            salvar.Senha = Convert.ToString(Request["senha"]);
            salvar.Setor = Convert.ToInt32(Request["setor"]);

            salvar.Salvar();
            Response.Redirect("/Adm/CadastroLista");
        }

        [HttpPost]
        public void ExcluirLogin()
        {
            var login = new Login();
            login.Id = Convert.ToInt32("0" + Request["id"]);

            login.Excluir();
            Response.Redirect("/Adm/Central");
        }

        [HttpPost]
        public void SalvarTipofunc()
        {
            var salvar = new Tpfc();
            salvar.Id = Convert.ToInt32("0" + Request["id"]);
            salvar.Id_setor = Convert.ToInt32(Request["id_setor"]);
            salvar.Nome = Convert.ToString(Request["nome"]);
            salvar.Setor = Convert.ToString(Request["setor"]);
            

            salvar.Salvar();
            Response.Redirect("/Adm/TipoFunLista");
        }

        [HttpPost]
        public void ExcluirTipofunc()
        {
            var tpfc = new Tpfc();
            tpfc.Id = Convert.ToInt32("0" + Request["id"]);

            tpfc.Excluir();
            Response.Redirect("/Adm/Central");
        }

        [HttpPost]
        public void SalvarSecao()
        {
            var secao = new Secao();
            secao.Id = Convert.ToInt32(Request["id"]);
            secao.Numero = Convert.ToInt32(Request["numero"]);

            secao.Salvar();
            Response.Redirect("/Adm/SecaoLista");
        }

        [HttpPost]
        public void ExcluirSecao()
        {
            var secao = new Secao();
            secao.Id = Convert.ToInt32(Request["id"]);

            secao.Excluir();
            Response.Redirect("/Adm/SecaoLista");
        }

        [HttpPost]
        public void SalvarMesaSecao()
        {
            var salvar = new MesaSecao();
            salvar.Id_secao = Convert.ToInt32(Request["id_secao"]);
            salvar.Id_mesa = Convert.ToInt32(Request["id_mesa"]);
            salvar.Data = Convert.ToDateTime(Request["data"]);

            salvar.Salvar();
            Response.Redirect("/Adm/MesaSecaoLista");
        }

        [HttpPost]
        public void ExcluirMesaSecao()
        {
            var mesaSecao = new MesaSecao();
            mesaSecao.Id_secao = Convert.ToInt32("0" + Request["id_secao"]);
            

            mesaSecao.Excluir();
            Response.Redirect("/Adm/Central");
        }

        [HttpPost]
        public void SalvarMesa()
        {
            var salvar = new Mesa();
            salvar.Id = Convert.ToInt32("0" + Request["id"]);
            salvar.Numero = Convert.ToInt32(Request["numero"]);
            salvar.Setor = Convert.ToInt32(Request["setor"]);
            salvar.Status = Convert.ToBoolean(Request["status_mesa"]);
            salvar.Data = Convert.ToDateTime(Request["data"]);

            salvar.Salvar();
            Response.Redirect("/Adm/ListaMesas");
        }

        [HttpPost]
        public void ExcluirMesa()
        {
            var mesa = new Mesa();
            mesa.Id = Convert.ToInt32("0" + Request["id"]);

            mesa.Excluir();
            Response.Redirect("/Adm/Central");
        }



    }
}