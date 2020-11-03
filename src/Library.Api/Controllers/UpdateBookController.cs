using Library.Application.UseCases.CreateBook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class UpdateBookController : ControllerBase
    {
        private readonly ICreateBookUseCase _createBookUseCase;

        public UpdateBookController(ICreateBookUseCase createBookUseCase)
        {
            _createBookUseCase = createBookUseCase;
        }

        /// <summary>
        /// Atualiza um livro.
        /// </summary>
        /// <remarks>Atualiza um livro.</remarks>
        /// <response code="204">Sucesso.</response>
        /// <response code="400">Requisição inválida.</response>        
        /// <response code="422">Entidade não processada.</response>        
        [HttpPut("books/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Execute(Guid id, CreateBookRequest createBookRequest)
        {
            createBookRequest.Id = id;

            await _createBookUseCase.Execute(createBookRequest);

            return NoContent();
        }
    }
}