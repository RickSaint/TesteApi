using Aplicacao.Service;
using Aplicacao.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : Controller
    {
        private readonly ILogger<ContatoController> _logger;
        private readonly IContatoService _contatoService;
        /// <summary>
        /// Construtor por injetar a interface do serviço do contato
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="contatoService"></param>
        public ContatoController(ILogger<ContatoController> logger, IContatoService contatoService)
        {
            _logger = logger;
            _contatoService = contatoService;
        }

        /// <summary>
        /// Endpoint responsavel por busca todos os contatos
        /// </summary>
        /// <returns>Todos contatos</returns>
        [HttpGet]
        public async Task<IEnumerable<ContatoViewModel>> GetAll()
        {
            return await _contatoService.GetAll();
        }

        /// <summary>
        /// Endpoint que é responsavel por busca um contato de acordo ao Id
        /// </summary>
        /// <param name="id">Id do contato</param>
        /// <returns>Contato especifico</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> RetornaPorId(int id)
        {
            var result = await _contatoService.RetornaPorId(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Registro não encontrado");
        }

        /// <summary>
        /// Endpoint responsavel pela criação do novo contato
        /// </summary>
        /// <param name="viewModel">Novo contato</param>
        /// <returns>Mensagem de criado</returns>
        [HttpPost]
        public IActionResult Post([FromBody] ContatoViewModel viewModel)
        {
            var model = _contatoService.Incluir(viewModel).Result;

            if (model != null && String.IsNullOrEmpty(model.MsgErro))
                return Ok(model);
            else
                return BadRequest(model.MsgErro);
        }

        /// <summary>
        /// Endpoint que é responsavel pela atualização do contato
        /// </summary>
        /// <param name="viewModel">Contato atualizado</param>
        /// <returns>msg de atualizado e contato atualizado</returns>
        [HttpPut]
        public IActionResult Put([FromBody] ContatoViewModel viewModel)
        {
            var model = _contatoService.Alterar(viewModel).Result;

            if (model != null && model.Valido)
                return Ok(model);
            else
                return BadRequest(model.MsgErro);
        }

        /// <summary>
        /// Endpoint responsavel por excluir o contato
        /// </summary>
        /// <param name="id">Id do contato</param>
        /// <returns>Msg de excluido</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var result = await _contatoService.Excluir(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound(result.MsgErro);
        }

    }
}
