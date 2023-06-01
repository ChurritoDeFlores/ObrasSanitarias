using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias.Interfaces
{
    internal interface IAgregarListar<T>
    {
        void Agregar(T t);
        List<T> Listar();
    }
}
