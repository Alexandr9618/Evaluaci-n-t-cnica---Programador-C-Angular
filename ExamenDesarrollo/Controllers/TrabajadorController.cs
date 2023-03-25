using CsvHelper;
using CsvHelper.Configuration;
using ExamenDesarrollo.Data;
using ExamenDesarrollo.Model;
using ExamenDesarrollo.utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenDesarrollo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class TrabajadorController : Controller
    {
        private readonly BD_Desarrollo bd = new BD_Desarrollo();
        private readonly List<Trabajador> trabajadores = new List<Trabajador>();
        public readonly List<TipoTrabajador> tipoTrabajador = new List<TipoTrabajador>();
        public TrabajadorController()
        {
            trabajadores= bd.cargaDatosCSV();


            tipoTrabajador.Add(new TipoTrabajador() { tipoTrabajador = 0, costoHora = 15, penalidadFalta = 120.0, bonificacion = 130, impuesto = 12 });
            tipoTrabajador.Add(new TipoTrabajador() { tipoTrabajador = 1, costoHora = 35, penalidadFalta = 280, bonificacion = 200, impuesto = 16 });
            tipoTrabajador.Add(new TipoTrabajador() { tipoTrabajador = 2, costoHora = 85, penalidadFalta = 680, bonificacion = 350, impuesto = 18 });
        }

        

        [HttpGet("tipo/{idTipo}")]
        public ResponseIdentity<List<Trabajador>> obtenerDetalle(int idTipo)
        {
            try
            {                
                var tipo = tipoTrabajador.FirstOrDefault(t => t.tipoTrabajador == idTipo);
                var data = trabajadores.Where(t => t.tipoTrabajador == idTipo).ToList();

                data = data.Select(t => { t.salarioNeto = tipo.CalcularSalario(t); return t; }).ToList();
                return new ResponseIdentity<List<Trabajador>>() { data = data, mensaje = "Operación se ha completado exitosamente" };

            }
            catch(Exception e)
            {
                return new ResponseIdentity<List<Trabajador>>() { data=null,mensaje=e.Message};
            }
            
        }

        [HttpGet("buscar/{nro_documento}")]
        public ResponseIdentity<List<Trabajador>> obtenerDetalle(string nro_documento)
        {
            try
            {
                
                var trabajador = trabajadores.Where(t => t.dni.Trim().Equals(nro_documento.Trim())).ToList().Select(t=> 
                {
                    var tipo = tipoTrabajador.FirstOrDefault(tt => tt.tipoTrabajador == t.tipoTrabajador);
                    t.salarioNeto = tipo.CalcularSalario(t); 
                    return t; 
                }).ToList();

                return new ResponseIdentity<List<Trabajador>>() { data = trabajador != null ? trabajador : null, mensaje = trabajador != null ? "Operación se ha completado exitosamente" : "Trabajador no encontrado" };
            }            
            catch (Exception e)
            {
                return new ResponseIdentity<List<Trabajador>>() { data = null, mensaje = e.Message };
            }

        }
    }
}
