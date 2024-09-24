using System.Text.Json.Serialization;

namespace SistemaEstoque.Application.DTOs
{
    public class CategoriaDto
    {
        [JsonPropertyName("Id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int Id { get; set; }
        
        [JsonPropertyName("Nome")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Nome { get; set; }
        
        [JsonPropertyName("Descricao")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Descricao { get; set; }
        
        [JsonPropertyName("TipoItem")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TipoItem { get; set; }
    }
}
