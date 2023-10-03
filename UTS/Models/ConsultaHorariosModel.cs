namespace UTS.Models
{
    public class ConsultaHorariosModel
    {
        public int ID { get; set; }
        public int ClaveDeEmpleado { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan InicioDelApartado { get; set; }
        public TimeSpan FinDelApartado { get; set; }
        public int NumeroEdificio { get; set; }
        public string NombreAula { get; set; }

    }
}
