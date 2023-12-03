using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using Microsoft.EntityFrameworkCore;

namespace eclipseworks_teste.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>
    {
        public TarefaRepository(EclipseContext ctx) : base(ctx)
        {
            
        }

        public int CountPerProject(long projectId) {
            return Db.Set<Tarefa>().Count(x => x.CodProjeto == projectId);
        }
    }
}
