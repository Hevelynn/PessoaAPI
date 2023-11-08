using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PessoaAPI.Models.Pessoa
{
    public class Endereco
    {
        public Endereco(string cEP, string logradouro, int numero, string bairro, string cidade, string estado)
        {
            CEP = cEP;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        [Key]
        public int Id { get; set; }
        [JsonPropertyName("cep")]
        public string CEP { get; set; }
        [JsonPropertyName("endereco")]
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
