using System;
using System.Collections.Generic;

namespace SOL_JUNIOR_SULCA.Entidades.Genericos
{
    public class Curso
    {
        public string CodLineaNegocio { get; set; }
        public string CodCurso { get; set; }

        public string DescCurso { get; set; }

        public string UsuarioCreador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public List<MatriculaDetalle> Matriculas { get; set; }
    }
}
