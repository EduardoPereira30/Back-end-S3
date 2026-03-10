using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces
{
    public interface IEventoRepository
    {
        List<Evento> Listar();
            
        void Catastrar(Evento evento);

        void Deletar(Guid idEvento);
        
        void Atualizar(Guid id, Evento evento);
        List<Evento> ListaPorId(Guid id);

        List<Evento> ProximosEventos();

        Evento BuscarPorId(Guid id);
    }
}