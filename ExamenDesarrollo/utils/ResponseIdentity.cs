using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenDesarrollo.utils
{
    public class ResponseIdentity<T>
    {
        public bool estado 
        {
            get
            {
                return data != null;
            }
        }

        public T data { get; set; }
        public string mensaje { get; set; }
    }
}
