using System;

namespace SOL_JUNIOR_SULCA.Entidades.Genericos
{
    public class MatriculaDetalle
    {
        public string CodProducto { get; set; }
        public int MatriculaIdMatricula { get; set; }
        public string CursoCodLineaNegocio { get; set; }
        public string CursoCodCurso { get; set; }

        public string Seccion { get; set; }
        public string Grupo { get; set; }

        public string UsuarioCreador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public Matricula Matricula { get; set; }
        public Curso Curso { get; set; }
    }
}
