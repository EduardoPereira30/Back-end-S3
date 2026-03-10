using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        void Catastrar(TipoUsuario tipoUsuario);

        void Atualizar(Guid id, TipoUsuario TipoUsuario);

        void Deletar(Guid id);

        TipoUsuario BuscarPorId(Guid id);
    }
}
