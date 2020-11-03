using Library.Application.UseCases.GetAuthors;
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
    public class GetAuthorsController : ControllerBase
    {
        private readonly IGetAuthorsUseCase _getAuthorsUseCase;

        public GetAuthorsController(IGetAuthorsUseCase getAuthorsUseCase)
        {
            _getAuthorsUseCase = getAuthorsUseCase;
        }

        /// <summary>
        /// Obtém os autores.
        /// </summary>
        /// <remarks>Obtém os autores.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("authors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Execute()
        {
            var response = await _getAuthorsUseCase.Execute();

            if (!(response != null && response.Any())) return NotFound();

            return Ok(response);
        }
    }
}