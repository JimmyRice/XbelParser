namespace XbelParser;

public class Folder
{
    public string Name { get; set; } = string.Empty;
    public List<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();
    public List<Folder> Children { get; set; } = new List<Folder>();
}
