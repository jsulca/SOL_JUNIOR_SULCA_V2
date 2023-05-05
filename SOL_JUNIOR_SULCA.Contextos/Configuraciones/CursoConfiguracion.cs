using SOL_JUNIOR_SULCA.Entidades.Genericos;
using System.Data.Entity.ModelConfiguration;

namespace SOL_JUNIOR_SULCA.Contextos
{
    public class CursoConfiguracion
    {
        public static void Configure(EntityTypeConfiguration<Curso> configuration)
        {
            configuration.ToTable("CURSO").HasKey(x => new
            {
                x.CodLineaNegocio,
                x.CodCurso
            });

            configuration.Property(x => x.CodLineaNegocio).HasColumnName("COD_LINEA_NEGOCIO");
            configuration.Property(x => x.CodCurso).HasColumnName("COD_CURSO");
            configuration.Property(x => x.DescCurso).HasColumnName("DESC_CURSO");

            configuration.Property(x => x.UsuarioCreador).HasColumnName("USUARIO_CREADOR");
            configuration.Property(x => x.FechaCreacion).HasColumnName("FECHA_CREACION");
            configuration.Property(x => x.UsuarioModificacion).HasColumnName("USUARIO_MODIFICACION");
            configuration.Property(x => x.FechaModificacion).HasColumnName("FECHA_MODIFICACION");
        }
    }
}
