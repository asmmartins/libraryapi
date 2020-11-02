using FluentValidation;
using Library.Application.UseCases.CreateGroup;

namespace Library.UseCases.CreateGroup
{
    public class CreateGroupRequestValidator : AbstractValidator<CreateGroupRequest>
    {
        public CreateGroupRequestValidator()
        {
            AddInepRules();
            AddNameRules();
        }

        private void AddInepRules()
        {
            RuleFor(request => request.Inep).NotNull();
            RuleFor(request => request.Inep).NotEmpty();
        }

        private void AddNameRules()
        {
            RuleFor(request => request.Name).NotNull();
            RuleFor(request => request.Name).NotEmpty();
        }
    }
}
