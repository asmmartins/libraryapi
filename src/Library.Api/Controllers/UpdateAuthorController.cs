using Library.Application.UseCases.CreateAuthor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class UpdateAuthorController : ControllerBase
    {
        private readonly ICreateAuthorUseCase _createAuthorUseCase;

        public UpdateAuthorController(ICreateAuthorUseCase createAuthorUseCase)
        {
            _createAuthorUseCase = createAuthorUseCase;
        }

        /// <summary>
        /// Atualiza um autor.
        /// </summary>
        /// <remarks>Atualiza um autor.</remarks>
        /// <response code="204">Sucesso.</response>
        /// <response code="400">Requisição inválida.</response>        
        /// <response code="422">Entidade não processada.</response>        
        [HttpPut("authors/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Execute(Guid id, CreateAuthorRequest createAuthorRequest)
        {
            createAuthorRequest.Id = id;

            await _createAuthorUseCase.Execute(createAuthorRequest);

            return NoContent();
        }
    }
}