using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTareas.Models
{
    public class ReunionParticipante
    {
        [Key]
        public int ReunionParticipanteID { get; set; }

        [ForeignKey("Reunion")]
        public int ReunionID { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioID { get; set; }

        // Propiedades de navegación
        public virtual Reunion Reunion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}