namespace LibraryManagement.Models;

public abstract class OpticalDrives : LibraryResourcesBase
{
    protected string? typeofDrive { get; set; }
    protected int size { get; set; }

    protected int numberOfMediaFiles { get; set; }


}

