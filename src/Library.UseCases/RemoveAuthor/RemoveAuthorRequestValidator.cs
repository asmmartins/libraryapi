using FluentValidation;
using Library.Application.UseCases.RemoveAuthor;

namespace Library.UseCases.RemoveAuthor
{
    public class RemoveAuthorRequestValidator : AbstractValidator<RemoveAuthorRequest>
    {
        public RemoveAuthorRequestValidator()
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
