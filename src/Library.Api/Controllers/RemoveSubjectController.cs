using Library.Application.UseCases.RemoveSubject;
using Library.Application.UseCases.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class RemoveSubjectController : ControllerBase
    {
        private readonly IRemoveSubjectUseCase _removeSubjectUseCase;

        public RemoveSubjectController(IRemoveSubjectUseCase removeSubjectUseCase)
        {
            _removeSubjectUseCase = removeSubjectUseCase;
        }

        /// <summary>
        /// Remove um assunto.
        /// </summary>
        /// <remarks>Remove um assunto.</remarks>
        /// <response code="204">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>                    
        [HttpDelete("subjects/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        public async Task<ActionResult<SubjectDto>> Execute(Guid id)
        {
            var request = new RemoveSubjectRequest() { Id = id };

            await _removeSubjectUseCase.Execute(request);            

            return NoContent();
        }
    }
}