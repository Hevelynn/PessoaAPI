using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PessoaAPI.Models.Pessoa
{
    public class Telefones
    {
        public Telefones(string telefoneFixo, string celular)
        {
            TelefoneFixo = telefoneFixo;
            Celular = celular;
        }

        [Key]
        public int Id { get; set; }
        [JsonPropertyName("telefone_fixo")]
        public string TelefoneFixo { get; set; }
        [JsonPropertyName("celular")]
        public string Celular { get; set; }
    }
}
