using ReyMagoApi.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReyMagoAPI.Core.Models.DTO
{
    public class SolicitudIngresoDTO
    {
        [Required(ErrorMessage = "The FirstName is Required")]
        [MaxLength(20)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "The LastName is Required")]
        [MaxLength(20)]
        public string Apellido { get; set; } = string.Empty;

        [MaxLength(10)]
        [Required(ErrorMessage = "The Identification should be between 20 Characters")]
        [RegularExpression("^[a-zA-Z]{1}[0-9]{9}$", ErrorMessage = "Only accept letters and numbers, Format allow V123456789")]
        public string Identificacion { get; set; } = string.Empty;

       
        [Required(ErrorMessage = "Insert your Age")]
        public int Edad { get; set; } = 0;

        public int Afinidad_Id { get; set; }

        
    }

    public class SolicitudIngresoPorGrimorioDTO
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "The FirstName is Required")]
        [MaxLength(20)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(10)]
        [Required(ErrorMessage = "The Identification should be between 20 Characters")]
        [RegularExpression("^[a-zA-Z]{1}[0-9]{9}$", ErrorMessage = "Only accept letters and numbers, Format allow V123456789")]
        public string Identificacion { get; set; } = string.Empty;
       
    }

    public class SolicitudIngresoActualizacionEstadoDTO
    {
        public bool Estatus { get; set; }
        
    }

}
