using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionTareas.Models
{
    public class Equipo
    {
        [Key]
        public int EquipoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        // Relaciones
        public virtual ICollection<ProyectoEquipo> ProyectoEquipos { get; set; }
        public virtual ICollection<EquipoMiembro> EquipoMiembros { get; set; }
    }
}