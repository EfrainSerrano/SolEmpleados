using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Business
{
    public class BusEmpleados
    {
        DatEmpleados oDatEmpleados = new DatEmpleados();

        public List<Empleados> Obtener(int idUsuario)
        {
           return oDatEmpleados.Obtener(idUsuario);
        }

        public Empleados ObtenerPorId(int idEmpleado)
        {
            return oDatEmpleados.ObtenerPorId(idEmpleado);
        }

        public void Agregar(Empleados oEmpleado)
        {
            oDatEmpleados.agregar(oEmpleado);
        }

        public void Editar(Empleados oEmpleados)
        {
            oDatEmpleados.Editar(oEmpleados);
        }

        public void Eliminar(int id)
        {
            oDatEmpleados.Eliminar(id);
        }
    }
}
