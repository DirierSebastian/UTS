using UTS.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Identity.Client;
using System.Transactions;
using System.Drawing.Imaging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UTS.Datos
{
    public class ConsultaHorariosDatos
    {
        public List<ConsultaHorariosModel> Listar()
        {
            var oLista = new List<ConsultaHorariosModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_Lista_multitablasH", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ConsultaHorariosModel()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            ClaveDeEmpleado = Convert.ToInt32(dr["ClaveDeEmpleado"]),
                            Nombre = dr["Nombre"].ToString(),
                            Fecha = (DateTime)dr["Fecha"],
                            InicioDelApartado = (TimeSpan)dr["InicioDelApartado"],
                            FinDelApartado = (TimeSpan)dr["FinDelApartado"],
                            NumeroEdificio = Convert.ToInt32(dr["NumeroEdificio"]),
                            NombreAula = dr["NombreAula"].ToString()
                        });
                    }
                }
            }
            return oLista;

        }
        public ConsultaHorariosModel ConsultarHorario(int Nombre)
        {
            var oConsulta = new ConsultaHorariosModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_consulta_multitablasH", conexion);
                cmd.Parameters.AddWithValue("Nombre", Nombre);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oConsulta.ID = Convert.ToInt32(dr["ID"]);
                        oConsulta.ClaveDeEmpleado = Convert.ToInt32(dr["ClaveDeEmpleado"]);
                        oConsulta.Nombre = dr["idhorario"].ToString();
                        oConsulta.Fecha = (DateTime)dr["Fecha"];
                        oConsulta.InicioDelApartado = (TimeSpan)dr["InicioDelApartado"];
                        oConsulta.FinDelApartado = (TimeSpan)dr["FinDelApartado"];
                        oConsulta.NumeroEdificio = Convert.ToInt32(dr["NumeroEdificio"]);
                        oConsulta.NombreAula = dr["NombreAula"].ToString();
                    }
                }
            }
            return oConsulta;
        }
    }
}
