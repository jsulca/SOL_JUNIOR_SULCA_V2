using System;
using System.Collections.Generic;

namespace SOL_JUNIOR_SULCA.Entidades.Genericos
{
    public class Matricula
    {
        public int IdMatricula { get; set; }
        public string CodLineaNegocio { get; set; }
        public string CodModalEst { get; set; }
        public string CodPeriodo { get; set; }
        public string CodAlumno { get; set; }

        public string UsuarioCreador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public List<MatriculaDetalle> Detalles { get; set; }
    }
}
