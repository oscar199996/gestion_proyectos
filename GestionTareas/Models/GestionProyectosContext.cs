using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GestionTareas.Models
{
    public class GestionProyectosContext : DbContext
    {
        public GestionProyectosContext() : base("DefaultConnection")
        {
        }

        // DbSets para cada tabla
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<ProyectoEquipo> ProyectoEquipos { get; set; }
        public DbSet<EquipoMiembro> EquipoMiembros { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Reunion> Reuniones { get; set; }
        public DbSet<ReunionParticipante> ReunionesParticipantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configuraciones adicionales de relaciones si es necesario
            modelBuilder.Entity<UsuarioRol>()
                .HasRequired(ur => ur.Usuario)
                .WithMany(u => u.UsuarioRoles)
                .HasForeignKey(ur => ur.UsuarioID);

            modelBuilder.Entity<UsuarioRol>()
                .HasRequired(ur => ur.Rol)
                .WithMany(r => r.UsuarioRoles)
                .HasForeignKey(ur => ur.RolID);
        }
    }
}