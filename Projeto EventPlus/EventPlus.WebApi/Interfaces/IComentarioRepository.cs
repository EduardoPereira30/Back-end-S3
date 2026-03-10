using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces
{
    public interface IComentarioRepository
    {

        void Catastrar(Comentario comentario);

        void Deletar(Guid id);

        List<Comentario> Listar(Guid IdEvento);

        Comentario BuscarPorIdDoUsuario(Guid idEvento,Guid IdUsuario);

        List<Comentario> ListarSomenteExibe(Guid idEvento);
    }
}
