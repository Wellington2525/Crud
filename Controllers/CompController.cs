using CRUD_1.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_1.Controllers
{
    public class CompController : Controller
    {
        // GET: Comp
        crudEmpleadoEntities dbobj = new crudEmpleadoEntities();
        public ActionResult Comp(comp obj)
        {
            return View(obj);
        }

        [HttpPost]
        public ActionResult AddEmpleado(comp model)
        {
            if (ModelState.IsValid)
            {
                comp obj = new comp();
                obj.idcomp = model.idcomp;
                obj.nombre = model.nombre;
              

                if (model.idcomp == 0)
                {
                    dbobj.comp.Add(obj);
                    dbobj.SaveChanges();
                }
                else
                {
                    dbobj.Entry(obj).State = EntityState.Modified;
                    dbobj.SaveChanges();
                }
                ModelState.Clear();

            }

            return View("Comp");
        }

        public ActionResult CompList()
        {
            //var vist = dbobj.empleado.ToList();
            var vist = dbobj.comp.ToList();
            return View(vist);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var ress = dbobj.comp.Where(x => x.idcomp == id).First();
            dbobj.comp.Remove(ress);
            dbobj.SaveChanges();

            var list = dbobj.comp.ToList();
            return View("CompList", list);
        }


    }
}