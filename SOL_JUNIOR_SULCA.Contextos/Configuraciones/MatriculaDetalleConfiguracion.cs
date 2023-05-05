using SOL_JUNIOR_SULCA.Entidades.Genericos;
using System.Data.Entity.ModelConfiguration;

namespace SOL_JUNIOR_SULCA.Contextos
{
    public class MatriculaDetalleConfiguracion
    {
        public static void Configure(EntityTypeConfiguration<MatriculaDetalle> configuration)
        {
            configuration.ToTable("DET_MATRICULA").HasKey(x => new
            {
                x.MatriculaIdMatricula,
                x.CursoCodLineaNegocio,
                x.CursoCodCurso
            });

            configuration.Property(x => x.CodProducto).HasColumnName("COD_PRODUCTO");
            configuration.Property(x => x.Seccion).HasColumnName("SECCION");
            configuration.Property(x => x.Grupo).HasColumnName("GRUPO");

            configuration.Property(x => x.UsuarioCreador).HasColumnName("USUARIO_CREADOR");
            configuration.Property(x => x.FechaCreacion).HasColumnName("FECHA_CREACION");
            configuration.Property(x => x.UsuarioModificacion).HasColumnName("USUARIO_MODIFICACION");
            configuration.Property(x => x.FechaModificacion).HasColumnName("FECHA_MODIFICACION");

            configuration.Property(x => x.MatriculaIdMatricula).HasColumnName("MATRICULA_ID_MATRICULA");
            configuration.Property(x => x.CursoCodLineaNegocio).HasColumnName("CURSO_COD_LINEA_NEGOCIO");
            configuration.Property(x => x.CursoCodCurso).HasColumnName("CURSO_COD_CURSO");

            configuration.HasRequired(x => x.Matricula).WithMany(x => x.Detalles);
            configuration.HasRequired(x => x.Curso).WithMany(x => x.Matriculas);
        }
    }
}
