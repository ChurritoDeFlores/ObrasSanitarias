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
        ControlTipeo ctrlTipeo = new ControlTipeo();
        public void Agregar()
        {
            Console.Clear();

            ControlLicitaciones ctrlLicitaciones = new ControlLicitaciones();
            Console.WriteLine("Licitaciones:");
            ctrlLicitaciones.Imprimir();
            Console.Write("Ingrese el ID de la licitacion para la propuesta: ");
            int idLicitacion = ctrlTipeo.ControlID(ctrlTipeo.SoloNumeros(Console.ReadLine()),ctrlLicitaciones.IDs());
            ControlProveedores ctrlProveedores = new ControlProveedores();
            Console.WriteLine("Proveedores:");
            ctrlProveedores.Imprimir();
            Console.Write("Ingrese el ID del proveedor para la propuesta: ");
            int idProveedor = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese fecha de presentacion de propuesta: ");
            string fechaPresentacion = ctrlTipeo.NoVacio(Console.ReadLine());
            Console.Write("Ingrese monto de propuesta: ");
            double monto = Convert.ToDouble(ctrlTipeo.NoVacio(Console.ReadLine()));
            propuestas.Agregar(idLicitacion,idProveedor,fechaPresentacion,monto);
        }
        public void Eliminar()
        {
            Console.Clear();
            Imprimir();
            Console.WriteLine("################################################");
            Console.Write("Ingrese el ID de la propuesta a borrar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            propuestas.Eliminar(id);
        }
        public void Imprimir()
        {
            Console.Clear();
            Impresion imprimir = new Impresion();
            Console.WriteLine(imprimir.GenerarImpresion(propuestas.Listar()));
        }
    }
}
