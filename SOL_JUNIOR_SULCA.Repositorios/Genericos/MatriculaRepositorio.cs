using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios.Base;
using System.Collections.Generic;
using System.Linq;

namespace SOL_JUNIOR_SULCA.Repositorios
{
    public class MatriculaRepositorio : BaseRepositorio<Matricula>
    {
        public MatriculaRepositorio(PruebaContexto contexto) : base(contexto) { }

        public List<Matricula> Listar(MatriculaFiltro filtro) => Query(filtro).ToList();

        #region Metodos

        private IQueryable<Matricula> Query(MatriculaFiltro filtro)
        {
            IQueryable<Matricula> source = _contexto.Matricula.AsQueryable();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.CodLineaNegocio)) source = source.Where(x => x.CodLineaNegocio == filtro.CodLineaNegocio);
                if (!string.IsNullOrEmpty(filtro.CodModalEst)) source = source.Where(x => x.CodModalEst == filtro.CodModalEst);
                if (!string.IsNullOrEmpty(filtro.CodAlumno)) source = source.Where(x => x.CodAlumno == filtro.CodAlumno);
                if (!string.IsNullOrEmpty(filtro.CodPeriodo)) source = source.Where(x => x.CodPeriodo == filtro.CodPeriodo);
            }

            return source;
        }

        #endregion

    }
}
