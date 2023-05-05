using SOL_JUNIOR_SULCA.Entidades.Genericos;

namespace SOL_JUNIOR_SULCA.WebAPI.Models
{
    public class DTOMatricula
    {
        public string CodLineaNegocio { get; set; }
        public string CodModalEst { get; set; }
        public string CodPeriodo { get; set; }
        public string CodAlumno { get; set; }

        public string UsuarioCreador { get; set; }

        public Matricula ToMatricula() => new Matricula 
        {
            CodLineaNegocio = CodLineaNegocio,
            CodModalEst = CodModalEst,
            CodPeriodo = CodPeriodo,
            CodAlumno = CodAlumno,

            UsuarioCreador = UsuarioCreador
        };
    }
}