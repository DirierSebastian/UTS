using UTS.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Identity.Client;
using System.Transactions;
using System.Drawing.Imaging;


namespace UTS.Datos
{
    public class ConsultaAulasDatos
    {
        public List<ConsultaAulasModel> Listar()
        {
            //crear una lista vacia
            var oLista = new List<ConsultaAulasModel>();
            // crear una instancia de la clase conexion
            var cn = new Conexion();
            //utilizar using para establecer la cadena de conexion
            using (var conexion = new SqlConnection(cn.getAulasUTSContext()))
            {
                //abrir la conexion
                conexion.Open();
                //Comando a ejecutar
                SqlCommand cmd = new SqlCommand("Sp_consulta_multitabla2", conexion);
                //decir el tipo de comando
                cmd.CommandType = CommandType.StoredProcedure;
                //Leer el resultado de la ejecucion del procedimiento almacenado
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //una ves se esten leyendo tambien los guardaremos en la lista
                        oLista.Add(new ConsultaAulasModel()
                        { //se utilizan las propiedades de la clase
                            Nombre = dr["Nombre"].ToString(),
                            Horainicio = (TimeSpan)dr["Horainicio"],
                            HoraoFin = (TimeSpan)dr["HoraoFin"],
                            Fecha = (DateTime)dr["Fecha"],
                            NombreAula = dr["NombreAula"].ToString(),
                            NumeroEdificio = Convert.ToInt32(dr["NumeroEdificio"]),
                            idhorario = Convert.ToInt32(dr["idhorario"])
                        });
                    }
                }
            }
            return oLista;
        }
    }
}
