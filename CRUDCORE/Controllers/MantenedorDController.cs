using Microsoft.AspNetCore.Mvc;

using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorDController : Controller
    {

        DoctoresDatos _DoctoresDatos = new DoctoresDatos();

        public IActionResult ListarD()
        {
            
            var oLista = _DoctoresDatos.ListarD();

            return View(oLista);
        }

        public IActionResult GuardarD()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult GuardarD(DoctoresModel oDoctores)
        {
         
            if (!ModelState.IsValid)
                return View();


            var respuesta = _DoctoresDatos.GuardarD(oDoctores);

            if (respuesta)
                return RedirectToAction("ListarD");
            else 
                return View();
        }

        public IActionResult EditarD(int Id)
        {
            
            var oDoctores = _DoctoresDatos.ObtenerD(Id);
            return View(oDoctores);
        }

        [HttpPost]
        public IActionResult EditarD(DoctoresModel oDoctores)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _DoctoresDatos.EditarD(oDoctores);

            if (respuesta)
                return RedirectToAction("ListarD");
            else
                return View();
        }


        public IActionResult EliminarD(int Id)
        {
          
            var oDoctores = _DoctoresDatos.ObtenerD(Id);
            return View(oDoctores);
        }

        [HttpPost]
        public IActionResult EliminarD(DoctoresModel oDoctores)
        {
  
            var respuesta = _DoctoresDatos.EliminarD(oDoctores.Id);

            if (respuesta)
                return RedirectToAction("ListarD");
            else
                return View();
        }

    }
}
