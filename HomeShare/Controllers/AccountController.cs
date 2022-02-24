using HolidayRental.BLL.Entities;
using HolidayRental.Common.Repositories;
using HoliDayRental.Handlers;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HoliDayRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMembreRepository<MembreBLL> _MembreService;
        private readonly SessionManager _session;

        public AccountController(ILogger<AccountController> logger, IMembreRepository<MembreBLL> membreService, SessionManager session)
        {
            _logger = logger;
            _MembreService = membreService;
            this._session = session;
        }

        //private readonly IHttpContextAccessor _httpContext;

        //public AccountController(ILogger<AccountController> logger, IHttpContextAccessor httpContext)
        //{
        //    _logger = logger;
        //    _httpContext = httpContext;
        //}
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        //LOGIN & SESSION
        public IActionResult Login()
        {
            if (_session.IsConnected) return RedirectToAction("Index", "Home");
            return View();
        }

        ///// <summary>
        ///// Action récupérant le formulaire dans un model LoginForm, que j'ai créé moi-même, permet de travailler les donnée d'un formulaire.
        ///// ATTENTION : Signature doit être différente de l'affichage du formulaire, et être d'un HttpVerb différent, si l'affichage est en GET, la récupération est en POST 
        ///// (vérifier que la balise form contienne une méthode POST) : [HttpPost]
        ///// </summary>
        ///// <param name="formCollection"></param>
        ///// <returns></returns>
        [HttpPost]
        public IActionResult Register(ConnectionForm form)
        {
            //ValidateLoginForm(form, ModelState);
            if (!ModelState.IsValid) return View();
            //Création d'une méthode CheckPassword 
            int id = _MembreService.checkPassword(form.Login, form.Password);
            if (id == -1) return View();
            _session.User = _MembreService.Get(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        //Exemple d'ajout de valeur pour une session permettant de spécifier que l'utilisateur est connecté
        //[HttpPost]
        //public IActionResult Register()
        //{
        //    _httpContext.HttpContext.Session.SetObjectAsJson("IsLogged", true);
        //    return View();
        //}



        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
