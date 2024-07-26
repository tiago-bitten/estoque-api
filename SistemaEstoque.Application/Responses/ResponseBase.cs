using System.Text.Json.Serialization;

namespace SistemaEstoque.Application.Responses
{
    public class ResponseBase<T>
    {
        [JsonPropertyName("Sucesso")]
        public bool Sucesso { get; set; }

        [JsonPropertyName("Mensagem")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Mensagem { get; set; }

        [JsonPropertyName("Erros")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Erros { get; set; }

        [JsonPropertyName("Conteudo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T Conteudo { get; set; }
        
        [JsonPropertyName("Total")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Total { get; set; }

        public ResponseBase()
        {
            Erros = new List<string>();
        }
    }
}
