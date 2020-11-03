using Library.Application.UseCases.GetSubjects;
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
    public class GetSubjectsController : ControllerBase
    {
        private readonly IGetSubjectsUseCase _getSubjectsUseCase;

        public GetSubjectsController(IGetSubjectsUseCase getSubjectsUseCase)
        {
            _getSubjectsUseCase = getSubjectsUseCase;
        }

        /// <summary>
        /// Obtém os assuntos.
        /// </summary>
        /// <remarks>Obtém os assuntos.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("subjects")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> Execute()
        {
            var response = await _getSubjectsUseCase.Execute();

            if (!(response != null && response.Any())) return NotFound();

            return Ok(response);
        }
    }
}