using AutoMapper;
using SistemaEstoque.Application.Commands.CreateLote;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class LoteProfile : Profile
    {
        public LoteProfile()
        {
            CreateMap<CreateLoteCommand, Lote>();

            CreateMap<Lote, CreateLoteResponse>();
        }
    }
}
