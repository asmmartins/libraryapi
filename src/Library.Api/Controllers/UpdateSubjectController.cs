using Library.Application.UseCases.CreateSubject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class UpdateSubjectController : ControllerBase
    {
        private readonly ICreateSubjectUseCase _createSubjectUseCase;

        public UpdateSubjectController(ICreateSubjectUseCase createSubjectUseCase)
        {
            _createSubjectUseCase = createSubjectUseCase;
        }

        /// <summary>
        /// Atualiza um assunto.
        /// </summary>
        /// <remarks>Atualiza um assunto.</remarks>
        /// <response code="204">Sucesso.</response>
        /// <response code="400">Requisição inválida.</response>        
        /// <response code="422">Entidade não processada.</response>        
        [HttpPut("subjects/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Execute(Guid id, CreateSubjectRequest createSubjectRequest)
        {
            createSubjectRequest.Id = id;

            await _createSubjectUseCase.Execute(createSubjectRequest);

            return NoContent();
        }
    }
}