using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces
{
    public interface IIntituicaoRepository
    {

        List<Instituicao> Listar();

        void Catastrar(Instituicao instituicao);

        void Atualizar(Guid id, Instituicao instituicao);

        void Deletar(Guid id);

        Instituicao BuscarPorId(Guid id);
    }
}
