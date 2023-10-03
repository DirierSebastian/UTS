using Microsoft.AspNetCore.Mvc;
using UTS.Datos;
using UTS.Models;

namespace UTS.Controllers
{
    public class ConsultaAulasController : Controller
    {
        ConsultaAulasDatos _consultaaulaDatos = new ConsultaAulasDatos();
        public IActionResult Listar()
        {
            var lista = _consultaaulaDatos.Listar();
            return View(lista);
        }

    }
}
