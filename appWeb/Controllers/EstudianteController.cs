using Modelo;
using Servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appWeb.Controllers
{
    public class EstudianteController : Controller
    {
        private IEstudianteService _serviceEst;

        public EstudianteController(IEstudianteService serviceEst)
        {
            _serviceEst = serviceEst;
        }

        // GET: Estudiante
        [HttpGet]
        public ActionResult Index()
        {
            var estudiantes = _serviceEst.GetAllEstudiante();
            return View(estudiantes);
        }

        [HttpGet]
        public ActionResult Crud(int id=0)
        {
            EstudianteModelo model = new EstudianteModelo();
          /*  if (id.HasValue)
            {
                model = _serviceEst.GetByIdEstudiante(id.Value);
            }
            */
            return View(id == 0 ? new EstudianteModelo() : _serviceEst.GetByIdEstudiante(id));
        }

        [HttpPost]
        public ActionResult Crud(int? id, EstudianteModelo model)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0) id = null;
                    bool isNew = !id.HasValue;
                    _serviceEst.AddEdditEstudiante(isNew, model);
                    result = true;
                    msg = "Dato guardado";
                }
                else
                {
                    result = false;
                    msg = "Ha ocurrido un error";
                }

                
            } catch (Exception ex)
            {
                result = false;
                throw ex;
                
            }

            // return RedirectToAction("Index");
            return Json(new { response = result, message= msg, href = "~/Estudiante" },JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DeleteEstudiante(int id)
        {
            EstudianteModelo modelo = new EstudianteModelo();
            modelo = _serviceEst.GetByIdEstudiante(id);
            modelo.NombreCompleto = $"{modelo.PrimerNombre} {modelo.PrimerApellido}";
            modelo.Id = id;
            return View(modelo);


            
        }

        [HttpPost]
        public ActionResult DeleteEstudiante(int id, FormCollection form)
        {

            _serviceEst.DeleteEstudiante(id);
            return Json(new { response = true, message="Registro borrado", href = "~/Estudiante" }, JsonRequestBehavior.AllowGet);
        }
    }
}