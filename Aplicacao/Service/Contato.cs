using Aplicacao.ViewModel;
using AutoMapper;
using Dominio.Entidades;
using Infraestrutura.Data.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Service
{
    // Classe que gerencia o serviço do contato e ela é herdado a interface especifica do contato.
    // A interface tem definição das operações que o cantato deve implementar
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly ILogger<IContatoService> _logger;
        private readonly IMapper _mapper;

        public ContatoService(ILogger<IContatoService> logger,
            IMapper mapper,
            IContatoRepository cadastroTesteRepository)
        {
            _contatoRepository = cadastroTesteRepository;
            _logger = logger;
            _mapper = mapper;
        }

        // Método que busca todos contatos
        // onde a propriedade é igual a true(verdadeiro)
        public async Task<IEnumerable<ContatoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ContatoViewModel>>(_contatoRepository.AsQueryable().Where(p => p.IsAtivo == true));
        }
        // Método que busca a entidade
        // contato de acordo com Id passado no parametro
        public async Task<ContatoViewModel> RetornaPorId(int id)
        {
            var retorno = await _contatoRepository.AsQueryable().Where(p => p.Id == id && p.IsAtivo == true).FirstOrDefaultAsync();
            return _mapper.Map<ContatoViewModel>(retorno);
        }
        // Método que cria o contato e pesiste ele no banco de dados
        // Nele validamos a idade do contato cadastrado e validamos o dados 
        // passados.
        public async Task<ContatoViewModel> Incluir(ContatoViewModel obj)
        {
            var objRetorno = new ContatoViewModel();

            obj.Idade = Validation.ValidarContato.CalcularIdade(obj);
            var validacaoDados = Validation.ValidarContato.ValidarDados(obj);

            if (!validacaoDados.Valido)
                objRetorno.MsgErro = "Erro ao incluir dados! " + validacaoDados.Erro;
            else
            {
                try
                {
                    var objInc = _mapper.Map<Contato>(obj);
                    var testeInc = await _contatoRepository.Insert(objInc);
                    objRetorno = _mapper.Map<ContatoViewModel>(objInc);
                }
                catch (Exception ex)
                {
                    objRetorno.MsgErro = "Erro ao incluir dados! " + ex.Message;
                }
            }

            return objRetorno;
        }
        // Método que excluimos a entidade de acordo com id passado 
        // no parametro
        public async Task<ContatoViewModel> Excluir(int id)
        {
            var retorno = new ContatoViewModel();

            try
            {
                var obj = _contatoRepository.SelectById(id).Result;

                if (obj == null)
                {
                    retorno.Valido = false;
                    retorno.MsgErro = "Contato não encontrado!";
                }
                else
                {
                    _contatoRepository.Delete(obj);
                    retorno.Valido = true;
                    await _contatoRepository.Commit();
                }
            }
            catch (Exception ex)
            {
                retorno.Valido = false;
                retorno.MsgErro = "Erro ao excluir Contato! " + ex.Message;

            }

            return retorno;
        }

        // Método que faz update da entidade
        public async Task<ContatoViewModel> Alterar(ContatoViewModel obj)
        {
            try
            {
                var objAlt = _mapper.Map<Contato>(obj);
                await _contatoRepository.Update(objAlt);
                await _contatoRepository.Commit();
                obj.Valido = true;
            }
            catch (Exception ex)
            {
                obj.Valido = false;
                obj.MsgErro = "Erro ao incluir dados! " + ex.Message;
            }

            return obj;
        }
    }
}
