using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entCliente
    {
        public int idCliente { get; set; }
        public String nombres { get; set; }
        public String apellidos { get; set; }
        public String documentoIdentidad { get; set; }
        public String tipoDocumentoIdentidad { get; set; }
        public String tipoCliente { get; set; }
        public String celular { get; set; }
        public String correo { get; set; }
        public Boolean estado { get; set; }
    }
}
