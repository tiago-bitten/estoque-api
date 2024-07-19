using AutoMapper;
using SistemaEstoque.Application.Commands.CreateLote;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class LoteProfile : Profile
    {
        public LoteProfile()
        {
            CreateMap<CreateLoteCommand, Lote>();

            CreateMap<Lote, CreateLoteResponse>();

            CreateMap<Lote, LoteDTO>();
        }
    }
}
