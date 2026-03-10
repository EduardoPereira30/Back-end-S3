using EventPlus.WebApi.BdContextEvent;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _context;

        public TipoEventoRepository (EventContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Atualiza um tipo de evento usando o rastreamento automatico
        /// </summary>
        /// <param name="id">id do tipo a ser atualizado</param> 
        /// <param name="tipoEvento">novos dados do tipo evento</param>

        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            var tipoEventoBuscado = _context.TipoEventos.Find(id);

            if(tipoEventoBuscado != null) 
            {
                tipoEventoBuscado.Titulo = tipoEvento.Titulo;

                _context.SaveChanges();

            }
        }
        /// <summary>
        /// Busca por tipo de evento por id
        /// </summary>
        /// <param name="id">id do tipo evento a ser buscado</param>
        /// <returns>objeto do TioEvento com as informacoes do tipo </returns>
        public TipoEvento BuscarPorId(Guid id)
        {
            return _context.TipoEventos.Find(id)!;

        }
        /// <summary>
        /// cadastra um novo tipo de evnto
        /// </summary>
        /// <param name="tipoEvento"> tipo de evento a ser cadastrado</param>
        public void Catastrar(TipoEvento tipoEvento)
        {
            _context.TipoEventos.Add(tipoEvento);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {

            var tipoEventoBuscado = _context.TipoEventos.Find(id);

            if(tipoEventoBuscado != null)
            {
               _context.TipoEventos.Remove(tipoEventoBuscado);
                _context.SaveChanges();
            }
        }

        public List<TipoEvento> Listar()
        {
            return _context.TipoEventos.OrderBy(tipoEvento => tipoEvento.Titulo).ToList();
        }
    }
}
