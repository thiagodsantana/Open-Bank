using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBank.API.Helpers
{
    public static class AutoMapperHelper
    {
        public static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
                {
                    //cfg.CreateMap<Parametro, ParametroVM>();
                    //cfg.CreateMap<TipoCategoria, TipoCategoriaVM>();
                    //cfg.CreateMap<Categoria, CategoriaVM>();
                    //cfg.CreateMap<Parceiro, ParceiroVM>();
                    //cfg.CreateMap<MidiaParceiro, MidiaParceiroVM>();
                    //cfg.CreateMap<Cidade, CidadeVM>()
                    //  .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Descricao))
                    //  .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.Sigla));
                });
        }

    }
}
