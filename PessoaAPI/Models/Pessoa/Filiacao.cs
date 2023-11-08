using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PessoaAPI.Models.Pessoa
{
    public class Filiacao
    {
        public Filiacao(string mae, string pai)
        {
            Mae = mae;
            Pai = pai;
        }

        [Key]
        public int Id { get; set; }
        [JsonPropertyName("mae")]
        public string Mae { get; set; }
        [JsonPropertyName("pai")]
        public string Pai { get; set; }
    }
}
