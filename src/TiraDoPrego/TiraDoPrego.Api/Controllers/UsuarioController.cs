using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TiraDoPrego.Api.Infra;
using TiraDoPrego.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TiraDoPrego.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioContext _userContext;

        public UsuarioController(UsuarioContext userContext)
        {
            _userContext = userContext;
        }

        [HttpPost]
        public void Post([FromBody] Usuario usuario)
        {
            usuario.password = PasswordEncrypt.HashPassword(usuario.password);
            _userContext.Add(usuario);
            _userContext.SaveChanges();
        }

        [HttpPut("{id}")]
        [Authorize("Bearer")]
        public void Put(int id, [FromBody] Usuario usuario)
        {
            var user = _userContext.usuarios.Single(p => p.id == id);
            user.admin = usuario.admin;
            user.password = PasswordEncrypt.HashPassword(usuario.password);

            _userContext.SaveChanges();
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        public ActionResult<Usuario> Get(int id)
        {
            try
            {
                return _userContext.usuarios.Single(p => p.id == id);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Authorize("Bearer")]
        public ActionResult<List<Usuario>> Get()
        {
            return _userContext.usuarios.ToList();
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public void Delete(int id)
        {
            var prest = _userContext.usuarios.Single(p => p.id == id);
            _userContext.usuarios.Remove(prest);
            _userContext.SaveChanges();
        }
    }
}