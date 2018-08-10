using Fluent_NHibernate_Crud_Basico.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fluent_NHibernate_Crud_Basico.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            VerificacaoParametros();

            using(ISession session = NHibernateHelper.OpenSession())
            {
                var jogos = session.Query<Jogo>().ToList();
                return View(jogos);
            }
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            using(ISession session = NHibernateHelper.OpenSession()) {
                var jogo = session.Get<Jogo>(id);
                return View(jogo);
            }
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Jogo jogo)
        {
            try
            {
                // TODO: Add insert logic here
                using(ISession session = NHibernateHelper.OpenSession()) {
                    using(ITransaction transation = session.BeginTransaction()) { 
                        session.Save(jogo);
                        transation.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var jogo = session.Get<Jogo>(id);
                return View(jogo);
            }
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                using(ISession session = NHibernateHelper.OpenSession()) {
                    var jogoAlterado = session.Get<Jogo>(id);
                    jogoAlterado.Nome = collection["nome"];
                    jogoAlterado.Classificacao = Convert.ToInt16(collection["classificacao"]);

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(jogoAlterado);
                        transaction.Commit();
                    }

                    return RedirectToAction("Index", new {alterado = "ok"});
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var jogo = session.Get<Jogo>(id);
                return View(jogo);
            }
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               
                using(ISession session = NHibernateHelper.OpenSession())
                {
                    var jogoDeletar = session.Get<Jogo>(id);
                    using(ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(jogoDeletar);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index", new { deletado = "ok"});
            }
            catch
            {
                return View();
            }
        }
        
        //Apenas verificando a leitura da QueryString em Mvc
        private void VerificacaoParametros()
        {
            if (Request.QueryString["alterado"] == "ok")
                ViewBag.Operacao = "Jogo foi <b>ALTERADO</b> com sucesso!";

            if (Request.QueryString["deletado"] == "ok")
                ViewBag.Operacao = "Jogo foi <b>DELETADO</b> com sucesso!";
        }


    }
}
