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
        {
            string formato = "{0,-20}||$ {1,-20}||{2,-20}||{3,-20}||{4,-15}||{5,-20}||{6,-20}||{7,-20}||{8,-20}||{9,-20}";
            return String.Format(formato, licitacion.tipoDeObra, licitacion.presupuestoEstimado, licitacion.ubicacion, licitacion.fechaLimite, licitacion.estado, proveedor.nombre, proveedor.direccion, proveedor.email, fechaPresentacion, monto);
        }

    }
}
