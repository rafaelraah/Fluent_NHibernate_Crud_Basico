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
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
