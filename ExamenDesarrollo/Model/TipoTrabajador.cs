using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenDesarrollo.Model
{
    public class TipoTrabajador
    {
        public int tipoTrabajador { get; set; }
        public double costoHora { get; set; }
        public double penalidadFalta { get; set; }
        public double bonificacion { get; set; }
        public int impuesto { get; set; }
        public double CalcularSalario(Trabajador t)
        {
            return (((t.horasLaboradas * costoHora) - (t.faltas * penalidadFalta)) + bonificacion) * (100 - impuesto);
        }
    }
}
