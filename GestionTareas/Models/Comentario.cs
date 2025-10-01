using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTareas.Models
{
    public class Comentario
    {
        [Key]
        public int ComentarioID { get; set; }

        [ForeignKey("Tarea")]
        public int TareaID { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioID { get; set; }

        [Required]
        [Column("ComentarioTexto")] // Esto mapea a una columna diferente en la BD
        public string Texto { get; set; }

        public DateTime FechaComentario { get; set; } = DateTime.Now;

        // Propiedades de navegación
        public virtual Tarea Tarea { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}