using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using UTS.Datos;
using UTS.Models;

namespace UTS.Controllers
{
    public class HorariosController : Controller
    {
        HorarioDatos _horarioDatos = new HorarioDatos();
        InstalacionDatos _instalacionDatos = new InstalacionDatos();
        UsuarioDatos _usuarioDatos = new UsuarioDatos();
        public IActionResult Listar()
        {
            var lista = _horarioDatos.Listar();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Insertar()
        {
            List <InstalacionModel> lista = _instalacionDatos.Lista();
            List<SelectListItem> listaI = lista.ConvertAll(
                item => new SelectListItem()
                {
                    Text = item.nombre.ToString(),
                    Value = item.idaula.ToString(),
                    Selected = false
                });
            ViewBag.Lista = listaI;
            return View();
        }

        [HttpPost]
        public IActionResult Insertar(HorarioModel model)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Listar");
            }
            bool respuesta = _horarioDatos.InsertarApartado(model);
            if(respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int idhorario)
        {
            var _horario = _horarioDatos.ConsultarHorario(idhorario);
            return View(_horario);
        }
        [HttpPost]
        public IActionResult Eliminar(HorarioModel model)
        {
            var respuesta = _horarioDatos.EliminarHorario(model.idhorario);
            if(respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int idhorario)
        {            List<InstalacionModel> lista = _instalacionDatos.Lista();
            List<SelectListItem> listaI = lista.ConvertAll(     
                item => new SelectListItem()
                {
                    Text = item.nombre.ToString(),
                    Value = item.idaula.ToString(),
                    Selected = false
                });
            ViewBag.Lista = listaI;

            HorarioModel _contacto = _horarioDatos.ConsultarHorario(idhorario);
            return View(_contacto);
        }
        [HttpPost]
        
        public IActionResult Editar(HorarioModel model)
        {
            if(ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _horarioDatos.EditarApartado(model);
            if(respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }



    }



}
