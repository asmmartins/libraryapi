using Library.Application.UseCases.GetBooksAuthors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class GetBooksAuthorsController : ControllerBase
    {
        private readonly IGetBooksAuthorsUseCase _getBooksAuthorsUseCase;

        public GetBooksAuthorsController(IGetBooksAuthorsUseCase getBooksAuthorsUseCase)
        {
            _getBooksAuthorsUseCase = getBooksAuthorsUseCase;
        }

        /// <summary>
        /// Obtém o livros por autor.
        /// </summary>
        /// <remarks>Obtém o livros por autor.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("author-books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BookAuthorDto>>> Execute()
        {
            var response = await _getBooksAuthorsUseCase.Execute();

            if (!(response != null && response.Any())) return NotFound();

            return Ok(response);
        }
    }
}
