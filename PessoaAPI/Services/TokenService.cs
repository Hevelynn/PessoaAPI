using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PessoaAPI.Models;

namespace PessoaAPI.Services
{
    public static class TokenService
    {
        public static string GerarToken(Usuario usuario)
        {
            JwtSecurityTokenHandler gerenciadorToken = new JwtSecurityTokenHandler();

            byte[] chave = Encoding.ASCII.GetBytes(Settings.Segredo);

            var dadosToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = gerenciadorToken.CreateToken(dadosToken);
            return gerenciadorToken.WriteToken(token);
        }
    }
}
