using TiraDoPrego.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace TiraDoPrego.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private PrestadorContext _prestadorContext;
        private UsuarioContext _usuarioContext;

        public StatusController(UsuarioContext usuarioContext, PrestadorContext prestadorContext)
        {
            _prestadorContext = prestadorContext;
            _usuarioContext = usuarioContext;
        }

        [HttpGet]
        [Authorize("Bearer")]
        public ActionResult<dynamic> Get()
        {
            var countPrestador = _prestadorContext.prestadores.Count();
            var countUsuario = _usuarioContext.usuarios.Count();
            dynamic status = new ExpandoObject();
            status.Prestador = countPrestador != null ? countPrestador : 0;
            status.Usuario = countUsuario != null ? countUsuario : 0;
            return status;
        }



    }
}
