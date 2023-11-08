using PessoaAPI.Data.Context;
using PessoaAPI.Models.Pessoa;
using PessoaAPI.Repository;

namespace PessoaAPI.Services;

public class PessoaService
{
    private readonly PessoaRepository _pessoaRepository;
    private readonly FluentContext _FluentContext;

    public PessoaService(FluentContext context, PessoaRepository pessoaRepository)
    {
        _FluentContext = context;
        _pessoaRepository = pessoaRepository;
    }

    public List<Pessoa> ConsulteLista()
    {
        return _pessoaRepository.ConsulteLista();
    }
    public Pessoa ConsultarPorCPF(string cpf)
    {
        cpf = FormatarCPF(cpf);
        return _pessoaRepository.ConsultarPorCPF(cpf);
    }

    public List<Pessoa> ConsultarPorCEP(int cep)
    {
        return _pessoaRepository.ConsultarPorCEP(cep);
    }
    public Pessoa CadastrarPessoa(Pessoa pessoa)
    {
        pessoa.DadosPessoais.CPF = FormatarCPF(pessoa.DadosPessoais.CPF);
        return _pessoaRepository.CadastrarPessoa(pessoa);
    }

    public Pessoa AtualizarPessoa(Pessoa pessoa)
    {
        pessoa.DadosPessoais.CPF = FormatarCPF(pessoa.DadosPessoais.CPF);
        return _pessoaRepository.AtualizarPessoa(pessoa);
    }

    public Pessoa ExcluirPessoa(string cpf)
    {
        cpf = FormatarCPF(cpf);
        return _pessoaRepository.ExcluirPessoa(cpf);
    }

    private string FormatarCPF(string cpf) // 123.456.789-00
    {
        return null;
            //; retirar . e -
    }
}
