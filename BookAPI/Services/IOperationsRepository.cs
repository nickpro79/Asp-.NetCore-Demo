using BookAPI.Models;

namespace BookAPI.Services
{
    public interface IOperationsRepository
    {
        public Books FindCostliestBook();
        public (Books costliest, Books cheapest) FindCostliestAndCheapestBooks();
        public IEnumerable<Books> FindBooksByNameStartsWith();
        public IEnumerable<Books> FindBooksByAmountRange();

    }
}
