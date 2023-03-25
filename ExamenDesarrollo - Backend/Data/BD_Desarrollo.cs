using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using ExamenDesarrollo.Model;
using CsvHelper.Configuration;

namespace ExamenDesarrollo.Data
{
    public class BD_Desarrollo
    {
        public List<Trabajador> cargaDatosCSV()
        {
            string fileCSV = @"C:\data-trabajadores.csv";
            var trabajadores = new List<Trabajador>();
            try
            {
                var cnf = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = "|",
                    HasHeaderRecord = true,
                    HeaderValidated=null,
                    MissingFieldFound=null
                };
                using (var reader = new StreamReader(fileCSV))
                using (var csv = new CsvReader(reader, cnf))
                {
                    csv.Context.RegisterClassMap(new TrabajadorMap());
                    trabajadores = csv.GetRecords<Trabajador>().ToList();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return trabajadores;
        }
    }

    public sealed class TrabajadorMap : ClassMap<Trabajador>
    {
        public TrabajadorMap()
        {
            Map(t => t.dni).Name("DNI");
            Map(t => t.horasLaboradas).Name("Horas Laboradas");
            Map(t => t.diasLaborados).Name("Dias  Laborados");
            Map(t => t.faltas).Name("Faltas");
            Map(t => t.tipoTrabajador).Name("Tipo de Trabajador");
        }
    }
}
