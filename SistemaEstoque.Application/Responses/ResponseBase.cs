using System.Text.Json.Serialization;

namespace SistemaEstoque.Application.Responses
{
    public class ResponseBase<T>
    {
        public bool Sucesso { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Mensagem { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Erros { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T Conteudo { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Total { get; set; }

        public ResponseBase()
        {
            Erros = new List<string>();
        }
    }
}
