using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces
{
    public interface IPresencaRepository
    {
        void Inscrever(Presenca inscricao);

        void Deletar(Guid id);

        List<Presenca> Listar();

        Presenca BuscarPorId(Guid id);

        void Atualizar(Guid id);

        List<Presenca> ListarMinhas(Guid IdUsuario);
    }
}
