using BookAPI.Models;

namespace BookAPI.Services
{

    public class BooksRepository : IBooksrRepository
    {
        List<Books> books = new List<Books>();
        public BooksRepository() {
            books.Add(new Books { Name="A Book One", Description="Description of Book One", Amount=29.99, Author="Author One" });
            books.Add(new Books { Name = "Book Two", Description = "Description of Book Two", Amount = 39.99, Author = "Author Two" });
            books.Add(new Books { Name = "A Book Three", Description = "Description of Book Three", Amount = 49.99, Author = "Author Three" });
            books.Add(new Books { Name = "Book Four", Description = "Description of Book Three", Amount = 50, Author = "Author Four" });
        }
        public bool AddBook(Books c)
        {
            if (c == null)
            {
                return false;
            }
            books.Add(c);
            return true;
        }

        public bool DeleteAllBooks()
        {
            books.Clear();
            return true;
        }

        public bool DeleteBook(Guid id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                books.Remove(book);
                return true;
            }
            return false;
        }

        public IEnumerable<Books> GetBooks()
        {
            return books;
        }


        public Books GetBooksById(Guid id)
        {
           var book = books.FirstOrDefault(x => x.Id == id);
           return book;
        }

        public Books UpdateBook(Guid id, Books c)
        {
            var existingBook = books.FirstOrDefault(x => x.Id == id);
            if (existingBook != null) {
                existingBook.Author = c.Author;
                existingBook.Description = c.Description;
                existingBook.Name = c.Name;
                existingBook.Amount = c.Amount;
            }
            return existingBook;
        }
    }
}
