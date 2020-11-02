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
            RuleFor(group => group.Id).NotNull();
            RuleFor(group => group.Id).NotEmpty();
        }

        private void AddNameRules()
        {
            RuleFor(group => group.Name).NotNull();
            RuleFor(group => group.Name).NotEmpty();
            RuleFor(group => group.Name).MinimumLength(1);
            RuleFor(group => group.Name).MaximumLength(40);
        }        
    }
}