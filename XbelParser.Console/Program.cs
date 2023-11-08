using XbelParser;

public class Program
{
    public static void Main()
    {
        // Load your XML here, you can load it from a file or the internet.
        string path = "";
        string file = File.ReadAllText(path);

        Result result = new XbelParser.XbelParser(file).GetResult();

        PrintFolders(result.Folders);
        PrintBookmarks(result.Bookmarks);
    }

    public static void PrintFolders(List<Folder> folders)
    {
        foreach (Folder folder in folders)
        {
            Console.WriteLine("Folder name: " + folder.Name);

            if (folder.Children.Count != 0)
            {
                PrintFolders(folder.Children);
            }

            PrintBookmarks(folder.Bookmarks);
        }
    }

    public static void PrintBookmarks(List<Bookmark> bookmarks)
    {
        foreach (Bookmark bookmark in bookmarks)
        {
            Console.WriteLine("Bookmark Name: " + bookmark.Name);
            Console.WriteLine("Bookmark URL: " + bookmark.Url);
        }
    }
}