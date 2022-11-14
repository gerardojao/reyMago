using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReyMagoApi.Entities
{
    public class Grimorio
    {
        public Grimorio()
        {
            Estudiante = new HashSet<Estudiante>();           
        }

        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        public ICollection<Estudiante> Estudiante { get; set; }
    }
}
