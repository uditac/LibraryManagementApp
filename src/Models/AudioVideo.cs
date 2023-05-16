namespace LibraryManagement.Models
{
    public class AudioVideo :OpticalDrives
    {
        protected int duration { get; set; }

        protected string Artist { get; set; }

        protected string Tracktitle { get; set; }
    }
}
