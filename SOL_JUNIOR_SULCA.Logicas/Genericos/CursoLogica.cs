using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios;
using System.Collections.Generic;

namespace SOL_JUNIOR_SULCA.Logicas
{
    public class CursoLogica
    {
        private PruebaContexto _contexto;
        private CursoRepositorio _repositorio;

        public List<Curso> Listar()
        {
            using (_contexto = new PruebaContexto())
            {
                _repositorio = new CursoRepositorio(_contexto);
                return _repositorio.GetAll();
            }
        }

    }
}
