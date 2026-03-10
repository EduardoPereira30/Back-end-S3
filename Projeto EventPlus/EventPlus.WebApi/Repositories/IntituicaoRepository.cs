using EventPlus.WebApi.Models;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.BdContextEvent;

namespace EventPlus.WebApi.Repositories
 
{
    public class IntituicaoRepository : IIntituicaoRepository
    {

        private readonly EventContext _context;

        public IntituicaoRepository(EventContext context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Instituicao instituicao)
        {
            var institucaoBuscado = _context.Instituicaos.Find(id);

            if (institucaoBuscado != null)
            {
                institucaoBuscado.NomeFantasia = instituicao.NomeFantasia;

                _context.SaveChanges();

            }
        }

        public Instituicao BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Catastrar(Instituicao instituicao)
        {
            _context.Instituicaos.Add(instituicao);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var institucaoBuscado = _context.Instituicaos.Find(id);

            if (institucaoBuscado != null)
            {
                _context.Instituicaos.Remove(institucaoBuscado);
                _context.SaveChanges();
            }
        }

        public List<Instituicao> Listar()
        {
            return _context.Instituicaos.OrderBy(tipoEvento => tipoEvento.NomeFantasia).ToList();
        }
    }
}
