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
            int idLicitacion = 0;
            int idProveedor = 0;
            using (ControlLicitaciones ctrlLicitaciones = new ControlLicitaciones())
            {
                Console.WriteLine("Licitaciones:");
                ctrlLicitaciones.ImprimirConID();
                Console.Write("Ingrese el ID de la licitacion para la propuesta: ");
                idLicitacion = Convert.ToInt32(Console.ReadLine());
            }
            using (ControlProveedores ctrlProveedores = new ControlProveedores())
            {
                Console.WriteLine("Proveedores:");
                ctrlProveedores.ImprimirConID();
                Console.Write("Ingrese el ID del proveedor para la propuesta: ");
                idProveedor = Convert.ToInt32(Console.ReadLine());
            }
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
            Console.WriteLine(String.Format("{0,-20}||$ {1,-20}||{2,-20}||{3,-20}||{4,-15}||{5,-20}||{6,-20}||{7,-20}||{8,-20}||{9,-20}", "Tipo de Obra", "Presupuesto estimado","Ubicacion", "Fecha limite", "Estado", "Nombre", "Direccion", "Email", "Fecha Presentacion", "Monto"));
            Console.WriteLine(imprimir.GenerarImpresion(propuestas.Listar()));
        }
    }
}
