using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias.Controladores
{
    internal class ControlTipeo
    {
        public string NoVacio(string cadena)
        {
            while (cadena == "" || cadena == null)
            {
                Console.WriteLine("No ingreso dato, por favor intente nuevamente.");
                cadena = Console.ReadLine();
            }
            return cadena;
        }
    }
}
