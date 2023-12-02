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
    }
}
