using CRUD_1.Context;
using CRUD_1.Models;
using CRUD_1.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_1.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        private IEnumerable<SelectListItem> ListComp;
        crudEmpleadoEntities dbobj = new crudEmpleadoEntities();
        public ActionResult Empleado(empleado obj)
        {
               LlenarComb();


                return View(obj);

           
           
        }

        private void LlenarComb()
        {
            ListComp = new CompL().Consulta().ToList().Select(p => new SelectListItem { Value = p.idcomp.ToString(), Text = p.nombre}); ;
        }

        [HttpPost]
        public ActionResult AddEmpleado( empleado model)
        {
            if (ModelState.IsValid)
            {
                empleado obj = new empleado();
                obj.idEmp = model.idEmp;
                obj.nombre = model.nombre;
                obj.apellido = model.apellido;
                obj.telefono = model.telefono;
                obj.direccion = model.direccion;
                obj.idcomp = model.idcomp;

                if(model.idEmp == 0)
                {
                    dbobj.empleado.Add(obj);
                    dbobj.SaveChanges();
                }
                else
                {
                    dbobj.Entry(obj).State = EntityState.Modified;
                    dbobj.SaveChanges();
                }
                ModelState.Clear();

            }
            
            return View("Empleado");
        }

        public ActionResult EmpleadoList()
        {
            //var vist = dbobj.empleado.ToList();
            var vist = dbobj.VistaEmpleado.ToList();
            return View(vist);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var res = dbobj.empleado.Where(x => x.idEmp == id).First();
            dbobj.empleado.Remove(res);
            dbobj.SaveChanges();

            var list = dbobj.VistaEmpleado.ToList();
            return View("EmpleadoList", list);
        }

      

       /* public ActionResult Combox()
        {
            List<comp> list = null;
            using (crudEmpleadoEntities obj = new crudEmpleadoEntities())
            {
                list =
                    (from d in obj.comp
                     select new comp
                     {
                         idcomp = d.idcomp,
                         nombre = d.nombre

                     }).ToList();

                   
            }
            List<SelectListItem> items = list.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.idcomp.ToString(),
                    Selected = false

                };
            });

            ViewBag.items = items;
           return View();
        }*/
    }
}