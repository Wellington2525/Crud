using CRUD_1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_1.Datos
{
    public class CompL
    {
        public List<comp> Consulta()
        {
            using (crudEmpleadoEntities obj = new crudEmpleadoEntities())
            {
                return obj.comp.AsNoTracking().ToList();
            }
        }
    }
}