using System.ComponentModel.DataAnnotations;
//valirdar los cambios del formulario
namespace UTS.Models
{
    public class InstalacionModel
    {
        public int idaula { get; set; }

        public int capacidad { get; set; }

        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio wachin")]

        public EdificioModel refEdificio { get; set; }

    }
}
