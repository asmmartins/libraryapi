using FluentValidation;
using Library.Application.UseCases.CreateSubject;

namespace Library.UseCases.CreateSubject
{
    public class CreateSubjectRequestValidator : AbstractValidator<CreateSubjectRequest>
    {
        public CreateSubjectRequestValidator()
        {            
            AddNameRules();
        }        

        private void AddNameRules()
        {
            RuleFor(request => request.Description).NotNull();
            RuleFor(request => request.Description).NotEmpty();
        }
    }
}
