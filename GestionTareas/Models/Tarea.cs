using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTareas.Models
{
    public class Tarea
    {
        [Key]
        public int TareaID { get; set; }

        [ForeignKey("Proyecto")]
        public int ProyectoID { get; set; }

        [ForeignKey("Usuario")]
        public int? AsignadoA { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        [StringLength(50)]
        public string Estado { get; set; } = "Pendiente";

        [StringLength(20)]
        public string Prioridad { get; set; } = "Media";

        [DataType(DataType.Date)]
        public DateTime? FechaInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaFin { get; set; }

        // Propiedades de navegación
        public virtual Proyecto Proyecto { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Archivo> Archivos { get; set; }
    }
}