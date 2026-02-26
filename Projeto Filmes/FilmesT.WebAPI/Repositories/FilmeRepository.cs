using FilmesT.WebAPI.BdContextFilme;
using FilmesT.WebAPI.Interfaces;
using FilmesT.WebAPI.Models;
using System.Linq.Expressions;


namespace FilmesT.WebAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly FilmeContext _context;

        public FilmeRepository( FilmeContext    context ) {
        _context = context;

        }
        public void AtualizarIdCorpo(Filme filmeAtualizado)
        {
            try
            {
                Filme FilmeBuscado = _context.Filmes.Find(filmeAtualizado.Idfilme)!;
                if (FilmeBuscado != null)
                {
                    FilmeBuscado.Titulo = filmeAtualizado.Titulo;
                    FilmeBuscado.Idgenero = filmeAtualizado.Idgenero;
                }

                _context.Filmes.Update(FilmeBuscado!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AtualizarIdUrl(Guid id, Filme FilmeAtualizado)
        {
            try
            {
                Filme FilmeBuscado = _context.Filmes.Find(id.ToString())!;
                if(FilmeBuscado != null)
                {
                    FilmeBuscado.Titulo = FilmeAtualizado.Titulo;
                    FilmeBuscado.Idgenero = FilmeAtualizado.Idgenero;

                }

                _context.Filmes.Update( FilmeBuscado!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Filme BuscarPorId(Guid id)
        {
            try
            { Filme FilmeBuscado = _context.Filmes.Find(id.ToString())!;
                return FilmeBuscado;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Cadastrar(Filme novoFilme)
        {
            try {

                novoFilme.Idfilme = Guid.NewGuid().ToString();
                _context.Filmes.Add(novoFilme);
                _context.SaveChanges();
            }
            catch(Exception) 
            {
                throw; 
            }
        }

        public void Deletar(Guid id)
        {

            try
            {
                Filme FilmeBuscado = _context.Filmes.Find(id.ToString())!;
                if(FilmeBuscado != null)
                {
                    _context.Filmes.Remove(FilmeBuscado);
                }
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
                
        }

        public List<Filme> listar()
        {
            try
            {
            List<Filme> listaFilme = _context.Filmes.ToList();
            return listaFilme;
            }
            catch (Exception) { throw; }

        }
    }
}
