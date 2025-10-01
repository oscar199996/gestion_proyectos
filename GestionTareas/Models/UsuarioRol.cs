using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTareas.Models
{
    public class UsuarioRol
    {
        [Key]
        public int UsuarioRolID { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioID { get; set; }

        [ForeignKey("Rol")]
        public int RolID { get; set; }

        // Propiedades de navegación
        public virtual Usuario Usuario { get; set; }
        public virtual Rol Rol { get; set; }
    }
}