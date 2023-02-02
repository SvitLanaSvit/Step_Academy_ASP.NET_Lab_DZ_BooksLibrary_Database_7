namespace Lab_DZ_BooksLibrary_7.Models
{
    public class BookRepository : IRepository<Book>
    {
        List<Book> _books;

        public BookRepository()
        {
            _books = new()
            {
                new Book()
                {
                    Id = 1,
                    Author = "Patrick Ness",
                    Name = "The Knife of Never Letting Go",
                    Genre = "Young-adult, science fiction",
                    Publishing = "Walker Books",
                    YearOfPublishing = 2008,
                    FilePath = "/images/Knife_of_Never_letting_Go_cover.jpg",
                    AboutBook = "„A bleak and unflinching novel with fascinating characters and extraordinary " +
                    "dialogue which creates a fully-realised world that the reader really buys into." +
                    "The dog Manchee is an inspired creation! Ness conveys a real sense of terror " +
                    "and the ending is devastating. A novel that really stands out.“"
                },
                new Book()
                {
                    Id = 2,
                    Author = "Patrick Ness",
                    Name = "The Ask and the Answer ",
                    Genre = "Young-adult, science fiction",
                    Publishing = "Walker Books",
                    YearOfPublishing = 2009,
                    FilePath = "/images/The_Ask_and_the_Answer.jpg",
                    AboutBook = "„A visceral and compelling story of incredible power which combines " +
                    "some fantastic writing with intelligent consideration of some important issues: " +
                    "the nature of war, terrorism and the treatment of women. A challenging novel which " +
                    "really lives inside your head.“"
                }
            };
        }
        public Book Add(Book entity)
        {
            _books.Add(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            Book? book = Get(id);
            return _books.Remove(book!);
        }

        public Book Edit(Book entity)
        {
            Book? book = Get(entity.Id);
            book!.Name = entity.Name;
            book!.Author = entity.Author;
            book!.Genre = entity.Genre;
            book!.Publishing = entity.Publishing;
            book!.YearOfPublishing = entity.YearOfPublishing;
            book!.FilePath = entity.FilePath;
            book!.AboutBook = entity.AboutBook;
            return book;
        }

        public Book? Get(int id)
        {
            return _books.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }
    }
}
