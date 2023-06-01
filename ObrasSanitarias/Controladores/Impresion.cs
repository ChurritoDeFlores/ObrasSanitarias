using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias.Controladores
{
    internal class Impresion
    {
        public string GenerarImpresion<T>(List<T> lista)
        {
            StringBuilder listaString = new StringBuilder();
            foreach (var item in lista)
            {
                listaString.AppendLine(item.ToString());
            }
            return listaString.ToString();
        }
        public string GenerarImpresionConID<T>(List<T>lista)
        {
            StringBuilder listaString = new StringBuilder();
            foreach (var item in lista)
            {
                listaString.AppendLine(item.ToStringConID());
            }
            return listaString.ToString();
        }
    }
}
