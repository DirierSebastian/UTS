using Microsoft.AspNetCore.Mvc;
using UTS.Datos;
using UTS.Models;

namespace UTS.Controllers
{
    public class ConsultaHorarioController : Controller
    {
        ConsultaHorariosDatos _consultaHorariosDatos = new ConsultaHorariosDatos();
        public IActionResult Listar()
        {
            var lista = _consultaHorariosDatos.Listar();
            return View(lista);
        }



    }
}
