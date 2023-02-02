namespace Lab_DZ_BooksLibrary_7.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Publishing { get; set; } = null!;
        public int YearOfPublishing { get; set; }
        public string? FilePath { get; set; } //obov`jazkovo dlja files!!!!!! vstanovljuvaty nullable
        public string AboutBook { get; set; } = null!;
    }
}
