

using System.Security.Cryptography.X509Certificates;

namespace LibraryManagement.Models;


public class Book: LibraryResourcesBase
{
    public string BookId { get; set; }
    public List<string> Authors { get; set; } = new List<string>();
    public string Publisher { get; set; }
    public int PublicationYear { get; set; }
    public int NumberOfPages { get; set; }
}