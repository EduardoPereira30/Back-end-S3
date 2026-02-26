using FilmesT.WebAPI.BdContextFilme;
using FilmesT.WebAPI.Controllers;
using FilmesT.WebAPI.Interfaces;
using FilmesT.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesT.WebAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {

        private readonly FilmeContext _context;

        public GeneroRepository( FilmeContext context)
        {
            _context = context;
        }

        public void AtualizarIdCorpo(Genero generoAtualizado)
        {
            try
            {
                Genero generoBuscado = _context.Generos.Find(generoAtualizado.Idgenero.ToString());
                if(generoBuscado != null)
                {
                    generoBuscado.Nome = generoAtualizado.Nome;

                }
                _context.Generos.Update(generoBuscado);
                _context.SaveChanges();
            }
            catch (Exception) 
            {
                throw;
            }
            ;
        }
        public void AtualizarIdUrl(Guid id, Genero GeneroAtualizado)
        {
           try
            {
                Genero generoBuscado = _context.Generos.Find(id.ToString());
                
                if (generoBuscado != null)
                {
                    generoBuscado.Nome = GeneroAtualizado.Nome;
                }
                _context.Generos.Update(generoBuscado);
                _context.SaveChanges();
            }catch(Exception)
            {
                throw;
            }
            ;
        }

        public Genero BuscarPorId(Guid id)
        {
            try
            {
                Genero generoBuscado = _context.Generos.Find(id.ToString());
                return generoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Genero novoGenero)
        {

            try {_context.Generos.Add(novoGenero);
                novoGenero.Idgenero = Guid.NewGuid().ToString();

            _context.SaveChanges(); }
            catch (Exception) 
            {
                throw; 
            }
            
        }

        public void Cadastrar(GeneroController novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Genero generoBuscado = _context.Generos.Find(id.ToString());

                if (generoBuscado != null)
                {
                _context.Generos.Remove(generoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Genero> listar()
        {
            try
            {
                List<Genero> ListaGeneros =
                    _context.Generos.ToList();
                return ListaGeneros;
            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}
