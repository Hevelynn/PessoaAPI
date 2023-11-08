using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PessoaAPI.Models.Pessoa
{
    public class CaracteristicasFisicas
    {
        public CaracteristicasFisicas(float altura, int peso)
        {
            Altura = altura;
            Peso = peso;
        }

        [Key]
        public int Id { get; set; }
        [JsonPropertyName("altura")]
        public float Altura { get; set; }
        [JsonPropertyName("peso")]
        public int Peso { get; set; }
    }
}
