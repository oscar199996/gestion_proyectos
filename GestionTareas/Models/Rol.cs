using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionTareas.Models
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        // Relaciones
        public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; }
    }
}