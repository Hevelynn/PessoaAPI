using FluentNHibernate.Conventions.Inspections;
using NHibernate.Engine;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cascade = FluentNHibernate.Conventions.Inspections.Cascade;

namespace PessoaAPI.Models.Pessoa
{
    public class Pessoa
    {
        public Pessoa()
        {
                
        }
        public Pessoa(DadosPessoais dadosPessoais, Endereco endereco, Filiacao filiacao, 
            Online online, Outros outros, Telefones telefones, CaracteristicasFisicas caracteristicasFisicas)
        {
            DadosPessoais = dadosPessoais;
            Endereco = endereco;
            Filiacao = filiacao;
            Online = online;
            Outros = outros;
            Telefones = telefones;
            CaracteristicasFisicas = caracteristicasFisicas;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public DadosPessoais DadosPessoais { get; set; }
        [Required]
        public Endereco Endereco { get; set; }
        [Required]
        public Filiacao Filiacao { get; set; }
        [Required]
        public Online Online { get; set; }
        [Required]
        public Outros Outros { get; set; }
        [Required]
        public Telefones Telefones { get; set; }
        [Required]
        public CaracteristicasFisicas CaracteristicasFisicas { get; set; }
    }
}
