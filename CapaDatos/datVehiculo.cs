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

        public List<entVehiculo> ListarVehiculos()
        {
            SqlCommand cmd = null;
            List<entVehiculo> lista = new List<entVehiculo>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarVehiculos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entVehiculo v = new entVehiculo();
                    v.idVehiculo = Convert.ToInt32(dr["idVehiculo"]);
                    v.placa = dr["placa"].ToString();
                    v.marca = dr["marca"].ToString();
                    v.modelo = dr["modelo"].ToString();
                    v.color = dr["color"].ToString();
                    v.Cliente = new entCliente();
                    v.Cliente.idCliente = Convert.ToInt32(dr["idCliente"]);
                    v.Cliente.nombres = dr["nombres"].ToString();
                    v.Cliente.apellidos = dr["apellidos"].ToString();
                    v.Cliente.documentoIdentidad = dr["documentoIdentidad"].ToString();
                    v.Cliente.tipoDocumentoIdentidad = dr["tipoDocumentoIdentidad"].ToString();
                    v.Cliente.tipoCliente = dr["tipoCliente"].ToString();
                    v.Cliente.celular = dr["celular"].ToString();
                    v.Cliente.correo = dr["correo"].ToString();
                    v.Cliente.estado = Convert.ToBoolean(dr["estado"]);
                    v.estado = Convert.ToBoolean(dr["estado"]);
                    lista.Add(v);
                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lista;
        }

        public Boolean EditarVehiculo (entVehiculo v)
        {

        }

        #endregion metodos
    }
}
