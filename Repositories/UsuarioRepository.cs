using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using Microsoft.EntityFrameworkCore;

namespace eclipseworks_teste.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(EclipseContext ctx) : base(ctx)
        {
            
        }

        public bool CheckIfGerente(long usuarioId) {
            return Db.Set<Usuario>().Any(x => x.CodUsuario == usuarioId && x.Cargo == CargoUsuario.Gerente);
        }
    }
}
