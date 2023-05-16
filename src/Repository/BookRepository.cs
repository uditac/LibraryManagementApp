using LibraryManagement.Models;

namespace LibraryManagement.Repository;

public interface IBookRepository
{
    List<Book> CreateBook(Book book);

    List<Book> FilterBooksByName(string[] searchStrings);

}
public class BookRepository: IBookRepository
{
    public List<Book> BookList { get; set; }
    public BookRepository(List<Book> bookList)
    {
        BookList = bookList;
    }

    public List<Book> CreateBook(Book book)
    {
        BookList.Add(book);
        return BookList;

    }

    public List<Book> FilterBooksByName(string[] searchStrings)
    {
        List<Book> resList = new List<Book>();
        foreach (string searchString in searchStrings)
        {
            if (!string.IsNullOrEmpty(searchString.Trim()))
            {
                var lst = BookList.Where(x => x.Title.Contains(searchString.Trim())
                                              || string.Join(" ", x.Authors).Contains(searchString.Trim())
                                              || x.Publisher.Contains(searchString.Trim())
                                              || x.PublicationYear.ToString().Contains(searchString.Trim()));
                resList.AddRange(lst);
            }
            else
            {
                throw new ArgumentException("One or more than one of the search string is empty or null!");
            }
            
        }

        return resList.DistinctBy(x => x.BookId).ToList();
    }


}
