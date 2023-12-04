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

        public IList<Tarefa> GetAllByProject(long projectId)
        {
            return Db.Set<Tarefa>().Where(x => x.CodProjeto == projectId).ToList();
        }

        public IList<Tarefa> GetTarefasPorUsuario30dias(long usuarioId) {
            return Db.Set<Tarefa>().Where(x => x.CodUsuario == usuarioId && x.Status == StatusTarefa.Concluida && x.HistoricoTarefa.Any(y => y.DataModificacao > DateTime.Now.AddDays(-30))).ToList();
        }
    }
}
