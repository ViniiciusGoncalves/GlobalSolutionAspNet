using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalSolution.Models
{
    public class MedicoViewModel
    {
        public long MedicoId { get; set; }
        public string NomeMedico { get; set; }
        public string Especialidade { get; set; }
        public string Crm { get; set; }

        // Dados do Hospital
        public string NomeHospital { get; set; }
        public string TelefoneHospital { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
