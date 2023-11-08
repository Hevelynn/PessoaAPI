using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PessoaAPI.Models.Pessoa
{
    public class DadosPessoais
    {
        public DadosPessoais(string nome, int idade, string cPF, string rG, string dataNascimento, string sexo, string signo)
        {
            Nome = nome;
            Idade = idade;
            CPF = cPF;
            RG = rG;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Signo = signo;
        }
        
        [JsonPropertyName("nome")]
        [Required]
        public string Nome { get; set; }
        [JsonPropertyName("idade")]
        public int Idade { get; set; }
        [Key]
        [JsonPropertyName("cpf")]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; set; }
        [JsonPropertyName("rg")]
        public string RG { get; set; }
        [JsonPropertyName("data_nasc")]
        public string DataNascimento { get; set; }
        [JsonPropertyName("sexo")]
        public string Sexo { get; set; }
        [JsonPropertyName("signo")]
        public string Signo { get; set; }

    }
}
