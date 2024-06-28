using BookAPI.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookAPI.Services
{
    public class OperationsRepository : IOperationsRepository
    {
        private readonly List<Books> books;

        public OperationsRepository(IBooksrRepository booksRepository)
        {
            books = booksRepository.GetBooks().ToList();
        }
        public IEnumerable<Books> FindBooksByAmountRange()
        {
            var b = books.Where(b => (b.Amount > books.Min(b => b.Amount) & b.Amount < books.Max(b => b.Amount)));
            return b;
        }
        public IEnumerable<Books> FindBooksByNameStartsWith()
        {
            return books.Where(b => b.Name.StartsWith("a", StringComparison.OrdinalIgnoreCase));
        }

        public (Books costliest, Books cheapest) FindCostliestAndCheapestBooks()
        {
            var costliest = books.OrderByDescending(b => b.Amount).FirstOrDefault();
            var cheapest = books.OrderBy(b => b.Amount).FirstOrDefault();
            return (costliest, cheapest);
        }

        public Books FindCostliestBook()
        {
            var book = books.OrderByDescending(b => b.Amount).FirstOrDefault();
            return book;
        }
    }
}
