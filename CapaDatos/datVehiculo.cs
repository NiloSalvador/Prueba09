using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datVehiculo
    {
        #region singleton
        private static readonly datVehiculo UnicaInstancia = new datVehiculo();

        public static datVehiculo Instancia
        {
            get
            {
                return datVehiculo.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public Boolean InsertarVehiculo (entVehiculo p)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarVehiculo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmPlaca", p.placa);
                cmd.Parameters.AddWithValue("@prmMarca", p.marca);
                cmd.Parameters.AddWithValue("@prmModelo", p.modelo);
                cmd.Parameters.AddWithValue("@prmColor", p.color);
                cmd.Parameters.AddWithValue("@prmIdCliente", p.Cliente.idCliente);
                cmd.Parameters.AddWithValue("@prmEstado", p.estado);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) inserto = true;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return inserto;
        }

        #endregion metodos
    }
}
