using BookAPI.Models;

namespace BookAPI.Services
{
    public interface IBooksrRepository
    {
        public IEnumerable<Books> GetBooks();
        public Books GetBooksById(Guid id);
        public bool AddBook(Books c);
        public Books UpdateBook(Guid id,Books c);
        public bool DeleteBook(Guid id);
        public bool DeleteAllBooks();
    }
}
