using HolidayRental.BLL.Entities;
using HolidayRental.Common.Repositories;
using HoliDayRental.Handlers;
using HoliDayRental.Infrastructure.Helpers;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContext;

        private readonly IBienEchangeRepository<BienEchangeBLL> _BienEchangeService;
        private readonly IPaysRepository<PaysBLL> _PaysService;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext, IBienEchangeRepository<BienEchangeBLL> bienEchangeService, IPaysRepository<PaysBLL> paysService)
        {
            _logger = logger;
            _httpContext = httpContext;
            _BienEchangeService = bienEchangeService;
            _PaysService = paysService;
        }

        //public IActionResult Index()
        //{
        //    _httpContext.HttpContext.Session.SetObjectAsJson("Titre", "Welcome");
        //    return View();
        //}

        public IActionResult Index()
        {
            _httpContext.HttpContext.Session.SetObjectAsJson("Titre", "Welcome");

            HomeIndex model = new HomeIndex();

            model.BiensEchanges = _BienEchangeService.Get().Select(c => c.ToListItem());
            model.BiensEchanges = model.BiensEchanges.Select(m => { m.Pays = _PaysService.Get((int)m.idPays).ToDetails(); return m; });
            return View(model);
        }
    }
}

//try
//{
//    IEnumerable<BienEchangeListItem> model2 = _BienEchangeService.Get().Select(c => c.ToListItem());
//    model2 = model2.Select(m => { m.Pays = _PaysService.Get((int)m.idPays).ToDetails(); return m; });
//    return View(model);
//}
//catch (Exception e)
//{
//    return Json(e);
//}
