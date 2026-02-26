using FilmesT.WebAPI.Controllers;
using FilmesT.WebAPI.Models;

namespace FilmesT.WebAPI.Interfaces;

public interface IGeneroRepository
   {

    void Cadastrar(Genero novoGenero);

    void AtualizarIdCorpo(Genero generoAtualizado);

    void AtualizarIdUrl(Guid id,Genero GeneroAtualizado);

    List<Genero> listar();

    void Deletar(Guid id);

    Genero BuscarPorId(Guid id);
}
