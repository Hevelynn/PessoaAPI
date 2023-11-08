using Microsoft.EntityFrameworkCore;
using PessoaAPI.Models.Pessoa;

namespace PessoaAPI.Data.Context
{
    public class FluentContext : DbContext
    {
        public FluentContext(DbContextOptions<FluentContext> options) : base(options)
        {
            
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<DadosPessoais> DadosPessoais { get; set; }
        public DbSet<CaracteristicasFisicas> CaracteristicasFisicas { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Filiacao> Filiacao { get; set; }
        public DbSet<Online> Online { get; set; }
        public DbSet<Outros> Outros { get; set; }
        public DbSet<Telefones> Telefones { get; set; }


    }
}
