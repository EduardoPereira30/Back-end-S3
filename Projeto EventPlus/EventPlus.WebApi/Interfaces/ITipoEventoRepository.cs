using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces
{
    public interface ITipoEventoRepository
    {
        List<TipoEvento> Listar();

        void Catastrar(TipoEvento tipoEvento);

        void Atualizar (Guid id, TipoEvento tipoEvento);

        void Deletar(Guid id);

        TipoEvento BuscarPorId(Guid id);
    }
}
