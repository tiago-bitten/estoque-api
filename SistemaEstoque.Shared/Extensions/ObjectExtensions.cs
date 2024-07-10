using System.Text.Json;
using System.Text.Json.Serialization;

namespace SistemaEstoque.Shared.Extensions
{
    public static class ObjectExtensions
    {
        public static T DeepClone<T>(this T obj)
        {
            if (obj == null)
                throw new Exception("Objeto não pode ser nulo.");

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IgnoreNullValues = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var json = JsonSerializer.Serialize(obj, options);
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
