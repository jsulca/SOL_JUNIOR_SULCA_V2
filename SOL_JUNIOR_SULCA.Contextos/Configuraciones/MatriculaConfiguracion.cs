using SOL_JUNIOR_SULCA.Entidades.Genericos;
using System.Data.Entity.ModelConfiguration;

namespace SOL_JUNIOR_SULCA.Contextos
{
    public class MatriculaConfiguracion
    {
        public static void Configure(EntityTypeConfiguration<Matricula> configuration)
        {
            configuration.ToTable("MATRICULA").HasKey(x => x.IdMatricula);

            configuration.Property(x => x.IdMatricula).HasColumnName("ID_MATRICULA").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            configuration.Property(x => x.CodLineaNegocio).HasColumnName("COD_LINEA_NEGOCIO");
            configuration.Property(x => x.CodModalEst).HasColumnName("COD_MODAL_EST");
            configuration.Property(x => x.CodPeriodo).HasColumnName("COD_PERIODO");
            configuration.Property(x => x.CodAlumno).HasColumnName("COD_ALUMNO");

            configuration.Property(x => x.UsuarioCreador).HasColumnName("USUARIO_CREADOR");
            configuration.Property(x => x.FechaCreacion).HasColumnName("FECHA_CREACION");
            configuration.Property(x => x.UsuarioModificacion).HasColumnName("USUARIO_MODIFICACION");
            configuration.Property(x => x.FechaModificacion).HasColumnName("FECHA_MODIFICACION");
        }
    }
}
