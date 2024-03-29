using System.Text.Json.Serialization;

namespace ExoApi.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string? Titulo { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status? Status { get; set; }
        public DateTime DataInicio { get; set; }
        public string? Tecnologia { get; set; }
        public string? Requisito { get; set; }
        public string? Area { get; set; }
                 
    }
}