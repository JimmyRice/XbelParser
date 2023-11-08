using System.Xml;

namespace XbelParser;

public class XbelParser
{
    private string Content;

    public XbelParser(string content)
    {
        Content = content;
    }

    public Result GetResult()
    {
        Result result = new Result();
        List<Bookmark> bookmarks = new List<Bookmark>();
        List<Folder> folders = new List<Folder>();
        XmlDocument document = new XmlDocument();

        document.LoadXml(Content);

        XmlNode? root = document.DocumentElement;

        if (root == null)
        {
            throw new Exception("NULL XML ROOT");
        }

        foreach (XmlNode node in root.ChildNodes)
        {
            string tagName = node.Name;

            if (tagName == "folder")
            {
                Folder folder = ProcessFolder(node);

                folders.Add(folder);
            }

            if (tagName == "bookmark")
            {
                Bookmark bookmark = ProcessBookmark(node);

                bookmarks.Add(bookmark);
            }
        }

        result.Folders = folders;
        result.Bookmarks = bookmarks;

        return result;
    }

    private Folder ProcessFolder(XmlNode folderNode)
    {
        Folder folder = new Folder();

        foreach (XmlNode node in folderNode)
        {
            string tagName = node.Name;

            if (tagName == "bookmark")
            {
                Bookmark bookmark = ProcessBookmark(node);
                folder.Bookmarks.Add(bookmark);
            }

            if (tagName == "folder")
            {
                var child = ProcessFolder(node);

                folder.Children.Add(child);
            }

            if (tagName == "title")
            {
                folder.Name = node.InnerText;
            }
        }

        return folder;
    }

    private Bookmark ProcessBookmark(XmlNode bookmarkNode)
    {
        Bookmark bookmark = new Bookmark();

        // Find href attribute

        if (bookmarkNode.Attributes == null)
        {
            throw new Exception("Attributes is null");
        }

        foreach (XmlAttribute xmlAttribute in bookmarkNode.Attributes)
        {
            if (xmlAttribute.Name == "href")
            {
                bookmark.Url = xmlAttribute.InnerText;
            }
        }

        // Find bookmark name

        foreach (XmlNode node in bookmarkNode.ChildNodes)
        {
            if (node.Name == "title")
            {
                bookmark.Name = node.InnerText;
            }
        }

        return bookmark;
    }
}
