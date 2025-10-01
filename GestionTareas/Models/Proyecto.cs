using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace GestionTareas.Models
{
    public class Proyecto
    {
        [Key]
        public int ProyectoID { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaFin { get; set; }

        [StringLength(50)]
        public string Estado { get; set; } = "En Progreso";

        // Relaciones
        public virtual ICollection<ProyectoEquipo> ProyectoEquipos { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
        public virtual ICollection<Archivo> Archivos { get; set; }
        public virtual ICollection<Reporte> Reportes { get; set; }
        public virtual ICollection<Reunion> Reuniones { get; set; }
    }
}