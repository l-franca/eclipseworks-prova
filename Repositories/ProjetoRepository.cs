﻿using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using Microsoft.EntityFrameworkCore;

namespace eclipseworks_teste.Repositories
{
    public interface IProjetoRepository : IBaseRepository<Projeto>
    {
        bool CanBeRemoved(long codProjeto);
        IList<Projeto> GetAllProjetos();
        IList<Projeto> GetByUserId(long userId);
    }

    public class ProjetoRepository : BaseRepository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(EclipseContext ctx) : base(ctx)
        {

        }

        public IList<Projeto> GetByUserId(long userId)
        {
            return Db.Set<Projeto>().Where(x => x.CodUsuario == userId).OrderByDescending(x => x.CodProjeto).ToList();
        }

        public IList<Projeto> GetAllProjetos()
        {
            return Db.Set<Projeto>().OrderByDescending(x => x.CodProjeto).ToList();
        }

        public bool CanBeRemoved(long codProjeto)
        {
            return !Db.Set<Tarefa>().Any(x => x.CodProjeto == codProjeto && x.Status != StatusTarefa.Concluida);
        }

    }
}
