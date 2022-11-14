using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiBase.Models
{
    public class Respuesta<T>
    {
        public int Ok { get; set; }
        [JsonIgnore]
        public List<T> Data { get; set; } = new List<T>();
        public string? Message { get; set; }
    }
   
}