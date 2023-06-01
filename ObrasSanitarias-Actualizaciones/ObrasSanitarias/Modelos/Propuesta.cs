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

    }
}
