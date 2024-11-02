using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContatosAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class RegioesController : ControllerBase
    {
        private readonly IRegioesRepository _regioesRepository;

        public RegioesController(IRegioesRepository regioesRepository)
        {
            _regioesRepository = regioesRepository;
        }

        /// <summary>
        /// Endpoint que retorna a região e a UF de todos os DDDs cadastrados na base de dados.
        /// </summary>
        /// <returns>Retorna um List de objetos Regioes referentes a todos os DDDs cadastrados.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Ok(_regioesRepository.Index());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
