using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTareas.Models
{
    public class Reunion
    {
        [Key]
        public int ReunionID { get; set; }

        [ForeignKey("Proyecto")]
        public int ProyectoID { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public string Notas { get; set; }

        // Propiedades de navegación
        public virtual Proyecto Proyecto { get; set; }
        public virtual ICollection<ReunionParticipante> ReunionesParticipantes { get; set; }
    }
}