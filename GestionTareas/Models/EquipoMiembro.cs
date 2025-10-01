using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTareas.Models
{
    public class EquipoMiembro
    {
        [Key]
        public int EquipoMiembroID { get; set; }

        [ForeignKey("Equipo")]
        public int EquipoID { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioID { get; set; }

        [StringLength(100)]
        public string RolEnEquipo { get; set; }

        // Propiedades de navegación
        public virtual Equipo Equipo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}