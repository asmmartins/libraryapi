using FluentValidation;

namespace Library.Domain.Books
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            AddIdRules();
            AddTitleRules();
            AddPublishingCompanyRules();
            AddEditionRules();
            AddPublicationYearRules();
        }

        private void AddIdRules()
        {
            RuleFor(book => book.Id).NotNull();
            RuleFor(book => book.Id).NotEmpty();
        }

        private void AddTitleRules()
        {
            RuleFor(book => book.Title).NotNull();
            RuleFor(book => book.Title).NotEmpty();
            RuleFor(book => book.Title).MinimumLength(1);
            RuleFor(book => book.Title).MaximumLength(40);
        }

        private void AddPublishingCompanyRules()
        {
            RuleFor(book => book.PublishingCompany).NotNull();
            RuleFor(book => book.PublishingCompany).NotEmpty();
            RuleFor(book => book.PublishingCompany).MinimumLength(1);
            RuleFor(book => book.PublishingCompany).MaximumLength(40);
        }

        private void AddEditionRules()
        {
            RuleFor(book => book.Edition).NotNull();
            RuleFor(book => book.Edition).NotEmpty();
            RuleFor(book => book.Edition).GreaterThan(0);
        }

        private void AddPublicationYearRules()
        {
            RuleFor(book => book.PublicationYear).NotNull();
            RuleFor(book => book.PublicationYear).NotEmpty();
            RuleFor(book => book.PublicationYear).MinimumLength(4);
            RuleFor(book => book.PublicationYear).MaximumLength(4);
            RuleFor(book => book.PublicationYear).Matches(@"^\d{4}$");
        }
    }
}