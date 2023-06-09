using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias.Modelos
{
    internal class Licitacion
    {
        public int ID { get; set; }
        public string tipoDeObra { get; set; }
        public double presupuestoEstimado { get; set; }
        public string ubicacion { get; set; }
        public string fechaLimite { get; set; }
        public string estado { get; set; }
        public Licitacion() { }
        public Licitacion(int iD, string tipoDeObra, double presupuestoEstimado, string ubicacion, string fechaLimite, string estado)
        {
            ID = iD;
            this.tipoDeObra = tipoDeObra;
            this.presupuestoEstimado = presupuestoEstimado;
            this.ubicacion = ubicacion;
            this.fechaLimite = fechaLimite;
            this.estado = estado;
        }
        public Licitacion(string tipoDeObra, double presupuestoEstimado, string ubicacion, string fechaLimite, string estado)
        {
            this.tipoDeObra = tipoDeObra;
            this.presupuestoEstimado = presupuestoEstimado;
            this.ubicacion = ubicacion;
            this.fechaLimite = fechaLimite;
            this.estado = estado;
        }
        public override string ToString()
        {
            return String.Format("||{0,6}||{1,30}||$ {2,20}||{3,20}||{4,15}||{5,10}||", ID, tipoDeObra, presupuestoEstimado, ubicacion, fechaLimite, estado);
        }
    }
}
