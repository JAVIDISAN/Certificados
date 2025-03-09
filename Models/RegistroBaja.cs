using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoBD.Models
{
    public class RegistroBaja
    {
        string matricula;
        DateTime fechaBaja;
        string observaciones;
        DateTime fechaMaxReingreso;
        string tipoBaja;

        public string Matricula { get => matricula; set => matricula = value; }
        public DateTime FechaBaja { get => fechaBaja; set => fechaBaja = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public DateTime FechaMaxReingreso { get => fechaMaxReingreso; set => fechaMaxReingreso = value; }
        public string TipoBaja { get => tipoBaja; set => tipoBaja = value; }
    }
}
