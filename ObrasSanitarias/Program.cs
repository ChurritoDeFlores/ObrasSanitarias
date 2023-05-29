using ObrasSanitarias.BaseDeDatos;
using ObrasSanitarias.Controladores;
using ObrasSanitarias.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ControlMenu ctrlMenu = new ControlMenu();
            ctrlMenu.Menu();
            Console.ReadKey();

        }
    }
}
