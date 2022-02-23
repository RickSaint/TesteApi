using Aplicacao.ViewModel;
using AutoMapper;
using Dominio.Entidades;

namespace WebAPI.Config
{
    // Aqui fazemos o mapeamento de um objeto trasnferindo para outro
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
        }
    }
}
