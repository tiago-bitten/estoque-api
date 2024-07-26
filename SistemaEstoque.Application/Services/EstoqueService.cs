using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class EstoqueService<T> : ServiceBase<T>, IEstoqueService<T> where T : Estoque
    {
        public EstoqueService(IRepositoryBase<T> repository)
            : base(repository)
        {
        }

        public Task UpdateEstoque(T estoque, int quantidade, ETipoMovimentacao tipoMovimentacao)
        {
            var estoqueAtual = estoque.Quantidade;

            if (tipoMovimentacao.Equals(ETipoMovimentacao.Entrada))
            {
                var novaQuantidade = estoqueAtual + quantidade;

                estoque.Quantidade = novaQuantidade;
            }
            else
            {
                var novaQuantidade = estoqueAtual - quantidade;

                if (novaQuantidade < 0 || novaQuantidade < estoque.QuantidadeMinima)
                    throw new Exception("Quantidade inválida");

                estoque.Quantidade = novaQuantidade;
            }

            _repository.Update(estoque);

            return Task.CompletedTask;
        }
    }
}
