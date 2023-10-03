using UTS.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Identity.Client;
using System.Transactions;
using System.Drawing.Imaging;

namespace UTS.Datos
{
    public class HorarioDatos
    {
        public List<HorarioModel> Listar()
        {
            var oLista = new List<HorarioModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_ListarHorario", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new HorarioModel()
                        {
                            idhorario = Convert.ToInt32(dr["idhorario"]),
                            refInstalacion = new InstalacionModel
                            {
                                idaula = Convert.ToInt32(dr["idaula2"]),
                            },
                            clave_empleado2 = Convert.ToInt32(dr["clave_empleado2"]),
                            Fecha = (DateTime)dr["Fecha"],
                            HoraInicio = (TimeSpan)dr["HoraInicio"],
                            HoraFin = (TimeSpan)dr["HoraFin"]
                        });
                    }
                }
            }
            return oLista;

        }
        public HorarioModel ConsultarHorario(int idhorario)
        {
            var oHorario = new HorarioModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("horario_agenda_consultar", conexion);
                cmd.Parameters.AddWithValue("idhorario", idhorario);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oHorario.idhorario = Convert.ToInt32(dr["idhorario"]);
                        oHorario.refInstalacion = new InstalacionModel
                        {
                            idaula = Convert.ToInt32(dr["idaula2"]),
                        };
                        oHorario.clave_empleado2 = Convert.ToInt32(dr["clave_empleado2"]);
                        oHorario.Fecha = (DateTime)dr["Fecha"];
                        oHorario.HoraInicio = (TimeSpan)dr["HoraInicio"];
                        oHorario.HoraFin = (TimeSpan)dr["HoraFin"];
                    }
                }
            }
            return oHorario;
        }

        public bool InsertarApartado(HorarioModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_InsertarHorario", conexion);
                    cmd.Parameters.AddWithValue("idaula2", model.refInstalacion.idaula);
                    cmd.Parameters.AddWithValue("clave_empleado2", model.clave_empleado2);
                    cmd.Parameters.AddWithValue("Fecha", model.Fecha);
                    cmd.Parameters.AddWithValue("HoraInicio", model.HoraInicio);
                    cmd.Parameters.AddWithValue("HoraFin", model.HoraFin);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception  e) {
                string error = e.Message;
                respuesta = false;
            }

            return respuesta;

        }

        public bool EditarApartado(HorarioModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_EditarHorario", conexion);
                    cmd.Parameters.AddWithValue("idhorario", model.idhorario);
                    cmd.Parameters.AddWithValue("idaula2", model.refInstalacion.idaula);
                    cmd.Parameters.AddWithValue("clave_empleado2", model.clave_empleado2);
                    cmd.Parameters.AddWithValue("Fecha", model.Fecha);
                    cmd.Parameters.AddWithValue("HoraInicio", model.HoraInicio);
                    cmd.Parameters.AddWithValue("HoraFin", model.HoraFin);
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

        public bool EliminarHorario(int idhorario) 
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("dbo.horario_agenda_eliminar", conexion);
                    cmd.Parameters.AddWithValue("idhorario", idhorario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch(Exception e) 
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

    }

}

