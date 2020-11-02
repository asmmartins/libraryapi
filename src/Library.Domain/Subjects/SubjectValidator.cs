using FluentValidation;

namespace Library.Domain.Subjects
{
    public class SubjectValidator : AbstractValidator<Subject>
    {
        public SubjectValidator()
        {
            AddIdRules();
            AddDescriptionRules();            
        }

        private void AddIdRules()
        {
            RuleFor(subject => subject.Id).NotNull();
            RuleFor(subject => subject.Id).NotEmpty();
        }

        private void AddDescriptionRules()
        {
            RuleFor(subject => subject.Description).NotNull();
            RuleFor(subject => subject.Description).NotEmpty();
            RuleFor(subject => subject.Description).MinimumLength(1);
            RuleFor(subject => subject.Description).MaximumLength(20);
        }        
    }
}