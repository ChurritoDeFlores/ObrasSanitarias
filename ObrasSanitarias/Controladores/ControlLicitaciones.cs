using ObrasSanitarias.BaseDeDatos;
using ObrasSanitarias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias.Controladores
{
    internal class ControlLicitaciones
    {
        Licitaciones licitaciones = new Licitaciones();
        ControlTipeo ctrlTipeo = new ControlTipeo();
        public void Agregar()
        {
            Console.Clear();
            Console.WriteLine("### Nueva licitacion ###");
            Console.Write("Ingrese el tipo de obra: ");
            string tipoDeObra = ctrlTipeo.NoVacio(Console.ReadLine());
            Console.Write("Ingrese el presupuesto estimado: ");
            double presupuestoEstimado = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese la ubicacion de la obra: ");
            string ubicacion = ctrlTipeo.NoVacio(Console.ReadLine());
            Console.Write("Ingrese la fecha limite de licitacion: ");
            string fechaLimite = ctrlTipeo.NoVacio(Console.ReadLine());
            Console.WriteLine("Seleccione el estado de la licitacion:");
            Console.WriteLine("(1- Abierta/ 2- Cerrada/ 3- Adjudicada)");
            int op = Convert.ToInt32(Console.ReadLine());
            string estado = "Abierta"; // Por defecto
            switch(op)
            {
                    case 1: { estado = "Abierta"; }break;
                    case 2: { estado = "Cerrada"; }break;
                    case 3: { estado = "Adjudicada"; }break;
            }
            Licitacion licitacion = new Licitacion
            {
                tipoDeObra = tipoDeObra,
                presupuestoEstimado = presupuestoEstimado,
                ubicacion = ubicacion,
                fechaLimite = fechaLimite,
                estado = estado
            };
            licitaciones.Agregar(licitacion);
        }
        public void EditarObra()
        {
            Console.Clear();
            Imprimir();
            Console.WriteLine("################################################");
            Console.Write("Ingrese el ID de la licitacion a modificar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el tipo de obra de licitacion: ");
            string obra = Console.ReadLine();
            licitaciones.EditarObra(id, obra);
            Console.ReadKey();
        }
        public void Eliminar()
        {
            Console.Clear();
            Imprimir();
            Console.WriteLine("################################################");
            Console.Write("Ingrese el ID de la licitacion a borrar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            licitaciones.Eliminar(id);
      
        }
        

        public void Imprimir()
        {
            Console.Clear();
            Impresion imprimir = new Impresion();
            Console.WriteLine(String.Format("||{0,-6}||{1,-30}||{2,-22}||{3,-20}||{4,-15}||{5,-10}||", "ID", "Tipo de Obra", "Presupuesto Estimado", "Ubicacion", "Fecha Limite", "Estado"));
            Console.WriteLine(imprimir.GenerarImpresion(licitaciones.Listar()));
        }
        public List<int> IDs()
        {
            return licitaciones.IDs();
        }
        
    }
}
