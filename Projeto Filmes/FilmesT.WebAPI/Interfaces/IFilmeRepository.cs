using FilmesT.WebAPI.Models;

namespace FilmesT.WebAPI.Interfaces
{
    public interface IFilmeRepository
    {

        void Cadastrar(Filme novoFilme);

        void AtualizarIdCorpo(Filme filmeAtualizado);

        void AtualizarIdUrl(Guid id, Filme FilmeAtualizado);

        List<Filme> listar();

        void Deletar(Guid id);

        Filme BuscarPorId(Guid id);
    }
}
