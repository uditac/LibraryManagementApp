using LibraryManagement.Models;
using LibraryManagement.Repository;

namespace LibraryManagement.Database;

public static class DbInstaller
{
    public static IServiceCollection AddDBHandler(this IServiceCollection services)
    {
        List<Book> BookList = new List<Book>();
        services.AddSingleton<IBookRepository, BookRepository>(_ => new BookRepository(BookList));
        return services;
    }
}