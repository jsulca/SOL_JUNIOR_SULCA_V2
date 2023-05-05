using SOL_JUNIOR_SULCA.Entidades.Genericos;

namespace SOL_JUNIOR_SULCA.WebAPI.Models
{
    public class DTOMatriculaDetalle
    {
        public string CodProducto { get; set; }
        public int? MatriculaIdMatricula { get; set; }
        public string CursoCodLineaNegocio { get; set; }
        public string CursoCodCurso { get; set; }

        public string Seccion { get; set; }
        public string Grupo { get; set; }

        public string UsuarioCreador { get; set; }

        public MatriculaDetalle ToMatriculaDetalle() => new MatriculaDetalle
        {
            CodProducto = CodProducto,
            MatriculaIdMatricula = MatriculaIdMatricula.Value,
            CursoCodLineaNegocio = CursoCodLineaNegocio,
            CursoCodCurso = CursoCodCurso,

            Seccion = Seccion,
            Grupo   = Grupo,

            UsuarioCreador = UsuarioCreador
        };
    }
}