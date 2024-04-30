using Microsoft.AspNetCore.Mvc;

using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {

        PacientesDatos _ContactoDatos = new PacientesDatos();

        public IActionResult Listar()
        {
       
            var oLista = _ContactoDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
    
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PacientesModel oContacto)
        {
           
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();
        }

        public IActionResult Editar(int IdContacto)
        {
            
            var ocontacto = _ContactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(PacientesModel oContacto)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int IdContacto)
        {
            
            var ocontacto = _ContactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(PacientesModel oContacto)
        {
  
            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
