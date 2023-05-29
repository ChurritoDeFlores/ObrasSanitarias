using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias.Controladores
{
    internal class ControlMenu
    {
        public void Menu()
        {
            bool salir = true;
            do
            {
                Console.Clear();
                Console.WriteLine("## Obras Sanitarias ##");
                Console.WriteLine("1- Licitaciones.");
                Console.WriteLine("0- Salir.");
                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    default: { Console.WriteLine("Opcion incorrecta"); Console.ReadKey(); } break;
                    case 0: { salir = false; }break;
                    case 1: { MenuLicitaciones(); }break;

                }


            }while (salir == true);
        }
        private void MenuLicitaciones()
        {   
            Console.Clear();
            ControlLicitaciones ctrlLicitaciones = new ControlLicitaciones();
            bool salir = true;
            do
            {
                Console.WriteLine("## Licitaciones ##");
                Console.WriteLine("1- Agregar Licitacion.");
                Console.WriteLine("2- Mostrar Licitaciones.");
                Console.WriteLine("0- Salir.");
                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    default: { Console.WriteLine("Opcion incorrecta"); Console.ReadKey(); } break;
                    case 0: { salir = false; } break;
                    case 1: { ctrlLicitaciones.Agregar(); } break;
                    case 2: { ctrlLicitaciones.Imprimir(); } break;

                }


            } while (salir == true);
        }
    }
}
