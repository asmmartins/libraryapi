using FluentValidation;
using Library.Application.UseCases.CreateAuthor;

namespace Library.UseCases.CreateAuthor
{
    public class CreateAuthorRequestValidator : AbstractValidator<CreateAuthorRequest>
    {
        public CreateAuthorRequestValidator()
        {
            AddNameRules();
        }

        private void AddNameRules()
        {
            RuleFor(request => request.Name).NotNull();
            RuleFor(request => request.Name).NotEmpty();
        }
    }
}
