using ObrasSanitarias.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias.Modelos
{
    internal class Propuesta
    {
        public int ID { get; set; }
        public string fechaPresentacion { get; set; }
        public double monto { get; set; }
        public Licitacion licitacion { get; set; }
        public Proveedor proveedor { get; set; }

        public Propuesta() { }

        public Propuesta(int id, string fechaPresentacion, double monto,Licitacion licitacion) 
        {
            this.ID = id;
            this.fechaPresentacion = fechaPresentacion;
            this.monto = monto;
            this.licitacion = licitacion;
        }
        public Propuesta(int id, string fechaPresentacion, double monto, Licitacion licitacion, Proveedor proveedor)
        {
            this.ID = id;
            this.fechaPresentacion = fechaPresentacion;
            this.monto = monto;
            this.licitacion = licitacion;
            this.proveedor = proveedor;
        }
        public Propuesta(string fechaPresentacion, double monto, Licitacion licitacion)
        {
            this.fechaPresentacion = fechaPresentacion;
            this.monto = monto;
            this.licitacion = licitacion;
            this.proveedor = proveedor;
        }
        public Propuesta(string fechaPresentacion, double monto, Licitacion licitacion, Proveedor proveedor)
        {
            this.fechaPresentacion = fechaPresentacion;
            this.monto = monto;
            this.licitacion = licitacion;
            this.proveedor = proveedor;
        }
        public override string ToString()
        {   //   ═  ║ ╔  ╗  ╝ ╚       <---- Caracteres para hacer el marco
            string formato =    "╔═════════════════════════════════════════╗\n" +
                                "║ID: {0,37}║\n" +
                                "║Licitacion:                              ║\n" +
                                "║\tTipo de obra: {1,20}║\n" +
                                "║\tPresupuesto estimado:$ {2,11}║\n" +
                                "║\tUbicacion: {3,23}║\n" +
                                "║\tFecha limite: {4,20}║\n" +
                                "║\tEstado: {5,26}║\n" +
                                "║Proveedor:                               ║\n" +
                                "║\tNombre: {6,26}║\n" +
                                "║\tDireccion: {7,23}║\n" +
                                "║\tEmail: {8,27}║\n" +
                                "║Propuesta:                               ║\n" +
                                "║\tFecha de presentacion: {9,11}║\n" +
                                "║\tMonto:$ {10,26}║\n" +
                                "╚═════════════════════════════════════════╝\n";

            return String.Format(formato,ID, licitacion.tipoDeObra, licitacion.presupuestoEstimado, licitacion.ubicacion, licitacion.fechaLimite, licitacion.estado, proveedor.nombre, proveedor.direccion, proveedor.email, fechaPresentacion, monto);
        }

    }
}
