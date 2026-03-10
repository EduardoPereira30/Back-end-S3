using EventPlus.WebApi.BdContextEvent;
using EventPlus.WebApi.Models;
using EventPlus.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace EventPlus.WebApi.Repositories;
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        private readonly EventContext _context;

        public TipoUsuarioRepository(EventContext context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TipoUsuario TipoUsuario)
        {
            var tipoUsuarioBuscado = _context.TipoUsuarios.Find(id);

            if (tipoUsuarioBuscado != null)
            {
                tipoUsuarioBuscado.Titulo = TipoUsuario.Titulo;

                _context.SaveChanges();

            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            return _context.TipoUsuarios.Find(id)!;
        }

        public void Catastrar(TipoUsuario tipoUsuario)
        {
            _context.TipoUsuarios.Add(tipoUsuario);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var tipoUsurioBuscado = _context.TipoUsuarios.Find(id);

            if (tipoUsurioBuscado != null)
            {
                _context.TipoUsuarios.Remove(tipoUsurioBuscado);
                _context.SaveChanges();
            }
        }

        public List<TipoUsuario> Listar()
        {
            return _context.TipoUsuarios.OrderBy(tipoUsuario => tipoUsuario.Titulo).ToList();
        }
    }

