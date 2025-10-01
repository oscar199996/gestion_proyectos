using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionTareas.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(255)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(255)]
        public string Contraseña { get; set; }

        public bool Estado { get; set; } = true;

        // Relaciones
        public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; }
        public virtual ICollection<EquipoMiembro> EquipoMiembros { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Archivo> Archivos { get; set; }
        public virtual ICollection<Reporte> Reportes { get; set; }
        public virtual ICollection<ReunionParticipante> ReunionesParticipantes { get; set; }
    }
}