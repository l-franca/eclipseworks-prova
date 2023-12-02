using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using Microsoft.EntityFrameworkCore;

namespace eclipseworks_teste.Repositories
{
    public class HistoricoTarefaRepository : BaseRepository<HistoricoTarefa>
    {
        public HistoricoTarefaRepository(EclipseContext ctx) : base(ctx)
        {
            
        }
    }
}
