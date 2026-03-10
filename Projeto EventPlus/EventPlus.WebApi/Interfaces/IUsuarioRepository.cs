using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha(string Email,string Senha);
    }
}
