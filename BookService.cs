using BookApi.Models;

namespace BookApi
{
    // Реализация IBookService — хранит книги в памяти
    public class BookService : IBookService
    {
        // Статический список книг (общий для всех экземпляров)
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Война и мир", Author = "Лев Толстой", Year = 1869, Genre = "Роман" },
            new Book { Id = 2, Title = "Преступление и наказание", Author = "Фёдор Достоевский", Year = 1866, Genre = "Роман" },
            new Book { Id = 3, Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Year = 1967, Genre = "Фантастика" }
        };

        private static int _nextId = 4;

        public List<Book> GetAllBooks() => _books;

        public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public Book AddBook(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public bool DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return false;
            _books.Remove(book);
            return true;
        }

        // Подсчёт количества книг
        public int GetCount() => _books.Count;
    }
}
