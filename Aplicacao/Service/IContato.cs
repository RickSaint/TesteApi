using Aplicacao.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Aplicacao.Service
{
    // Interface da entidade contato, nela temos os contratos de operações que será 
    // obrigatorio a implementação delas no serviço da entidade.
    public interface IContatoService
    {
        Task<IEnumerable<ContatoViewModel>> GetAll();
        Task<ContatoViewModel> RetornaPorId(int id);
        Task<ContatoViewModel> Incluir(ContatoViewModel obj);
        Task<ContatoViewModel> Alterar(ContatoViewModel obj);
        Task<ContatoViewModel> Excluir(int id);
    }

}