using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PessoaAPI.Models;
using PessoaAPI.Services;
using PessoaAPI.Models.Pessoa;
using System.ComponentModel.DataAnnotations;

namespace PessoaAPI.Controllers
{
    [Route("api/Pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService _pessoaService;

        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost]
        [Route("Autenticacao")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticacao([FromBody] Usuario model)
        {
            UsuarioService usuarioService = new UsuarioService();

            Usuario usuario = usuarioService.GetUsuario(model.NomeUsuario, model.Senha);

            if (usuario == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            string token = TokenService.GerarToken(usuario);

            return new
            {
                token
            };
        }

        [HttpGet]
        //[Authorize]
        [Route("GetConsultaLista")]
        public IActionResult GetPessoas()
        {
            return Ok(_pessoaService.ConsulteLista());
        }

        [HttpGet]
        [Route("ConsultaPorCPF")]
        public IActionResult ConsultaPorCPF(string cpf)
        {
            return Ok(_pessoaService.ConsultarPorCPF(cpf));
        }

        [HttpGet]
        [Route("ConsultarPorCEP")]
        public IActionResult ConsultaPorCEP(int cep)
        {
            return Ok(_pessoaService.ConsultarPorCEP(cep));
        }

        [HttpPost]
        [Route("GravarPessoa")]
        //[Authorize]
        public IActionResult GravarPessoa(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                Pessoa pessoaCadastrada = _pessoaService.CadastrarPessoa(pessoa);

                if (pessoaCadastrada != null)
                {
                    return Ok(pessoaCadastrada);
                }

                return BadRequest("Erro ao salvar pessoa, código já cadastrado.");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("AtualizarPessoa")]
        //[Authorize]
        public IActionResult AtualizarPessoa(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                Pessoa pessoaAtualizada = _pessoaService.AtualizarPessoa(pessoa);

                if (pessoaAtualizada != null)
                {
                    return Ok(pessoaAtualizada);
                }

                return BadRequest("Erro ao atualizar pessoa, pessoa não encontrada.");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("ExcluirPessoa")]
        public IActionResult Excluir(string cpf)
        {
            if (ModelState.IsValid)
            {
                Pessoa pessoaExcluida = _pessoaService.ExcluirPessoa(cpf);
                
                if (pessoaExcluida != null)
                {
                    return Ok(pessoaExcluida);
                }
                return BadRequest("Erro ao excluir cadastro");
            }
            else
            {
                return BadRequest(ModelState);
            }


            
        }

    }
}
