using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entEmpleado
    {
        public int idEmpleado { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string documentoIdentidad { get; set; }
        public string tipoDocumentoIdentidad { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public string sexo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string cargo { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string estado { get; set; }

        
    }
}
