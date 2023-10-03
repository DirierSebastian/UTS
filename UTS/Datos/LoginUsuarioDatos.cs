using UTS.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Identity.Client;
using System.Transactions;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UTS.Datos
{
    public class LoginUsuarioDatos
    {
        //metodo para ver si existe el correo


        public bool existeCorreo(int clave_empleado)
        {
           int eCorreo = 0;
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Validarclave", conexion);
                cmd.Parameters.AddWithValue("clave_empleado", clave_empleado);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        eCorreo = Convert.ToInt32(dr["clave_empleado"]);
                        //eCorreo = dr["clave_empleado"].ToString();
                    }
              
                }
            }
            if (eCorreo != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //creacion del metodo registro
        public bool Registro(UsuarioModel model)
        {
            bool respuesta;
            if (!existeCorreo(model.clave_empleado))
            {
                try
                {
                    var cn = new Conexion();
                    using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
                    {
                        conexion.Open();
                        SqlCommand cmd = new SqlCommand("SP_insertar_usuario", conexion);
                        cmd.Parameters.AddWithValue("clave_empleado", model.clave_empleado);
                        cmd.Parameters.AddWithValue("nombre", model.nombre);
                        cmd.Parameters.AddWithValue("apellidos", model.apellidos);
                        cmd.Parameters.AddWithValue("contraseña", model.contraseña);
                        cmd.Parameters.AddWithValue("telefono", model.telefono);
                   //     cmd.Parameters.AddWithValue("correo", model.correo);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();

                    }
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    respuesta = false;
                }
            }
            else
            {
                respuesta = false;
            }
            return respuesta;
        }



        //metodo validar usuario

        public UsuarioModel ValidarUsuario(int clave_empleado, string contraseña)
        {
            UsuarioModel usuario = new UsuarioModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", conexion);
                cmd.Parameters.AddWithValue("clave_empleado", clave_empleado);
                cmd.Parameters.AddWithValue("contraseña", contraseña);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario.clave_empleado = Convert.ToInt32(dr["clave_empleado"]);
                        usuario.nombre = dr["nombre"].ToString();
                        usuario.apellidos = dr["apellidos"].ToString();
                        usuario.contraseña = dr["contraseña"].ToString();
                        usuario.telefono = dr["telefono"].ToString();
                      //  usuario.correo = dr["correo"].ToString();

                    }
                }
            }
            return usuario;
        }

        //crear el metodo de CambiarClave
        public bool CambiarClave(int clave_empleado, string contraseña)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CambiarClave", conexion);
                    cmd.Parameters.AddWithValue("clave_empleado", clave_empleado);
                    cmd.Parameters.AddWithValue("contraseña", contraseña);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

    }
}