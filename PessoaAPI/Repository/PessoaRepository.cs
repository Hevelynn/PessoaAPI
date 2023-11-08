using Microsoft.EntityFrameworkCore;
using PessoaAPI.Data.Context;
using PessoaAPI.Models.Pessoa;

namespace PessoaAPI.Repository
{
    public class PessoaRepository
    {
        private FluentContext _fluentContext;
        public PessoaRepository(FluentContext fluentContext)
        {
            _fluentContext = fluentContext;
        }
        public List<Pessoa> ConsulteLista()
        {
            return _fluentContext.Pessoas.ToList();
        }
        public Pessoa ConsultarPorCPF(string cpf)
        {
            var _pessoa = BuscarPessoa(cpf);
            return _pessoa;
        }
        public List<Pessoa> ConsultarPorCEP(int cep)
        {
            var _pessoa = _fluentContext.Pessoas.Where(p => p.Endereco.CEP == cep.ToString()).ToList();
            return _pessoa;
        }        
        public Pessoa CadastrarPessoa(Pessoa pessoa)
        {
            _fluentContext.Pessoas.Add(pessoa);
            _fluentContext.SaveChanges();
            return pessoa;
        }
        public Pessoa AtualizarPessoa(Pessoa pessoa)
        {
            var _pessoa = BuscarPessoa(pessoa.DadosPessoais.CPF);

            if (_pessoa != null)
            {
                _pessoa.CaracteristicasFisicas.Altura = pessoa.CaracteristicasFisicas.Altura;
                _pessoa.CaracteristicasFisicas.Peso = pessoa.CaracteristicasFisicas.Peso;

                _pessoa.DadosPessoais.CPF = pessoa.DadosPessoais.CPF;
                _pessoa.DadosPessoais.Signo = pessoa.DadosPessoais.Signo;
                _pessoa.DadosPessoais.Sexo = pessoa.DadosPessoais.Sexo;
                _pessoa.DadosPessoais.Idade = pessoa.DadosPessoais.Idade;
                _pessoa.DadosPessoais.Nome = pessoa.DadosPessoais.Nome;
                _pessoa.DadosPessoais.RG = pessoa.DadosPessoais.RG;
                _pessoa.DadosPessoais.DataNascimento = pessoa.DadosPessoais.DataNascimento;

                _pessoa.Endereco.Numero = pessoa.Endereco.Numero;
                _pessoa.Endereco.Cidade = pessoa.Endereco.Cidade;
                _pessoa.Endereco.Estado = pessoa.Endereco.Estado;
                _pessoa.Endereco.Logradouro = pessoa.Endereco.Logradouro;
                _pessoa.Endereco.CEP = pessoa.Endereco.CEP;
                _pessoa.Endereco.Bairro = pessoa.Endereco.Bairro;

                _pessoa.Filiacao.Mae = pessoa.Filiacao.Mae;
                _pessoa.Filiacao.Pai = pessoa.Filiacao.Pai;

                _pessoa.Online.Senha = pessoa.Online.Senha;
                _pessoa.Online.Email = pessoa.Online.Email;

                _pessoa.Outros.CorFavorita = pessoa.Outros.CorFavorita;
                _pessoa.Outros.TipoSanguineo = pessoa.Outros.TipoSanguineo;

                _pessoa.Telefones.TelefoneFixo = pessoa.Telefones.TelefoneFixo;
                _pessoa.Telefones.Celular = pessoa.Telefones.Celular;

                _fluentContext.Pessoas.Update(_pessoa);
                _fluentContext.SaveChanges();
            }
            return _pessoa;
        }
        public Pessoa ExcluirPessoa(string cpf)
        {
            var pessoa = BuscarPessoa(cpf);
            if (pessoa == null)
            {
                return null;
            }

            ExcluirCaracteristicasFisicas(pessoa.CaracteristicasFisicas);
            ExcluirDadosPessoais(pessoa.DadosPessoais);
            ExcluirEndereco(pessoa.Endereco);
            ExcluirFiliacao(pessoa.Filiacao);
            ExcluirOnline(pessoa.Online);
            ExcluirOutros(pessoa.Outros);
            ExcluirTelefones(pessoa.Telefones);

            _fluentContext.Pessoas.Remove(pessoa);
            _fluentContext.SaveChanges();

            return pessoa;
        }
        private void ExcluirTelefones(Telefones telefones)
        {
            _fluentContext.Telefones.Remove(telefones);
        }
        private void ExcluirOutros(Outros outros)
        {
            _fluentContext.Outros.Remove(outros);
        }
        private void ExcluirOnline(Online online)
        {
            _fluentContext.Online.Remove(online);
        }
        private void ExcluirFiliacao(Filiacao filiacao)
        {
            _fluentContext.Filiacao.Remove(filiacao);
        }
        private void ExcluirEndereco(Endereco endereco)
        {
            _fluentContext.Endereco.Remove(endereco);
        }
        private void ExcluirCaracteristicasFisicas(CaracteristicasFisicas caracteristicasFisicas)
        {
            _fluentContext.CaracteristicasFisicas.Remove(caracteristicasFisicas);
        }
        private void ExcluirDadosPessoais(DadosPessoais dadosPessoais)
        {
            _fluentContext.DadosPessoais.Remove(dadosPessoais);
        }
        private Pessoa BuscarPessoa(string cpf)
        {
            return _fluentContext.Pessoas
                            .Include(p => p.DadosPessoais)
                            .Include(p => p.CaracteristicasFisicas)
                            .Include(p => p.Endereco)
                            .Include(p => p.Filiacao)
                            .Include(p => p.Online)
                            .Include(p => p.Outros)
                            .Include(p => p.Telefones)
                            .FirstOrDefault(p => p.DadosPessoais.CPF == cpf);
        }
    }
}
