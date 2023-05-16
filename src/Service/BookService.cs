using LibraryManagement.Models;
using LibraryManagement.Models.Request;
using LibraryManagement.Repository;
using System.Text.Json;

namespace LibraryManagement.Service
{
    public interface IBookService
    {
        List<Book> ReadBooks(string input);
        List<Book> FindBooks(string searchString);

        string GetBookLocation(string ISBN);

    }
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book> ReadBooks(string input)
        {

            BookCreateRequest? bookRequest = JsonSerializer.Deserialize<BookCreateRequest>(input);
            var bookId = Guid.NewGuid().ToString("N");
            var result = _bookRepository.CreateBook(new()
            {
                BookId = bookId,
                Title = bookRequest.Title,
                Authors = bookRequest.Authors.ToList(),
                PublicationYear = bookRequest.PublicationYear,
                NumberOfPages = bookRequest.NumberOfPages,
                Publisher = bookRequest.Publisher,
                ISBN = $"Book-{GenerateBookLocation()}-{bookId}"

            });

            return result;
        }

        public List<Book> FindBooks(string searchString)
        {
            return _bookRepository.FilterBooksByName(searchString.Split('&'));
        }

        public string GetBookLocation(string ISBN)
        {
            var roomInfo = ISBN.Split('-')[1];
            var location = roomInfo.ToCharArray();
            return $"The book is in Room {location[0]} shelve {location[1]} & row {location[2]}";
        }

        private string GenerateBookLocation()
        {
            var rooms = Enum.GetValues(typeof(RoomNumber));
            var shelves = Enum.GetValues(typeof(Shelve));
            var rows = Enum.GetValues(typeof(Row));
            return $"{(int)rooms.GetValue(new Random().Next(rooms.Length))}" +
                   $"{(int)shelves.GetValue(new Random().Next(shelves.Length))}" +
                   $"{(int)rows.GetValue(new Random().Next(rows.Length))}";
        }


    }
}
