using Library.Application.UseCases.GetSubject;
using Library.Application.UseCases.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class GetSubjectController : ControllerBase
    {
        private readonly IGetSubjectUseCase _getSubjectUseCase;

        public GetSubjectController(IGetSubjectUseCase getSubjectUseCase)
        {
            _getSubjectUseCase = getSubjectUseCase;
        }

        /// <summary>
        /// Obtém um assunto.
        /// </summary>
        /// <remarks>Obtém um assunto.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("subjects/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubjectDto>> Execute(Guid id)
        {
            var response = await _getSubjectUseCase.Execute(id);

            if (response == null) return NotFound();

            return Ok(response);
        }
    }
}