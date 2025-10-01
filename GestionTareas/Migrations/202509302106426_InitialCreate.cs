namespace GestionTareas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archivo",
                c => new
                    {
                        ArchivoID = c.Int(nullable: false, identity: true),
                        TareaID = c.Int(),
                        ProyectoID = c.Int(),
                        UsuarioID = c.Int(nullable: false),
                        NombreArchivo = c.String(nullable: false, maxLength: 200),
                        Ruta = c.String(nullable: false),
                        FechaSubida = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ArchivoID)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoID)
                .ForeignKey("dbo.Tarea", t => t.TareaID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.TareaID)
                .Index(t => t.ProyectoID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Proyecto",
                c => new
                    {
                        ProyectoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        Descripcion = c.String(),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(),
                        Estado = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ProyectoID);
            
            CreateTable(
                "dbo.ProyectoEquipo",
                c => new
                    {
                        ProyectoEquipoID = c.Int(nullable: false, identity: true),
                        ProyectoID = c.Int(nullable: false),
                        EquipoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProyectoEquipoID)
                .ForeignKey("dbo.Equipo", t => t.EquipoID, cascadeDelete: true)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoID, cascadeDelete: true)
                .Index(t => t.ProyectoID)
                .Index(t => t.EquipoID);
            
            CreateTable(
                "dbo.Equipo",
                c => new
                    {
                        EquipoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.EquipoID);
            
            CreateTable(
                "dbo.EquipoMiembro",
                c => new
                    {
                        EquipoMiembroID = c.Int(nullable: false, identity: true),
                        EquipoID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        RolEnEquipo = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.EquipoMiembroID)
                .ForeignKey("dbo.Equipo", t => t.EquipoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.EquipoID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 150),
                        Telefono = c.String(maxLength: 20),
                        Direccion = c.String(maxLength: 255),
                        Contraseña = c.String(nullable: false, maxLength: 255),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        ComentarioID = c.Int(nullable: false, identity: true),
                        TareaID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        ComentarioTexto = c.String(nullable: false),
                        FechaComentario = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ComentarioID)
                .ForeignKey("dbo.Tarea", t => t.TareaID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.TareaID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Tarea",
                c => new
                    {
                        TareaID = c.Int(nullable: false, identity: true),
                        ProyectoID = c.Int(nullable: false),
                        AsignadoA = c.Int(),
                        Titulo = c.String(nullable: false, maxLength: 200),
                        Descripcion = c.String(),
                        Estado = c.String(maxLength: 50),
                        Prioridad = c.String(maxLength: 20),
                        FechaInicio = c.DateTime(),
                        FechaFin = c.DateTime(),
                    })
                .PrimaryKey(t => t.TareaID)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.AsignadoA)
                .Index(t => t.ProyectoID)
                .Index(t => t.AsignadoA);
            
            CreateTable(
                "dbo.Reporte",
                c => new
                    {
                        ReporteID = c.Int(nullable: false, identity: true),
                        ProyectoID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        TipoReporte = c.String(maxLength: 100),
                        FechaGeneracion = c.DateTime(nullable: false),
                        Detalles = c.String(),
                    })
                .PrimaryKey(t => t.ReporteID)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.ProyectoID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.ReunionParticipante",
                c => new
                    {
                        ReunionParticipanteID = c.Int(nullable: false, identity: true),
                        ReunionID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReunionParticipanteID)
                .ForeignKey("dbo.Reunion", t => t.ReunionID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.ReunionID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Reunion",
                c => new
                    {
                        ReunionID = c.Int(nullable: false, identity: true),
                        ProyectoID = c.Int(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 200),
                        Fecha = c.DateTime(nullable: false),
                        Notas = c.String(),
                    })
                .PrimaryKey(t => t.ReunionID)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoID, cascadeDelete: true)
                .Index(t => t.ProyectoID);
            
            CreateTable(
                "dbo.UsuarioRol",
                c => new
                    {
                        UsuarioRolID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        RolID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioRolID)
                .ForeignKey("dbo.Rol", t => t.RolID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID)
                .Index(t => t.RolID);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        RolID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RolID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Archivo", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Archivo", "TareaID", "dbo.Tarea");
            DropForeignKey("dbo.Archivo", "ProyectoID", "dbo.Proyecto");
            DropForeignKey("dbo.ProyectoEquipo", "ProyectoID", "dbo.Proyecto");
            DropForeignKey("dbo.ProyectoEquipo", "EquipoID", "dbo.Equipo");
            DropForeignKey("dbo.EquipoMiembro", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioRol", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioRol", "RolID", "dbo.Rol");
            DropForeignKey("dbo.ReunionParticipante", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.ReunionParticipante", "ReunionID", "dbo.Reunion");
            DropForeignKey("dbo.Reunion", "ProyectoID", "dbo.Proyecto");
            DropForeignKey("dbo.Reporte", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Reporte", "ProyectoID", "dbo.Proyecto");
            DropForeignKey("dbo.Comentario", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Comentario", "TareaID", "dbo.Tarea");
            DropForeignKey("dbo.Tarea", "AsignadoA", "dbo.Usuario");
            DropForeignKey("dbo.Tarea", "ProyectoID", "dbo.Proyecto");
            DropForeignKey("dbo.EquipoMiembro", "EquipoID", "dbo.Equipo");
            DropIndex("dbo.UsuarioRol", new[] { "RolID" });
            DropIndex("dbo.UsuarioRol", new[] { "UsuarioID" });
            DropIndex("dbo.Reunion", new[] { "ProyectoID" });
            DropIndex("dbo.ReunionParticipante", new[] { "UsuarioID" });
            DropIndex("dbo.ReunionParticipante", new[] { "ReunionID" });
            DropIndex("dbo.Reporte", new[] { "UsuarioID" });
            DropIndex("dbo.Reporte", new[] { "ProyectoID" });
            DropIndex("dbo.Tarea", new[] { "AsignadoA" });
            DropIndex("dbo.Tarea", new[] { "ProyectoID" });
            DropIndex("dbo.Comentario", new[] { "UsuarioID" });
            DropIndex("dbo.Comentario", new[] { "TareaID" });
            DropIndex("dbo.EquipoMiembro", new[] { "UsuarioID" });
            DropIndex("dbo.EquipoMiembro", new[] { "EquipoID" });
            DropIndex("dbo.ProyectoEquipo", new[] { "EquipoID" });
            DropIndex("dbo.ProyectoEquipo", new[] { "ProyectoID" });
            DropIndex("dbo.Archivo", new[] { "UsuarioID" });
            DropIndex("dbo.Archivo", new[] { "ProyectoID" });
            DropIndex("dbo.Archivo", new[] { "TareaID" });
            DropTable("dbo.Rol");
            DropTable("dbo.UsuarioRol");
            DropTable("dbo.Reunion");
            DropTable("dbo.ReunionParticipante");
            DropTable("dbo.Reporte");
            DropTable("dbo.Tarea");
            DropTable("dbo.Comentario");
            DropTable("dbo.Usuario");
            DropTable("dbo.EquipoMiembro");
            DropTable("dbo.Equipo");
            DropTable("dbo.ProyectoEquipo");
            DropTable("dbo.Proyecto");
            DropTable("dbo.Archivo");
        }
    }
}
