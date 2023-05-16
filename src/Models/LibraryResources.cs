namespace LibraryManagement.Models;

public class LibraryResourcesBase
{
    public string ISBN { get; set; }
    public   string Title { get; set; } 
}
public enum RoomNumber : int
{
    One = 1, Two = 2, Three = 3
}

public enum Shelve : int
{
    Shelve1 = 1,
    Shelve2 = 2,
    Shelve3 = 3,
    Shelve4 = 4,
    Shelve5 = 5,
    Shelve6 = 6,
    Shelve7 = 7,
    Shelve8 = 8,
    Shelve9 = 9
}

public enum Row : int
{
    Row1 = 1,
    Row2 = 2,
    Row3 = 3,
    Row4 = 4,
    Row5 = 5,
    Row6 = 6
}
