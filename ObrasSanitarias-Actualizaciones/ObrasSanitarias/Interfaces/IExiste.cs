using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias.Interfaces
{
    internal interface IExiste <T>
    {
        bool Existe(T t);

    }
}
