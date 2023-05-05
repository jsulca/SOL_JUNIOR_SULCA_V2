using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Logicas;
using SOL_JUNIOR_SULCA.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SOL_JUNIOR_SULCA.WebAPI.Controllers
{
    [Route("v2/Matriculas")]
    public partial class MatriculaController : ApiController
    {
        private readonly MatriculaLogica _matriculaLogica;

        public MatriculaController()
        {
            _matriculaLogica = new MatriculaLogica();
        }

        public IHttpActionResult Get([FromUri] string CodLinea = null, [FromUri] string CodModalidad = null, [FromUri] string CodAlumno = null, [FromUri] string CodPeriodo = null)
        {
            DTOHeader response = new DTOHeader();
            try
            {
                Validar(CodLinea, CodAlumno);

                response.CodigoRetorno = "Correcto";

                MatriculaFiltro filtro = new MatriculaFiltro
                {
                    CodLineaNegocio = CodLinea,
                    CodModalEst = CodModalidad,
                    CodAlumno = CodAlumno,
                    CodPeriodo = CodPeriodo
                };

                List<Matricula> lista = _matriculaLogica.Listar(filtro, true);
                return Ok(new
                {
                    DTOHeader = response,
                    ListaDTODetMatriculaOBJ = lista.Select(x => new
                    {
                        DTODetMatriculaCab = new
                        {
                            MatriculaId = x.IdMatricula,
                            x.CodLineaNegocio,
                            x.CodModalEst,
                            x.CodPeriodo
                        },
                        ListaDTODetMatriculaDet = x.Detalles.Select(y => new
                        {
                            y.CodProducto,
                            y.Seccion,
                            y.Grupo,
                            DTOCurso = new
                            {
                                y.Curso.CodCurso,
                                y.Curso.DescCurso,
                            }
                        })
                    })
                });
            }
            catch (System.Exception ex)
            {
                response.CodigoRetorno = "Incorrecto";
                response.DescRetorno = ex?.InnerException?.Message ?? ex.Message;
                return Content(System.Net.HttpStatusCode.BadRequest, response);
            }
        }

        public IHttpActionResult Post([FromBody] DTOMatricula entidad)
        {
            DTOHeader response = new DTOHeader();

            try
            {
                Validar(entidad);
                response.CodigoRetorno = "Correcto";

                Matricula _ = entidad.ToMatricula();

                _matriculaLogica.Guardar(_);

                return Ok(new
                {
                    DTOHeader = response,
                    DTOMatriculaId = _.IdMatricula
                });
            }
            catch (System.Exception ex)
            {
                response.CodigoRetorno = "Incorrecto";
                response.DescRetorno = ex?.InnerException?.Message ?? ex.Message;
                return Content(System.Net.HttpStatusCode.BadRequest, response);
            }
        }


        #region Metodos

        [NonAction]
        private void Validar(string CodLinea, string CodAlumno)
        {
            if (string.IsNullOrEmpty(CodLinea)) throw new System.Exception("Es necesario ingresar una linea de negocio.");
            if (!string.IsNullOrEmpty(CodAlumno) && CodAlumno.Length < 9) throw new System.Exception("Es necesario que el codigo de alumno sea mayor a nueve caracteres.");
        }

        [NonAction]
        private void Validar(DTOMatricula entidad)
        {
            if (string.IsNullOrEmpty(entidad.CodLineaNegocio)) throw new System.Exception("Es necesario ingresar una linea de negocio.");
            if (string.IsNullOrEmpty(entidad.CodModalEst)) throw new System.Exception("Es necesario ingresar una modalidad.");
            if (string.IsNullOrEmpty(entidad.CodPeriodo)) throw new System.Exception("Es necesario ingresar un periodo.");
            if (string.IsNullOrEmpty(entidad.CodAlumno)) throw new System.Exception("Es necesario ingresar un codigo de alumno.");
            if (string.IsNullOrEmpty(entidad.UsuarioCreador)) throw new System.Exception("Es necesario ingresar un usuario.");
        }

        #endregion
    }
}
