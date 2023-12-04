﻿using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;

namespace eclipseworks_teste.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;
        public UsuarioService(EclipseContext context) { 
            _repository = new UsuarioRepository(context);
        }

        public IList<Usuario> ObterTodos() { return _repository.GetAll(); }
        public bool CheckIfGerente(long usuarioId) { return _repository.CheckIfGerente(usuarioId); }

        public Usuario AddUsuario(Usuario usuario) { _repository.Save(usuario); return usuario; }
    }
}