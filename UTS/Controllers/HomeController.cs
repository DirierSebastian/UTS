using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using UTS.Models;

namespace UTS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //Acion para cerrarSesion
        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "LoginUsuario");
        }

        public IActionResult index()
        {
            return View();
        }
        public IActionResult indexlogin()
        {
            return View();
        }
        public IActionResult indexrecordar()
        {
            return View();
        }
        public IActionResult indexinicio()
        {
            return View();
        }
        public IActionResult indexedificio1()
        {
            return View();
        }
        public IActionResult indexedificio2()
        {
            return View();
        }
        public IActionResult indexedificio3()
        {
            return View();
        }
        public IActionResult indexedificio4()
        {
            return View();
        }
        public IActionResult indexedificioH()
        {
            return View();
        }
        public IActionResult index1101()
        {
            return View();
        }
        public IActionResult index1102()
        {
            return View();
        }
        public IActionResult index1103()
        {
            return View();
        }
        public IActionResult index1201()
        {
            return View();
        }
        public IActionResult index1202()
        {
            return View();
        }
        public IActionResult index1203()
        {
            return View();
        }
        public IActionResult indexlabe1()
        {
            return View();
        }
        public IActionResult index2101()
        {
            return View();
        }
        public IActionResult index2102()
        {
            return View();
        }
        public IActionResult index2103()
        {
            return View();
        }
        public IActionResult index2201()
        {
            return View();
        }
        public IActionResult index2202()
        {
            return View();
        }
        public IActionResult index2203()
        {
            return View();
        }
        public IActionResult indexlabcis()
        {
            return View();
        }
        public IActionResult indexlabmic()
        {
            return View();
        }
        public IActionResult index3101()
        {
            return View();
        }
        public IActionResult index3102()
        {
            return View();
        }
        public IActionResult index3103()
        {
            return View();
        }
        public IActionResult index3201()
        {
            return View();
        }
        public IActionResult index3202()
        {
            return View();
        }
        public IActionResult index3203()
        {
            return View();
        }
        public IActionResult indexlabe3()
        {
            return View();
        }
        public IActionResult index4101()
        {
            return View();
        }
        public IActionResult index4102()
        {
            return View();
        }
        public IActionResult index4103()
        {
            return View();
        }
        public IActionResult index4201()
        {
            return View();
        }
        public IActionResult index4202()
        {
            return View();
        }
        public IActionResult index4203()
        {
            return View();
        }
        public IActionResult indexlabe4()
        {
            return View();
        }
        public IActionResult indexH101()
        {
            return View();
        }
        public IActionResult indexH102()
        {
            return View();
        }
        public IActionResult indexH103()
        {
            return View();
        }
        public IActionResult indexH201()
        {
            return View();
        }
        public IActionResult indexH202()
        {
            return View();
        }
        public IActionResult indexH203()
        {
            return View();
        }
        public IActionResult indexlabeH()
        {
            return View();
        }
        public IActionResult indexmagna()
        {
            return View();
        }
        public IActionResult indexjuntas()
        {
            return View();
        }
        public IActionResult indexauditorio()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}