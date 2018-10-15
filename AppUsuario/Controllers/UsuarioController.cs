using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppUsuario.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class UsuarioController : ControllerBase
    {

        private readonly IDbUsuarioRepository _usuarioRepository;

       
        public UsuarioController(IDbUsuarioRepository p)
        {
            _usuarioRepository = p;
        }


        // GET api/values
        [HttpGet]
        public   ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_usuarioRepository.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_usuarioRepository.Find(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Usuario p)
        {
            try
            {
                if (p == null || !ModelState.IsValid)
                {
                    return BadRequest("Usuario não informado");
                }
                bool itemExists = _usuarioRepository.Exists(p.ID);

                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, "Usuario já Cadastrada");
                }
                _usuarioRepository.Insert(p);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível cadastrar usuário");
            }
            return Ok(p);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario p)
        {
            try
            {
                if (p == null || !ModelState.IsValid)
                {
                    return BadRequest("Usuário não informada");
                }
                var existingItem = _usuarioRepository.Find(p.ID);
                if (existingItem == null)
                {
                    return NotFound("Usuário não encontrado");
                }
                _usuarioRepository.Update(p);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao atualizar Usuário");
            }
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _usuarioRepository.Find(id);
                if (item == null)
                {
                    return NotFound("Usuário não encontrado");
                }
                _usuarioRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao remover Usuario");
            }
            return NoContent();
        }
    }
}
