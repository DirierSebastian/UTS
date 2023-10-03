using UTS.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Identity.Client;
using System.Transactions;
using System.Drawing.Imaging;

namespace UTS.Datos
{
    public class InstalacionDatos
    {
        public List<InstalacionModel> Lista()
        {
            //crear una lista vacia
            var oLista = new List<InstalacionModel>();
            // crear una instancia de la clase conexion
            var cn = new Conexion();
            //utilizar using para establecer la cadena de conexion
            using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
            {
                //abrir la conexion
                conexion.Open();
                //Comando a ejecutar
                SqlCommand cmd = new SqlCommand("SP_listar_instalaciones", conexion);
                //decir el tipo de comando
                cmd.CommandType = CommandType.StoredProcedure;
                //Leer el resultado de la ejecucion del procedimiento almacenado
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //una ves se esten leyendo tambien los guardaremos en la lista
                        oLista.Add(new InstalacionModel()
                        { //se utilizan las propiedades de la clase
                            idaula = Convert.ToInt32(dr["idaula"]),
                            capacidad = Convert.ToInt32(dr["capacidad"]),
                            nombre = dr["nombre"].ToString(),
                            refEdificio = new EdificioModel()
                            {
                                numedificio = Convert.ToInt32(dr["numedificio1"])
                            }
                        });
                    }
                }
            }
            return oLista;
        }

        public InstalacionModel ConsultarInstalacion(int idaula)
        {
            var oInstalacion = new InstalacionModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_consulta_instalacion", conexion);
                cmd.Parameters.AddWithValue("idaula", idaula);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oInstalacion.idaula = Convert.ToInt32(dr["idaula"]);
                        oInstalacion.capacidad = Convert.ToInt32(dr["capacidad"]);
                        oInstalacion.nombre = dr["nombre"].ToString();
                        oInstalacion.refEdificio = new EdificioModel()
                        {
                            numedificio = Convert.ToInt32(dr["numedificio1"])
                        };

                    }
                }
            }
            return oInstalacion;
        }


        public bool GuardarInstalacion(InstalacionModel model)
        {
            //creo una variable boolean
            bool respuesta;
            try
            {
                var cn = new Conexion();
                //utlizar la cadena para establecer la cadena de conexion
                using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_insertar_instalacion", conexion);
                    //enviado un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("capacidad", model.capacidad);
                    cmd.Parameters.AddWithValue("nombre", model.nombre);
                    cmd.Parameters.AddWithValue("numedificio1", model.refEdificio.numedificio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //ejecutar el procedimiento almacennado
                    cmd.ExecuteNonQuery();
                }
                //si no ocurre un error la variable respuesta sera true
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool EditarInstalacion(InstalacionModel model)
        {
            //creo una variable boolean
            bool respuesta;
            try
            {
                var cn = new Conexion();
                //utlizar la cadena para establecer la cadena de conexion
                using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_actualizar_instalacion", conexion);
                    //enviado un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("idaula", model.idaula);
                    cmd.Parameters.AddWithValue("capacidad", model.capacidad);
                    cmd.Parameters.AddWithValue("nombre", model.nombre);
                    cmd.Parameters.AddWithValue("numedificio1", model.refEdificio.numedificio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //ejecutar el procedimiento almacennado
                    cmd.ExecuteNonQuery();
                }
                //si no ocurre un error la variable respuesta sera true
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool EliminarInstalacion(int idaula)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_eliminar_instalacion", conexion);
                    cmd.Parameters.AddWithValue("idaula", idaula);
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
