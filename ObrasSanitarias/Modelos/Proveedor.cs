using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias.Modelos
{
    internal class Proveedor
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set;}
        public string email { get; set;}
        public Proveedor() { }
        public Proveedor(int iD, string nombre, string direccion, string email)
        {
            ID = iD;
            this.nombre = nombre;
            this.direccion = direccion;
            this.email = email;
        }
        public Proveedor(string nombre, string direccion, string email)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.email = email;
        }

        public override string ToString()
        {
            return String.Format("{0,-6}||{1,-30}||{2,-30}||{3,-30}", ID, nombre, direccion, email);
        }
    }
}
