using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using Microsoft.EntityFrameworkCore;

namespace eclipseworks_teste.Repositories
{
    public class ProjetoRepository : BaseRepository<Projeto>
    {
        public ProjetoRepository(EclipseContext ctx) : base(ctx)
        {
            
        }

        public IList<Projeto> GetByUserId(long userId) {
            return Db.Set<Projeto>().Where(x => x.CodUsuario == userId).OrderByDescending(x=>x.CodProjeto).ToList();
        }

        public IList<Projeto> GetAllProjetos()
        {
            return Db.Set<Projeto>().OrderByDescending(x => x.CodProjeto).ToList();
        }

    }
}
