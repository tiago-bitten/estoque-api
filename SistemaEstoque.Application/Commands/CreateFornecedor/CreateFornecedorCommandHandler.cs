using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Application.Commands.CreateFornecedor
{
    public class CreateFornecedorCommandHandler : IRequestHandler<CreateFornecedorCommand, CreateFornecedorResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateFornecedorCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CreateFornecedorResponse> Handle(CreateFornecedorCommand request, CancellationToken cancellationToken)
        {
            var existsFornecedor = await _uow.Fornecedores.GeyByCpfCnpj(request.CpfCnpj);

            if (existsFornecedor != null)
                throw new Exception("Fornecedor já cadastrado");

            var fornecedor = _mapper.Map<Fornecedor>(request);

            await _uow.Fornecedores.AddAsync(fornecedor, EMPRESA_CONSTANTE.ID_EMPRESA);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateFornecedorResponse>(fornecedor);

            return await Task.FromResult(response);
        }
    }
}
