using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PessoaAPI.Models.Pessoa
{
    public class Outros
    {
        public Outros(string tipoSanguineo, string corFavorita)
        {
            TipoSanguineo = tipoSanguineo;
            CorFavorita = corFavorita;
        }

        [Key]
        public int Id { get; set; }
        [JsonPropertyName("tipo_sanguineo")]
        public string TipoSanguineo { get; set; }
        [JsonPropertyName("cor")]
        public string CorFavorita { get; set; }
    }
}
