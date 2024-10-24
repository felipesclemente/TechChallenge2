using Core.Entities;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContatosAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Ok(_contatoRepository.Index());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                return Ok(_contatoRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContatoInput input)
        {
            try
            {
                Contato newContato = new()
                {
                    Nome = input.Nome,
                    DDD = input.DDD,
                    Telefone = input.Telefone,
                    Email = input.Email
                };
                _contatoRepository.Create(newContato);
                return Ok(newContato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] ContatoUpdateInput input)
        {
            try
            {
                var contatoToUpdate = _contatoRepository.GetById(input.Id);
                contatoToUpdate.Nome = input.Nome;
                contatoToUpdate.DDD = input.DDD;
                contatoToUpdate.Telefone = input.Telefone;
                contatoToUpdate.Email = input.Email;
                _contatoRepository.Update(contatoToUpdate);
                return Ok(contatoToUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _contatoRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
