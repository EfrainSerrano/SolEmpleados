using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusConcepto
    {
        DatConcepto oDatConcepto = new DatConcepto();
        public List<Conceptos> Obtener()
        {
            return oDatConcepto.Obtener();
        }

        public Conceptos Obtener(int id)
        {
            return oDatConcepto.Obtener(id);
        }

        public void Agregar(Conceptos oConceptos)
        {
            oDatConcepto.Agregar(oConceptos);
        }

        public void Editar(Conceptos oConceptos)
        {
            oDatConcepto.Editar(oConceptos);
        }

        public void Eliminar(int id)
        {
            oDatConcepto.Eliminar(id);
        }
    }
}
