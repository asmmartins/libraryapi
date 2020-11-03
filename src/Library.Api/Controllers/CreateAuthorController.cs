using Library.Application.UseCases.CreateAuthor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class CreateAuthorController : ControllerBase
    {
        private readonly ICreateAuthorUseCase _createAuthorUseCase;

        public CreateAuthorController(ICreateAuthorUseCase createAuthorUseCase)
        {
            _createAuthorUseCase = createAuthorUseCase;
        }

        /// <summary>
        /// Cria um autor.
        /// </summary>
        /// <remarks>Cria um autor.</remarks>
        /// <response code="204">Sucesso.</response>
        /// <response code="400">Requisição inválida.</response>        
        /// <response code="422">Entidade não processada.</response>        
        [HttpPost("authors")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Execute(CreateAuthorRequest createAuthorRequest)
        {            
            await _createAuthorUseCase.Execute(createAuthorRequest);

            return NoContent();
        }
    }
}