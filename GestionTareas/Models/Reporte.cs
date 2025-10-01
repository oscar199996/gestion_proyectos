using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTareas.Models
{
    public class Reporte
    {
        [Key]
        public int ReporteID { get; set; }

        [ForeignKey("Proyecto")]
        public int ProyectoID { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioID { get; set; }

        [StringLength(100)]
        public string TipoReporte { get; set; }

        public DateTime FechaGeneracion { get; set; } = DateTime.Now;

        public string Detalles { get; set; }

        // Propiedades de navegación
        public virtual Proyecto Proyecto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}