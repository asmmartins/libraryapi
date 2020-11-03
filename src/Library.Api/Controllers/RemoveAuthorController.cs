using Library.Application.UseCases.RemoveAuthor;
using Library.Application.UseCases.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class RemoveAuthorController : ControllerBase
    {
        private readonly IRemoveAuthorUseCase _removeAuthorUseCase;

        public RemoveAuthorController(IRemoveAuthorUseCase removeAuthorUseCase)
        {
            _removeAuthorUseCase = removeAuthorUseCase;
        }

        /// <summary>
        /// Remove um autor.
        /// </summary>
        /// <remarks>Remove um autor.</remarks>
        /// <response code="204">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>                    
        [HttpDelete("authors/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        public async Task<ActionResult<AuthorDto>> Execute(Guid id)
        {
            var request = new RemoveAuthorRequest() { Id = id };

            await _removeAuthorUseCase.Execute(request);            

            return NoContent();
        }
    }
}