using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace SOL_JUNIOR_SULCA.Logicas
{
    public class MatriculaLogica
    {
        private PruebaContexto _contexto;
        private MatriculaRepositorio _repositorio;

        public List<Matricula> Listar(MatriculaFiltro filtro, bool conDetalles = false)
        {
            using (_contexto = new PruebaContexto())
            {
                _repositorio = new MatriculaRepositorio(_contexto);
                MatriculaDetalleRepositorio matriculaDetalleRepositorio = new MatriculaDetalleRepositorio(_contexto);
                
                List<Matricula> lista = _repositorio.Listar(filtro);

                if (lista.Count > 0 && conDetalles)
                {
                    int[] ids = lista.Select(x => x.IdMatricula).ToArray();
                    List<MatriculaDetalle> detalles = matriculaDetalleRepositorio.Listar(new MatriculaDetalleFiltro { MatriculaIds = ids });
                    lista.ForEach(x => x.Detalles = detalles.Where(y => y.MatriculaIdMatricula == x.IdMatricula).ToList());
                }

                return lista;
            }
        }

        public void Guardar(Matricula entidad)
        {
            using (_contexto = new PruebaContexto())
            {
                _repositorio = new MatriculaRepositorio(_contexto);
                entidad.FechaCreacion = System.DateTime.Now;
                _repositorio.Save(entidad);
                _contexto.SaveChanges();
            }
        }

        public void Guardar(MatriculaDetalle entidad)
        {
            using (_contexto = new PruebaContexto())
            {
                _repositorio = new MatriculaRepositorio(_contexto);
                CursoRepositorio cursoRepositorio = new CursoRepositorio(_contexto);
                MatriculaDetalleRepositorio matriculaDetalleRepositorio = new MatriculaDetalleRepositorio(_contexto);

                //TODO: Validar el identificador de la matricula
                if (_repositorio.CountBy(x => x.IdMatricula == entidad.MatriculaIdMatricula) == 0) throw new System.Exception("El identificador de la matricula no existe");

                //TODO: Validar el identificador del curso
                if (cursoRepositorio.CountBy(x => x.CodCurso == entidad.CursoCodCurso && x.CodLineaNegocio == entidad.CursoCodLineaNegocio) == 0) throw new System.Exception("El identificador del curso no existe");

                matriculaDetalleRepositorio.Save(entidad);

                _contexto.SaveChanges();
            }
        }

    }
}
