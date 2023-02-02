using Microsoft.EntityFrameworkCore;

namespace Lab_DZ_BooksLibrary_7.Models
{
    public class BookContext : DbContext
    {

        public DbSet<Book> Books { get; set; } = null!;
        public BookContext(DbContextOptions<BookContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            Book book1 = new Book()
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
            };
            Book book2 = new Book()
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
            };

            modelBuilder.Entity<Book>().HasData(book1, book2);
        }
    }
}
