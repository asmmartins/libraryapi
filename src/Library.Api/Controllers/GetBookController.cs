using Library.Application.UseCases.GetBook;
using Library.Application.UseCases.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class GetBookController : ControllerBase
    {
        private readonly IGetBookUseCase _getBookUseCase;

        public GetBookController(IGetBookUseCase getBookUseCase)
        {
            _getBookUseCase = getBookUseCase;
        }

        /// <summary>
        /// Obtém um livro.
        /// </summary>
        /// <remarks>Obtém um livro.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("books/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookDto>> Execute(Guid id)
        {
            var response = await _getBookUseCase.Execute(id);

            if (response == null) return NotFound();

            return Ok(response);
        }
    }
}