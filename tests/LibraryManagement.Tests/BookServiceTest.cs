using LibraryManagement.Models;
using LibraryManagement.Repository;
using LibraryManagement.Service;

namespace LibraryManagement.Tests;

public class BookServiceTest
{
    private List<Book> BookList = new List<Book>();
    private readonly IBookRepository _bookRepository;
    private readonly IBookService _bookService;

    public BookServiceTest()
    {
        _bookRepository = new BookRepository(BookList);
        _bookService = new BookService(_bookRepository);

        GenerateTestData();
    }

    [Fact]
    public void CreateBook_Test()
    {
        //Arrange
        string book = "{\"Authors\":[\"Dan Brown\"],\"Title\":\"The Lost Symbol\",\"Publisher\":\"Bantam Press\",\"PublicationYear\":2009,\"NumberOfPages\":523}";
        
        //Act
        var bookList = _bookService.ReadBooks(book);

        //Assert
        Assert.Equal(3, bookList.Count);
        Assert.Equal(1, bookList.Count(x=> x.Title == "The Lost Symbol"));
    }
    
    [Fact]
    public void GetBookLocation_Test()
    {
        //Arrange
        var isbn = BookList[0].ISBN;
        var locationString = isbn.Split('-')[1];
        var expectedLocation = $"The book is in Room {locationString.ToCharArray()[0]} shelve {locationString.ToCharArray()[1]} & row {locationString.ToCharArray()[2]}";
        
        //Act
        var location = _bookService.GetBookLocation(isbn);

        //Assert
        Assert.Equal(expectedLocation, location);
    }

    [Fact]
    public void FindBook_WithOneSearchString_Test()
    {
        //Arrange

        var searchstring = "Gyldendal";
        //Act
        var books = _bookService.FindBooks(searchstring);

        //Assert
        Assert.Equal(1, books.Count);
        Assert.Equal(searchstring, books[0].Publisher);
    }


    [Fact]
    public void FindBook_WithMultipleSearchStrings_Test()
    {
        //Arrange

        var searchstring = "Gyldendal & 2012";
        //Act
        var books = _bookService.FindBooks(searchstring);

        //Assert
        Assert.Equal(2, books.Count);
        Assert.Equal("Gyldendal", books[0].Publisher);
        Assert.Equal(2012, books[1].PublicationYear);
    }
    private void GenerateTestData()
    {

        string book1 = "{\"Authors\":[\"BrianJensen\"],\"Title\":\"TextsfromDenmark\",\"Publisher\":\"Gyldendal\",\"PublicationYear\":2001,\"NumberOfPages\":253}";

        string book2 = "{\"Authors\":[\"PeterJensen\",\"HansAndersen\"],\"Title\":\"StoriesfromAbroad\",\"Publisher\":\"Borgen\",\"PublicationYear\":2012,\"NumberOfPages\":156}";

        _bookService.ReadBooks(book1);
        _bookService.ReadBooks(book2);
    }
}