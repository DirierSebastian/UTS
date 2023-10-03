namespace UTS.Models
{
    public class HorarioModel
    {
        public int idhorario { get; set; }
        public InstalacionModel refInstalacion { get; set; }
        public int clave_empleado2 { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

    }
}
