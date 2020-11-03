using Library.Application.UseCases.GetAuthor;
using Library.Application.UseCases.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class GetAuthorController : ControllerBase
    {
        private readonly IGetAuthorUseCase _getAuthorUseCase;

        public GetAuthorController(IGetAuthorUseCase getAuthorUseCase)
        {
            _getAuthorUseCase = getAuthorUseCase;
        }

        /// <summary>
        /// Obtém um autor.
        /// </summary>
        /// <remarks>Obtém um autor.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("authors/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuthorDto>> Execute(Guid id)
        {
            var response = await _getAuthorUseCase.Execute(id);

            if (response == null) return NotFound();

            return Ok(response);
        }
    }
}