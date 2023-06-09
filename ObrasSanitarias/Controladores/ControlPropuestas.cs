using ObrasSanitarias.BaseDeDatos;
using ObrasSanitarias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObrasSanitarias.Controladores
{
    internal class ControlPropuestas
    {
        Propuestas propuestas = new Propuestas();
        public void Agregar()
        {
            Console.Clear();

            ControlLicitaciones ctrlLicitaciones = new ControlLicitaciones();
            Console.WriteLine("Licitaciones:");
            ctrlLicitaciones.Imprimir();
            Console.Write("Ingrese el ID de la licitacion para la propuesta: ");
            int idLicitacion = Convert.ToInt32(Console.ReadLine());
            ControlProveedores ctrlProveedores = new ControlProveedores();
            Console.WriteLine("Proveedores:");
            ctrlProveedores.Imprimir();
            Console.Write("Ingrese el ID del proveedor para la propuesta: ");
            int idProveedor = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese fecha de presentacion de propuesta: ");
            string fechaPresentacion = Console.ReadLine();
            Console.Write("Ingrese monto de propuesta: ");
            double monto = Convert.ToDouble(Console.ReadLine());
            propuestas.Agregar(idLicitacion,idProveedor,fechaPresentacion,monto);
        }
        public void Imprimir()
        {
            Console.Clear();
            Impresion imprimir = new Impresion();
            Console.WriteLine(imprimir.GenerarImpresion(propuestas.Listar()));
        }
    }
}
