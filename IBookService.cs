using BookApi.Models;

namespace BookApi
{
    // Контракт сервиса для работы с книгами
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book AddBook(Book book);
        bool DeleteBook(int id);
        int GetCount();
    }
}
