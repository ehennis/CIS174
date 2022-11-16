namespace CIS174Library.Models
{
    public interface IBook
    {
        public int BookId { get; set; }
        public string Name { get; set; }

        public int? Year { get; set; }
    }
}

