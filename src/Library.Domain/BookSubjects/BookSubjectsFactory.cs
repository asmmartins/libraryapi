using Library.Domain.Books;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using System.Collections.Generic;

namespace Library.Domain.BookSubjects
{
    public partial class BookSubject : IAggregateRoot
    {
        public static List<BookSubject> Create(Book book, List<Subject> subjects)
        {
            var bookSubjects = new List<BookSubject>();
            foreach (var subject in subjects)
            {
                bookSubjects.Add(new BookSubject()
                {
                    BookId = book.Id,
                    Book = book,
                    Subject = subject,
                    SubjectId = subject.Id
                });
            }            
            return bookSubjects;
        }        
    }
}
