using Library.Application.UseCases.GetBooks;
using Library.Application.UseCases.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class GetBooksController : ControllerBase
    {
        private readonly IGetBooksUseCase _getBooksUseCase;

        public GetBooksController(IGetBooksUseCase getBooksUseCase)
        {
            _getBooksUseCase = getBooksUseCase;
        }

        /// <summary>
        /// Obtém os livros.
        /// </summary>
        /// <remarks>Obtém os livros.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BookDto>>> Execute()
        {
            var response = await _getBooksUseCase.Execute();

            if (!(response != null && response.Any())) return NotFound();

            return Ok(response);
        }
    }
}