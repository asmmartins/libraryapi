using FluentValidation;
using Library.Application.UseCases.RemoveSubject;

namespace Library.UseCases.RemoveSubject
{
    public class RemoveSubjectRequestValidator : AbstractValidator<RemoveSubjectRequest>
    {
        public RemoveSubjectRequestValidator()
        {
            AddIdRules();
        }

        private void AddIdRules()
        {
            RuleFor(request => request.Id).NotNull();
            RuleFor(request => request.Id).NotEmpty();
        }
    }
}
