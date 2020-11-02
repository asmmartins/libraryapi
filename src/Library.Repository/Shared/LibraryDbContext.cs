using Library.Domain.Authors;
using Library.Domain.BookAuthors;
using Library.Domain.Books;
using Library.Domain.BookSubjects;
using Library.Domain.Subjects;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Shared
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Book> Books { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddAuthor(modelBuilder);
            AddSubject(modelBuilder);
            AddBook(modelBuilder);
            AddBookAuthor(modelBuilder);
            AddBookSubject(modelBuilder);
        }

        private void AddAuthor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(s => s.Name)
                .HasMaxLength(40)
                .IsRequired();
        }

        private void AddSubject(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>()
                .Property(s => s.Description)
                .HasMaxLength(20)
                .IsRequired();
        }

        private void AddBook(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(s => s.Title)
                .HasMaxLength(40)
                .IsRequired();

            modelBuilder.Entity<Book>()
               .Property(s => s.PublishingCompany)
               .HasMaxLength(40)
               .IsRequired();

            modelBuilder.Entity<Book>()
               .Property(s => s.PublicationYear)
               .HasMaxLength(4)
               .IsRequired();
        }

        private void AddBookAuthor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(t => new { t.BookId, t.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(pt => pt.Book)
                .WithMany(p => p.BookAuthors)
                .HasForeignKey(pt => pt.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(pt => pt.Author)
                .WithMany(t => t.BookAuthors)
                .HasForeignKey(pt => pt.AuthorId);
        }

        private void AddBookSubject(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookSubject>()
                .HasKey(t => new { t.BookId, t.SubjectId });

            modelBuilder.Entity<BookSubject>()
                .HasOne(pt => pt.Book)
                .WithMany(p => p.BookSubjects)
                .HasForeignKey(pt => pt.BookId);

            modelBuilder.Entity<BookSubject>()
                .HasOne(pt => pt.Subject)
                .WithMany(t => t.BookSubjects)
                .HasForeignKey(pt => pt.SubjectId);
        }

    }
}
