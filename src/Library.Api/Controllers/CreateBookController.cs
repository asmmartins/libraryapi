using Library.Application.UseCases.CreateBook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class CreateBookController : ControllerBase
    {
        private readonly ICreateBookUseCase _createBookUseCase;

        public CreateBookController(ICreateBookUseCase createBookUseCase)
        {
            _createBookUseCase = createBookUseCase;
        }

        /// <summary>
        /// Cria um livro.
        /// </summary>
        /// <remarks>Cria um livro.</remarks>
        /// <response code="204">Sucesso.</response>
        /// <response code="400">Requisição inválida.</response>        
        /// <response code="422">Entidade não processada.</response>        
        [HttpPost("books")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Execute(CreateBookRequest createBookRequest)
        {
            await _createBookUseCase.Execute(createBookRequest);

            return NoContent();
        }
    }
}