﻿using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using Microsoft.EntityFrameworkCore;

namespace eclipseworks_teste.Repositories
{
    public class HistoricoTarefaRepository : BaseRepository<HistoricoTarefa>
    {
        public HistoricoTarefaRepository(EclipseContext ctx) : base(ctx)
        {
            
        }

        public IList<HistoricoTarefa> GetAllComentarios(long tarefaId) { 
            return Db.Set<HistoricoTarefa>().Where(x=>x.CodTarefa==tarefaId && x.StatusHistorico == StatusHistorico.Comentario).OrderByDescending(x=>x.DataModificacao).ToList();
        }

        public IList<HistoricoTarefa> GetAllUpdates(long tarefaId)
        {
            return Db.Set<HistoricoTarefa>().Where(x => x.CodTarefa == tarefaId && x.StatusHistorico != StatusHistorico.Comentario).OrderByDescending(x => x.DataModificacao).ToList();
        }
    }
}
