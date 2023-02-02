namespace Lab_DZ_BooksLibrary_7.Models
{
    public class BookDbRepository : IRepository<Book>
    {
        private BookContext context;

        public BookDbRepository(BookContext context) 
        { 
            this.context = context;
        }
        public Book Add(Book entity)
        {
            context.Books.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Book? book = context.Books.Find(id);
            context.Books.Remove(book!);
            context.SaveChanges();
            return book != null;
        }

        public Book Edit(Book entity)
        {
            Book? book = context.Books.Find(entity.Id);
            book!.Name = entity.Name;
            book!.Author = entity.Author;
            book!.Genre = entity.Genre;
            book!.Publishing = entity.Publishing;
            book!.YearOfPublishing = entity.YearOfPublishing;
            book!.FilePath = entity.FilePath;
            book!.AboutBook = entity.AboutBook;
            context.SaveChanges();
            return book;
        }

        public Book? Get(int id)
        {
            return context.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return context.Books.ToList();
        }
    }
}