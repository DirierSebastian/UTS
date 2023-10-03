
using UTS.Models;
using System.Data.SqlClient;
using System.Data;
using UTS.Datos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UTS.Models
{
    public class UsuarioDatos
    {
        public List<UsuarioModel> Listar()
        {
            var oLista = new List<UsuarioModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_listar_usuarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using(var dr=cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new UsuarioModel()
                        {
                            clave_empleado= Convert.ToInt32(dr["clave_empleado"]),
                            nombre = dr["nombre"].ToString(),
                            apellidos = dr["apellidos"].ToString(),
                            contraseña = dr["contraseña"].ToString(),
                            //  tipo = dr["tipo"].ToString()
                            telefono = dr["telefono"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public UsuarioModel ObtenerUsuario(int clave_empleado)
        {
            var oUsuario = new UsuarioModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_consultar_un_usuario", conexion);
                cmd.Parameters.AddWithValue("clave_empleado", clave_empleado);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr=cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        oUsuario.clave_empleado = Convert.ToInt32(dr["clave_empleado"]);
                        oUsuario.nombre = dr["nombre"].ToString();
                        oUsuario.apellidos = dr["apellidos"].ToString();
                        oUsuario.contraseña = dr["contraseña"].ToString();
                        //  oUsuario.tipo = dr["tipo"].ToString();
                        oUsuario.telefono = dr["telefono"].ToString();
                    }
                }
            }
            return oUsuario;
        }

        public bool GuardarUsuario(UsuarioModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using(var conexion = new SqlConnection(cn.getAulasUTSContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_insertar_usuario", conexion);
                    cmd.Parameters.AddWithValue("clave_empleado", model.clave_empleado);
                    cmd.Parameters.AddWithValue("nombre", model.nombre);
                    cmd.Parameters.AddWithValue("apellidos", model.apellidos);
                    cmd.Parameters.AddWithValue("contraseña", model.contraseña);
                    // cmd.Parameters.AddWithValue("tipo", model.tipo);
                     cmd.Parameters.AddWithValue("telefono", model.telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool EditarUsuario(UsuarioModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_actualizar_usuario", conexion);
                    cmd.Parameters.AddWithValue("clave_empleado", model.clave_empleado);
                    cmd.Parameters.AddWithValue("nombre", model.nombre);
                    cmd.Parameters.AddWithValue("apellidos", model.apellidos);
                    cmd.Parameters.AddWithValue("contraseña", model.contraseña);
                    cmd.Parameters.AddWithValue("telefono", model.telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool EliminarUsuario(int clave_empleado)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_eliminar_usuario", conexion);
                    cmd.Parameters.AddWithValue("clave_empleado", clave_empleado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
