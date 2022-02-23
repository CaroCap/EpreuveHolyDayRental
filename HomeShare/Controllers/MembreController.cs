using HolidayRental.BLL.Entities;
using HolidayRental.Common.Repositories;
using HoliDayRental.Handlers;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Controllers
{
    public class MembreController : Controller
    {
        private readonly IMembreRepository<MembreBLL> _MembreService;
        private readonly IPaysRepository<PaysBLL> _PaysService;

        public MembreController(IMembreRepository<MembreBLL> MembreService, IPaysRepository<PaysBLL> paysService)
        {
            _MembreService = MembreService;
            _PaysService = paysService;

        }

        public IActionResult Index()
        {
            return RedirectToAction("ListeMembre");
        }

        // GET: MembreController
        public IActionResult ListeMembre()
        {
            try
            {
                IEnumerable<MembreListItem> model = _MembreService.Get().Select(c => c.ToListItem());
                model = model.Select(m => { m.Pays = _PaysService.Get((int)m.idPays).ToDetails(); return m; });
                return View(model);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        // GET: MembreController/Details/5
        public ActionResult Details(int id)
        {
            MembreDetails model = _MembreService.Get(id).ToDetails();
            model.Pays = _PaysService.Get((int)model.idPays).ToDetails();
            return View(model);
        }

        // GET: MembreController/Create
        public IActionResult Create()
        {
            MembreCreate model = new MembreCreate();
            // On va utiliser linQ pour aller récupérer la catégorie de notre student = .Select
            // On va utiliser LinQ pour n'avoir qu'une seule fois chaque élément = .Distinct
            // On peut ajouter ToList() ou ToArray() si besoin mais nous on veut IEnumerable donc pas besoin
            model.PaysList = _PaysService.Get().Select(s => s.ToDetails());

            return View(model);
        }

        // POST: MembreController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(MembreCreate collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                MembreBLL result = new MembreBLL(
                    0,
                    collection.Nom,
                    collection.Prenom,
                    collection.Email,
                    collection.idPays,
                    collection.Telephone,
                    collection.Login,
                    collection.Password
                );
                result.idMembre = this._MembreService.Insert(result);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                collection.PaysList = _PaysService.Get().Select(s => s.ToDetails());
                return View(collection);
            }
        }

        // GET: MembreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MembreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MembreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
