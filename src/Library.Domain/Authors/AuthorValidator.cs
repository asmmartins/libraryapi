using FluentValidation;

namespace Library.Domain.Authors
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            AddIdRules();
            AddNameRules();
        }

        private void AddIdRules()
        {
            RuleFor(author => author.Id).NotNull();
            RuleFor(author => author.Id).NotEmpty();
        }

        private void AddNameRules()
        {
            RuleFor(author => author.Name).NotNull();
            RuleFor(author => author.Name).NotEmpty();
            RuleFor(author => author.Name).MinimumLength(1);
            RuleFor(author => author.Name).MaximumLength(40);
        }
    }
}