using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class logEmpleado
    {
        #region singleton
        private static readonly logEmpleado UnicaInstancia = new logEmpleado();

        public static logEmpleado Instancia
        {
            get
            {
                return logEmpleado.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        
        
        #endregion metodos

    }
}
