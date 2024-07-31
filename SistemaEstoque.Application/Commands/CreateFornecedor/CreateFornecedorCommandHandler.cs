using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateFornecedor
{
    public class CreateFornecedorCommandHandler : IRequestHandler<CreateFornecedorCommand, CreateFornecedorResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateFornecedorCommandHandler(IUnitOfWork uow, IMapper mapper, ICurrentUserService currentUserService)
        {
            _uow = uow;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<CreateFornecedorResponse> Handle(CreateFornecedorCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _currentUserService.GetUsuario();
            var empresa = await _currentUserService.GetEmpresa();
            
            /**if (!usuario.PerfilAcesso.PermissaoFornecedor.Criar)
                throw new UnauthorizedAccessException("Usuário não tem permissão para criar fornecedores");**/
            
            var existsFornecedor = await _uow.Fornecedores.FindAsync(x => x.CpfCnpj == request.CpfCnpj);

            if (existsFornecedor != null)
                throw new Exception("Fornecedor já cadastrado");

            var fornecedor = _mapper.Map<Fornecedor>(request);
            fornecedor.Empresa = empresa;

            await _uow.Fornecedores.AddAsync(fornecedor, empresa.Id);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateFornecedorResponse>(fornecedor);

            return await Task.FromResult(response);
        }
    }
}
