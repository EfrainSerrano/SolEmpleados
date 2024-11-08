using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusNomina
    {
        DatNomina oDatNomina = new DatNomina();

        public List<Nomina> Obtener()
        {
            return oDatNomina.Obtener();
        }

        public List<Nomina> ObtenerNominasEmpleado(int idEmpleado)
        {
            return oDatNomina.ObtenerNominasEmpleado(idEmpleado);
        }

        public Nomina Obtener(int id)
        {
            return oDatNomina.Obtener(id);
        }

        public void Agregar(Nomina oNomina)
        {
            oDatNomina.Agregar(oNomina);
        }

        public void Editar(Nomina oNomina)
        {
            oDatNomina.Editar(oNomina);
        }

        public void Eliminar(int id)
        {
            oDatNomina.Eliminar(id);
        }

    }
}
