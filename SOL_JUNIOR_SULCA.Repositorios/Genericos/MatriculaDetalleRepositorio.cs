using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios.Base;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SOL_JUNIOR_SULCA.Repositorios
{
    public class MatriculaDetalleRepositorio : BaseRepositorio<MatriculaDetalle>
    {
        public MatriculaDetalleRepositorio(PruebaContexto contexto) : base(contexto) { }
    
        public List<MatriculaDetalle> Listar(MatriculaDetalleFiltro filtro)
        {
            var source = _contexto.MatriculaDetalle.Include(x => x.Curso).AsQueryable();

            if(filtro != null)
            {
                if (filtro.MatriculaIds != null && filtro.MatriculaIds.Length > 0)
                    source = source.Where(x => filtro.MatriculaIds.Contains(x.MatriculaIdMatricula));
            }

            return source.ToList();
        }
    }
}
