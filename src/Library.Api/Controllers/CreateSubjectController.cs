using Library.Application.UseCases.CreateSubject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class CreateSubjectController : ControllerBase
    {
        private readonly ICreateSubjectUseCase _createSubjectUseCase;

        public CreateSubjectController(ICreateSubjectUseCase createSubjectUseCase)
        {
            _createSubjectUseCase = createSubjectUseCase;
        }

        /// <summary>
        /// Cria um assunto.
        /// </summary>
        /// <remarks>Cria um assunto.</remarks>
        /// <response code="204">Sucesso.</response>
        /// <response code="400">Requisição inválida.</response>        
        /// <response code="422">Entidade não processada.</response>        
        [HttpPost("subjects")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Execute(CreateSubjectRequest createSubjectRequest)
        {
            await _createSubjectUseCase.Execute(createSubjectRequest);

            return NoContent();
        }
    }
}