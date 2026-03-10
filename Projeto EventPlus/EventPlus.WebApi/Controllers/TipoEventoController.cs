using EventPlus.WebApi.DTO;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.Models;
using EventPlus.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _TipoEventoRepository;

        public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
        {
            _TipoEventoRepository = tipoEventoRepository;
        }
        /// <summary>
        /// Endpoint da API que faz chamada para o metodo de listar os tipos de evento
        /// </summary>
        /// <returns>Status code 200 e a lista de tipos de evento</returns>
        [HttpGet]

        public ActionResult Listar()
        {
            try
            {
                return Ok(_TipoEventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult BuscaPorId(Guid id)
        {
            try
            {
                return Ok(_TipoEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz a chamada para o método de cadastrar um tipo de evento
        /// </summary>
        /// <param name="tipoEvento">Tipo de evento a ser cadastrado</param>
        /// <returns>Status code 201 e o tipo de evento cadastrado</returns>
        /// 
        [HttpPost]

        public ActionResult Cadastrar(TipoEventoDTO tipoEvento) {
            try
            {
                var novoTipoEvento = new TipoEvento
                {
                    Titulo = tipoEvento.Titulo!,
                };
                _TipoEventoRepository.Catastrar(novoTipoEvento);
                return StatusCode(201, novoTipoEvento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz a chamada para o método de Atualizar um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo de evento a ser atualizado</param>
        /// <param name="tipoEvento">Tipo de evento com os dados atualizados</param>
        /// <returns>Status code 204 e o tipo de evento atualizado</returns>
        [HttpPut("{id}")]

        public IActionResult Atualizar(Guid id, TipoEvento tipoEvento) {
            try
            {
                _TipoEventoRepository.Atualizar(id, tipoEvento);
                return StatusCode(204, tipoEvento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Endpoint da API que faz a chamada para o método de Deletar um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo do evento a ser excluído</param>
        /// <returns>Status Code 204</returns>

        [HttpDelete ("{id}")]

        public IActionResult Delete(Guid id) {
            try
            {
                _TipoEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
                
            }

        }

    }
}
