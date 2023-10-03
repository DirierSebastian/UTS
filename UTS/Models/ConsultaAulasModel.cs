namespace UTS.Models
{
    public class ConsultaAulasModel
    {

        public string Nombre { get; set; }
        public TimeSpan? Horainicio { get; set; }
        public TimeSpan? HoraoFin { get; set; }
        public DateTime? Fecha { get; set; }
        public string NombreAula { get; set; }
        public int NumeroEdificio { get; set; }
        public int idhorario { get; set; }
    }
}
