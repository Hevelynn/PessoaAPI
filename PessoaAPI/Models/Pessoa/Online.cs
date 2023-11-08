using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace PessoaAPI.Models.Pessoa
{
    public class Online
    {
        public Online(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        [Key]
        public int Id { get; set; }
        [JsonPropertyName("nome")]
        public string Email { get; set; }
        [JsonPropertyName("senha")]
        public string Senha { get; set; }
    }
}
