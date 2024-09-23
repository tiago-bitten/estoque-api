using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Application.DTOs.Items;

public class GetItemDto : DtoBase
{
    public ETipoItem Tipo { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal? PrecoVendaReferencia { get; set; }
    public decimal? PrecoCustoReferencia { get; set; }
    public int CategoriaId { get; set; } // Criar DTO para Categoria
}