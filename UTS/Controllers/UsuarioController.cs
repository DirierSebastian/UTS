using Microsoft.AspNetCore.Mvc;
using UTS.Datos;
using UTS.Models;

namespace UTS.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioDatos _usuarioDatos = new UsuarioDatos();
        public IActionResult Listar()
        {
            var lista = _usuarioDatos.Listar();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Insertar() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insertar(UsuarioModel model) 
        { 
            var respuesta = _usuarioDatos.GuardarUsuario(model);
            if(respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int clave_empleado)
        {
            UsuarioModel _usuario = _usuarioDatos.ObtenerUsuario(clave_empleado);
            return View(_usuario);
        }
        [HttpPost]
        public IActionResult Editar(UsuarioModel model)
        {
            var respuesta = _usuarioDatos.EditarUsuario(model);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int clave_empleado)
        {
            var _contacto = _usuarioDatos.ObtenerUsuario(clave_empleado);
            return View(_contacto); 
        }
        [HttpPost]
        public IActionResult Eliminar(UsuarioModel model)
        {
            var respuesta = _usuarioDatos.EliminarUsuario(model.clave_empleado);
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
