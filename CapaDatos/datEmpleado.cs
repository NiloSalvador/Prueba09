using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class datEmpleado
    {
        #region Singleton
            private static readonly datEmpleado UnicaInstancia = new datEmpleado();

            public static datEmpleado Instancia
            {
                get
                {
                    return datEmpleado.UnicaInstancia;
                }
            }
        #endregion Singleton

        #region Metodos CRUD
            public entEmpleado verificarEmpleado(string usuario, string contrasena)
            {
                entEmpleado e = null;
                SqlCommand cmd = null;
                try
                {
                    SqlConnection cn = Conexion.Instancia.Conectar();
                    cmd = new SqlCommand("spVerificarEmpleado", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmUsuario", usuario);
                    cmd.Parameters.AddWithValue("@prmContrasena", contrasena);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        e = new entEmpleado();
                        e.idEmpleado = Convert.ToInt32(dr["idEmpleado"]);
                        e.nombres = Convert.ToString(dr["nombres"]);
                        e.apellidos = Convert.ToString(dr["apellidos"]);
                        e.documentoIdentidad = Convert.ToString(dr["documentoIdentidad"]);
                        e.tipoDocumentoIdentidad = Convert.ToString(dr["tipoDocumentoIdentidad"]);
                        e.celular = Convert.ToString(dr["celular"]);
                        e.correo = Convert.ToString(dr["correo"]);
                        e.sexo = Convert.ToString(dr["sexo"]);
                        e.fechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]);
                        e.cargo = Convert.ToString(dr["cargo"]);
                        e.estado = Convert.ToString(dr["estado"]);
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return e;
            }

            public List<entEmpleado> ListarEmpleado()
            {
                SqlCommand cmd = null;
                List<entEmpleado> lista = new List<entEmpleado>();
                try
                {
                    SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                    cmd = new SqlCommand("spListarEmpleados", cn);  //Consulta a la base de datos
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        entEmpleado p = new entEmpleado();
                        p.idEmpleado = Convert.ToInt32(dr["identEmpleado"]);
                        p.nombres = Convert.ToString(dr["nombre"]);
                        p.apellidos = Convert.ToString(dr["marca"]);
                        p.documentoIdentidad = Convert.ToString(dr["cantidad"]);
                        p.tipoDocumentoIdentidad = Convert.ToString(dr["precio"]);
                        p.celular = Convert.ToString(dr["descripcion"]);
                        p.correo = Convert.ToString(dr["estado"]);
                        lista.Add(p);
                    }
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }

                return lista;
            }

            public entEmpleado BuscarEmpleado(int idEmpleado)
            {
                SqlCommand cmd = null;
                entEmpleado p = null;
                try
                {
                    SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                    cmd = new SqlCommand("spBuscarEmpleado", cn);  //Consulta a la base de datos
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmidEmpleado", idEmpleado);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        p = new entEmpleado();
                        p.idEmpleado = Convert.ToInt32(dr["idEmpleado"]);
                        p.nombres = Convert.ToString(dr["nombre"]);
                        p.apellidos = Convert.ToString(dr["marca"]);
                        p.documentoIdentidad = Convert.ToString(dr["cantidad"]);
                        p.tipoDocumentoIdentidad = Convert.ToString(dr["precio"]);
                        p.celular = Convert.ToString(dr["descripcion"]);
                        p.correo = Convert.ToString(dr["estado"]);
                    }
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }

                return p;
            }

            public Boolean InsertarEmpleado(entEmpleado p)
            {
                SqlCommand cmd = null;
                Boolean inserto = false;
                try
                {
                    SqlConnection cn = Conexion.Instancia.Conectar();
                    cmd = new SqlCommand("spInsertarEmpleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmNombres", p.nombres);
                    cmd.Parameters.AddWithValue("@prmApellidos", p.apellidos);
                    cmd.Parameters.AddWithValue("@prmDocumentoIdentidad", p.documentoIdentidad);
                    cmd.Parameters.AddWithValue("@prmTipoDocumentoIdentidad", p.tipoDocumentoIdentidad);
                    cmd.Parameters.AddWithValue("@prmCelular", p.celular);
                    cmd.Parameters.AddWithValue("@prmCorreo", p.correo);
                    cmd.Parameters.AddWithValue("@prmSexo", p.sexo);
                    cmd.Parameters.AddWithValue("@prmFechaNacimiento", p.fechaNacimiento);
                    cmd.Parameters.AddWithValue("@prmCargo", p.cargo);
                    cmd.Parameters.AddWithValue("@prmUsuario", p.usuario);
                    cmd.Parameters.AddWithValue("@prmContrasena", p.contrasena);
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


            public Boolean EditarEmpleado(entEmpleado e)
            {
                SqlCommand cmd = null;
                Boolean edito = false;
                try
                {
                    SqlConnection cn = Conexion.Instancia.Conectar();
                    cmd = new SqlCommand("spEditarEmpleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmstridEmpleado", e.idEmpleado);
                    cmd.Parameters.AddWithValue("@prmNombres", e.nombres);
                    cmd.Parameters.AddWithValue("@prmApellidos", e.apellidos);
                    cmd.Parameters.AddWithValue("@prmDocumentoIdentidad", e.documentoIdentidad);
                    cmd.Parameters.AddWithValue("@prmTipoDocumentoIdentidad", e.tipoDocumentoIdentidad);
                    cmd.Parameters.AddWithValue("@prmCelular", e.celular);
                    cmd.Parameters.AddWithValue("@prmCorreo", e.correo);
                    cmd.Parameters.AddWithValue("@prmSexo", e.sexo);
                    cmd.Parameters.AddWithValue("@prmFechaNacimiento", e.fechaNacimiento);
                    cmd.Parameters.AddWithValue("@prmCargo", e.cargo);
                    cmd.Parameters.AddWithValue("@prmUsuario", e.usuario);
                    cmd.Parameters.AddWithValue("@prmContrasena", e.contrasena);
                    cmd.Parameters.AddWithValue("@prmEstado", e.estado);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0) edito = true;
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                return edito;
            }
            
            public Boolean EliminarEmpleado(int idEmpleado)
            {
                SqlCommand cmd = null;
                Boolean elimino = false;
                try
                {
                    SqlConnection cn = Conexion.Instancia.Conectar();
                    cmd = new SqlCommand("spEliminarEmpleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmstridEmpleado", idEmpleado);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0) elimino = true;
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                return elimino;
            }



        #endregion Metodos
    }
}
