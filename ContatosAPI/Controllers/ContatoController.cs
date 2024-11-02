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

        /// <summary>
        /// Endpoint que retorna todos os contatos cadastrados na base de dados.
        /// </summary>
        /// <returns>Retorna um IList de objetos Contato referentes a todos os contatos cadastrados.</returns>
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

        /// <summary>
        /// Endpoint para buscar um contato através do seu ID.
        /// </summary>
        /// <param name="id">O ID do contato a buscar.</param>
        /// <returns>Retorna um objeto Contato referente ao ID informado, caso exista.</returns>
        [HttpGet("/id/{id:int}")]
        public IActionResult GetById([FromRoute] int id)
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

        /// <summary>
        /// Endpoint que retorna todos os contatos cadastrados, filtrados por DDD.
        /// </summary>
        /// <param name="DDD">O DDD (2 dígitos) que será utilizado para filtrar os contatos.</param>
        /// <returns>Retorna um IList de objetos Contato cadastrados com o DDD informado.</returns>
        [HttpGet("/ddd/{DDD:int}")]
        public IActionResult GetByDDD([FromRoute] int DDD)
        {
            try
            {
                return Ok(_contatoRepository.GetByDDD(DDD));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint que retorna todos os contatos cadastrados, filtrados pela região geográfica.
        /// </summary>
        /// <param name="regiao">A região que será utilizada como filtro. Os valores válidos são: Norte, Nordeste, Centro-Oeste, Sudeste e Sul.</param>
        /// <returns>Retorna um IList de objetos Contato cadastrados com a região informada.</returns>
        [HttpGet("/regiao/{regiao}")]
        public IActionResult GetByRegiao([FromRoute] string regiao)
        {
            try
            {
                return Ok(_contatoRepository.GetByRegiao(regiao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint para cadastro de um novo contato.
        /// </summary>
        /// <param name="input">São obrigatórios os campos de Nome (máx. 100 caracteres), DDD (2 dígitos) e Telefone (9 dígitos, sem hífen), e opcional o campo o Email (máx. 100 caracteres).</param>
        [HttpPost]
        public IActionResult Post([FromBody] ContatoCreate input)
        {
            try
            {
                _contatoRepository.Create(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint para atualizar os dados de um contato já existente.
        /// </summary>
        /// <param name="input">São obrigatórios os campos de ID, novo Nome (máx. 100 caracteres), novo DDD (2 dígitos) e novo Telefone (9 dígitos, sem hífen), e opcional o campo de novo Email (máx. 100 caracteres).</param>
        [HttpPut]
        public IActionResult Update([FromBody] ContatoUpdate input)
        {
            try
            {
                _contatoRepository.Update(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint para apagar um contato da base de dados.
        /// </summary>
        /// <param name="id">ID do contato que será apagado.</param>
        [HttpDelete("/del/{id:int}")]
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
