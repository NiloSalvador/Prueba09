using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        #region singleton
        private static readonly Conexion UnicaInstancia = new Conexion();

        public static Conexion Instancia
        {
            get
            {
                return Conexion.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=PC-ING-NILO-S\\SQLEXPRESS; initial Catalog=DBEstacionamientoIJAM; Integrated Security= true";
            //cn.ConnectionString = "Data Source=DBIJAM.database.azure.net; initial Catalog= DBCafetinIJAM; User ID = nilo; Password = 1234";
            return cn;
        }



        #endregion metodos

    }
}
