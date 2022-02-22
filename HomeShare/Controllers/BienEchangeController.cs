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
    public class BienEchangeController : Controller
    {
        private readonly IBienEchangeRepository<BienEchangeBLL> _BienEchangeService;
        //private readonly IMembreRepository<MembreBLL> _MembreService;
        //private readonly IPaysRepository<PaysBLL> _PaysService;
        //public BienEchangeController(IBienEchangeRepository<BienEchangeBLL> bienEchangeService, IMembreRepository<MembreBLL> membreService, IPaysRepository<PaysBLL> paysService)
        //{
        //    _BienEchangeService = bienEchangeService;
        //    _MembreService = membreService;
        //    _PaysService = paysService;
        //}

        public BienEchangeController(IBienEchangeRepository<BienEchangeBLL> bienEchangeService, IMembreRepository<MembreBLL> membreService, IPaysRepository<PaysBLL> paysService)
        {
            _BienEchangeService = bienEchangeService;
        }

        // GET: BienEchangeController
        public IActionResult Index()
        {
            IEnumerable<BienEchangeListItem> model = _BienEchangeService.Get().Select(c => c.ToListItem());
            return View(model);
        }

        // GET: BienEchangeController/Details/5
        public ActionResult Details(int id)
        {
            BienEchangeDetails model = _BienEchangeService.Get(id).ToDetails();
            //model.Diffusions = _diffusionService.GetByCinemaId(id).Select(d => d.ToDetails());
            return View(model);
        }

        // GET: BienEchangeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BienEchangeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: BienEchangeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BienEchangeController/Edit/5
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

        // GET: BienEchangeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BienEchangeController/Delete/5
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
