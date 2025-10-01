using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTareas.Models
{
    public class Archivo
    {
        [Key]
        public int ArchivoID { get; set; }

        [ForeignKey("Tarea")]
        public int? TareaID { get; set; }

        [ForeignKey("Proyecto")]
        public int? ProyectoID { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioID { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreArchivo { get; set; }

        [Required]
        public string Ruta { get; set; }

        public DateTime FechaSubida { get; set; } = DateTime.Now;

        // Propiedades de navegación
        public virtual Tarea Tarea { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}