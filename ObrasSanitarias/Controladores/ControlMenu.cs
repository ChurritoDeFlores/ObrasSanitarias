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
                Console.WriteLine("2- Proveedores.");
                Console.WriteLine("3- Propuestas");
                Console.WriteLine("0- Salir.");
                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    default: { Console.WriteLine("Opcion incorrecta"); Console.ReadKey(); } break;
                    case 0: { salir = false; }break;
                    case 1: { MenuLicitaciones(); }break;
                    case 2: { MenuProveedores(); }break;
                    case 3: { MenuPropuestas(); } break;

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
                Console.WriteLine("3- Eliminar Licitacion.");
                Console.WriteLine("4- Modificar Licitacion. (Tipo de obra)");
                Console.WriteLine("0- Salir.");
                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    default: { Console.WriteLine("Opcion incorrecta"); Console.ReadKey(); } break;
                    case 0: { salir = false; } break;
                    case 1: { ctrlLicitaciones.Agregar(); } break;
                    case 2: { ctrlLicitaciones.Imprimir(); } break;
                    case 3: { ctrlLicitaciones.Eliminar(); } break;
                    case 4: { ctrlLicitaciones.EditarObra(); } break;

                }
            } while (salir == true);
        }
        private void MenuProveedores()
        {
            Console.Clear();
            ControlProveedores ctrlProveedores = new ControlProveedores();
            bool salir = true;
            do
            {
                Console.WriteLine("## Proveedores ##");
                Console.WriteLine("1- Agregar Proveedor.");
                Console.WriteLine("2- Mostrar Proveedores.");
                Console.WriteLine("3- Eliminar Proveedor.");
                Console.WriteLine("4- Modificar Proveedor. (Nombre)");
                Console.WriteLine("0- Salir.");
                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    default: { Console.WriteLine("Opcion incorrecta"); Console.ReadKey(); } break;
                    case 0: { salir = false; } break;
                    case 1: { ctrlProveedores.Agregar(); } break;
                    case 2: { ctrlProveedores.Imprimir(); } break;
                    case 3: { ctrlProveedores.Eliminar(); } break;
                    case 4: { ctrlProveedores.EditarNombre(); } break;

                }
            } while (salir == true);
        }
        private void MenuPropuestas()
        {
            Console.Clear();
            ControlPropuestas ctrlPropuestas = new ControlPropuestas();
            bool salir = true;
            do
            {
                Console.WriteLine("## Propuestas ##");
                Console.WriteLine("1- Agregar Propuesta.");
                Console.WriteLine("2- Mostrar Propuestas.");
                Console.WriteLine("3- Eliminar Propuesta.");
                Console.WriteLine("0- Salir.");
                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    default: { Console.WriteLine("Opcion incorrecta"); Console.ReadKey(); } break;
                    case 0: { salir = false; } break;
                    case 1: { ctrlPropuestas.Agregar(); } break;
                    case 2: { ctrlPropuestas.Imprimir(); } break;
                    case 3: { ctrlPropuestas.Eliminar(); } break;

                }
            } while (salir == true);
        }
    }
}
