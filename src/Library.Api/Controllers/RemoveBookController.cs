using Library.Application.UseCases.RemoveBook;
using Library.Application.UseCases.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class RemoveBookController : ControllerBase
    {
        private readonly IRemoveBookUseCase _removeBookUseCase;

        public RemoveBookController(IRemoveBookUseCase removeBookUseCase)
        {
            _removeBookUseCase = removeBookUseCase;
        }

        /// <summary>
        /// Remove um livro.
        /// </summary>
        /// <remarks>Remove um livro.</remarks>
        /// <response code="204">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>                    
        [HttpDelete("books/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        public async Task<ActionResult<BookDto>> Execute(Guid id)
        {
            var request = new RemoveBookRequest() { Id = id };

            await _removeBookUseCase.Execute(request);            

            return NoContent();
        }
    }
}