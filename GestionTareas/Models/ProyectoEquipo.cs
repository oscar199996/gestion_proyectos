using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTareas.Models
{
    public class ProyectoEquipo
    {
        [Key]
        public int ProyectoEquipoID { get; set; }

        [ForeignKey("Proyecto")]
        public int ProyectoID { get; set; }

        [ForeignKey("Equipo")]
        public int EquipoID { get; set; }

        // Propiedades de navegación
        public virtual Proyecto Proyecto { get; set; }
        public virtual Equipo Equipo { get; set; }
    }
}