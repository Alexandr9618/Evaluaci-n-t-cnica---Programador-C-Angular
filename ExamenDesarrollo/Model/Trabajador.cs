using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenDesarrollo.Model
{
    public class Trabajador
    {
        public string dni { get; set; }
        public int horasLaboradas { get; set; }
        public int diasLaborados { get; set; }
        public int faltas { get; set; }
        public int tipoTrabajador { get; set; }
        public double salarioNeto { get; set; }
        
    }
}
