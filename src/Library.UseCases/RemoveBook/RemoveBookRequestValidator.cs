using FluentValidation;
using Library.Application.UseCases.RemoveBook;

namespace Library.UseCases.RemoveBook
{
    public class RemoveBookRequestValidator : AbstractValidator<RemoveBookRequest>
    {
        public RemoveBookRequestValidator()
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
