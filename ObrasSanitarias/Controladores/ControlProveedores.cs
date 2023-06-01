using Microsoft.SqlServer.Server;
using ObrasSanitarias.BaseDeDatos;
using ObrasSanitarias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias.Controladores
{
    internal class ControlProveedores : IDisposable
    {
        ControlTipeo ctrlTipeo = new ControlTipeo();
        Proveedores proveedores = new Proveedores();
        public void Agregar()
        {
            Console.Clear();
            Console.WriteLine("### Nuevo Proveedor ###");
            Console.Write("Ingrese nombre del proveedor: ");
            string nombre = ctrlTipeo.NoVacio(Console.ReadLine());
            Console.Write("Ingrese direccion del proveedor: ");
            string direccion = ctrlTipeo.NoVacio(Console.ReadLine());
            Console.Write("Ingrese email del provvedor: ");
            string email = ctrlTipeo.NoVacio(Console.ReadLine());
            Proveedor proveedor = new Proveedor
            {
                nombre = nombre,
                direccion = direccion,
                email = email
            };
            if (!proveedores.Existe(proveedor))
            {
                proveedores.Agregar(proveedor);
                Console.Clear();
                Console.WriteLine("Proveedor Agregado");
            }  
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Imprimir()
        {
            Console.Clear();
            Impresion imprimir = new Impresion();
            Console.WriteLine(String.Format("{0,-30}||{1,-30}||{2,-30}", "Nombre", "Direccion", "Email"));
            Console.WriteLine(imprimir.GenerarImpresion(proveedores.Listar()));
        }

        public void ImprimirConID()
        {
            Console.Clear();
            Impresion imprimir = new Impresion();
            Console.WriteLine(String.Format("{0,-6}||{1,-30}||{2,-30}||{3,-30}", "ID", "Nombre", "Direccion", "Email"));
            Console.WriteLine(imprimir.GenerarImpresion(proveedores.ListarConID()));
        }
    }
}
