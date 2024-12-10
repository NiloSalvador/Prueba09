using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entVehiculo
    {
        public int idVehiculo { get; set; }
        public String placa { get; set; }
        public String marca { get; set; }
        public String modelo { get; set; }
        public String color { get; set; }
        public entCliente Cliente { get; set; }
        public Boolean estado { get; set; }


    }
}
