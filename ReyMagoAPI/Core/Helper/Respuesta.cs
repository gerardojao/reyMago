using Newtonsoft.Json;

namespace ReyMagoApi.Core.Helper
{
    public class Respuesta<T>
    {
        public int Ok { get; set; }
        [JsonIgnore]
        public List<T> Data { get; set; } = new List<T>();
        public string? Message { get; set; }
    }
   
}