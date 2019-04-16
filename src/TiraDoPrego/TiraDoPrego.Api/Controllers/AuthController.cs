using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using TiraDoPrego.Api.Infra;
using TiraDoPrego.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace TiraDoPrego.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UsuarioContext _usuarioContext;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;


        public AuthController(UsuarioContext usuarioContext, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            _usuarioContext = usuarioContext;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody] Usuario usuario)
        {
            bool credenciaisValidas = true;
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.login))
            {
                var usuarioBase = _usuarioContext.usuarios.Where(b => b.login == usuario.login).Select((c) => new
                {
                    login = c.login,
                    password = c.password
                }).FirstOrDefault();

                credenciaisValidas = PasswordEncrypt.VerifyHashedPassword(usuarioBase.password, usuario.password);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.login, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.login)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK",
                    usuario = usuario.login,
                    admin = true
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
}
