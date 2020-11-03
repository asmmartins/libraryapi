using FluentValidation;
using Library.Application.UseCases.CreateBook;

namespace Library.UseCases.CreateBook
{
    public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
    {
        public CreateBookRequestValidator()
        {
            AddTitleRules();
        }

        private void AddTitleRules()
        {
            RuleFor(request => request.Title).NotNull();
            RuleFor(request => request.Title).NotEmpty();
        }
    }
}
