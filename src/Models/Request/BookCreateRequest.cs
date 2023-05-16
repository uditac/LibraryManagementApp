namespace LibraryManagement.Models.Request
{
    public class BookCreateRequest
    {
        public string Title { get; init; }
        public string[] Authors { get; init; } = new List<string>().ToArray();
        public string Publisher { get; init; }
        public int PublicationYear { get; init; }
        public int NumberOfPages { get; init; }
    }
}
