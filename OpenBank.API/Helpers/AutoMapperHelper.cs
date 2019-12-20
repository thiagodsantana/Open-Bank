using AutoMapper;
using OpenBank.Domain.Enumerators;
using OpenBank.Domain.Models;
using OpenBank.Domain.ViewModels;
using OpenBank.Repository.External;
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
                    cfg.CreateMap<Transacao, TransacaoVM>()
                        .ForMember(dest => dest.TipoMovimento, opt => opt.MapFrom(src => Utils.GetDescription((EnumTipoMovimento)Enum.ToObject(typeof(EnumTipoMovimento), src.TipoMovimento))));

                    cfg.CreateMap<Conta, ContaVM>();
                    cfg.CreateMap<Conta, DadosContaVM>();
                });
        }

    }
}
