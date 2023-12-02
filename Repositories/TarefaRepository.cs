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
    }
}
