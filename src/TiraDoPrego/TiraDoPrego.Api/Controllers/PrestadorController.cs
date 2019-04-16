using TiraDoPrego.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiraDoPrego.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorController : ControllerBase
    {
        private PrestadorContext _prestadorContext;

        public PrestadorController(PrestadorContext prestadorContext)
        {
            _prestadorContext = prestadorContext;
        }

        [HttpPost]
        [Authorize("Bearer")]
        public void Post([FromBody] Prestador prestador)
        {
            _prestadorContext.Add(prestador);
            _prestadorContext.SaveChanges();
        }

        [HttpPut("{id}")]
        [Authorize("Bearer")]
        public void Put(int id, [FromBody] Prestador prestador)
        {
            var prest = _prestadorContext.prestadores.Single(p => p.id == id);
            prest.nome = prestador.nome;
            prest.horario = prestador.horario;
            prest.latitude = prestador.latitude;
            prest.longitude = prestador.longitude;
            prest.telefone = prestador.telefone;
            
            _prestadorContext.SaveChanges();
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        public ActionResult<Prestador>  Get(int id)
        {
            try
            {
                return _prestadorContext.prestadores.Single(p => p.id == id);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public ActionResult<List<Prestador>> Get()
        {
            return _prestadorContext.prestadores.ToList();
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public void Delete( int id)
        {
            var prest = _prestadorContext.prestadores.Single(p => p.id == id);
            _prestadorContext.prestadores.Remove(prest);
            _prestadorContext.SaveChanges();
        }
    }
}
