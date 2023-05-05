using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Logicas;
using SOL_JUNIOR_SULCA.WebAPI.Models;
using System.Web.Http;

namespace SOL_JUNIOR_SULCA.WebAPI.Controllers
{
    [Route("v2/MatriculasDetalle")]
    public partial class MatriculaDetalleController : ApiController
    {
        private readonly MatriculaLogica _matriculaLogica;

        public MatriculaDetalleController()
        {
            _matriculaLogica = new MatriculaLogica();
        }

        public IHttpActionResult Post([FromBody] DTOMatriculaDetalle entidad)
        {
            DTOHeader response = new DTOHeader();
            try
            {
                Validar(entidad);

                MatriculaDetalle _ = entidad.ToMatriculaDetalle();
                _matriculaLogica.Guardar(_);

                response.CodigoRetorno = "Correcto";
                response.DescRetorno = "Se registro el detalle";

                return Ok(new
                {
                    DTOHeader = response,
                });
            }
            catch (System.Exception ex)
            {
                response.CodigoRetorno = "Incorrecto";
                response.DescRetorno =  ex.Message;
                return Content(System.Net.HttpStatusCode.BadRequest, response);
            }
        }


        #region Metodos

        [NonAction]
        private void Validar(DTOMatriculaDetalle entidad)
        {
            if (string.IsNullOrEmpty(entidad.CodProducto)) throw new System.Exception("Es necesario ingresar el producto.");
            if (!entidad.MatriculaIdMatricula.HasValue) throw new System.Exception("Es necesario ingresar el identificador del usuario.");
            if (string.IsNullOrEmpty(entidad.CursoCodLineaNegocio)) throw new System.Exception("Es necesario ingresar la linea de negocio.");
            if (string.IsNullOrEmpty(entidad.CursoCodCurso)) throw new System.Exception("Es necesario ingresar el curso.");

            if (string.IsNullOrEmpty(entidad.Seccion)) throw new System.Exception("Es necesario ingresar la seccion.");
            if (string.IsNullOrEmpty(entidad.Grupo)) throw new System.Exception("Es necesario ingresar el grupo.");

            if (string.IsNullOrEmpty(entidad.UsuarioCreador)) throw new System.Exception("Es necesario ingresar un usuario.");
        }


        #endregion
    }
}
