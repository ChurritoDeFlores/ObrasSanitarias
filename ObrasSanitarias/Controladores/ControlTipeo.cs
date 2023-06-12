using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
        public int ControlID(int var, List<int>ids)
        {
            while (!ids.Contains(var))
            {
                Console.WriteLine("El id ingresado no es valido, ingrese nuevamente:");
                var = SoloNumeros(NoVacio(Console.ReadLine()));
            }
            return var;
        }
        public int SoloNumeros(string cadena)
        {
            string patron = @"^[0-9]+$";
            do
            {
                Console.WriteLine("Solo debe ingresar numeros, intente nuevamente.");
                cadena = Console.ReadLine();
            } while (!Regex.IsMatch(cadena,patron));
            
            return Convert.ToInt32(cadena);
        }
    }
}
