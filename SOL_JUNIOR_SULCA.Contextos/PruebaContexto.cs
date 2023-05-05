using SOL_JUNIOR_SULCA.Entidades.Genericos;
using System.Data.Entity;

namespace SOL_JUNIOR_SULCA.Contextos
{
    public class PruebaContexto : DbContext
    {
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<MatriculaDetalle> MatriculaDetalle { get; set; }

        public PruebaContexto() : base ("name=OracleDbContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SYSTEM");

            CursoConfiguracion.Configure(modelBuilder.Entity<Curso>());
            MatriculaConfiguracion.Configure(modelBuilder.Entity<Matricula>());
            MatriculaDetalleConfiguracion.Configure(modelBuilder.Entity<MatriculaDetalle>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
