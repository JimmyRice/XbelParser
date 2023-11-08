# XBELParser

XBELParser is not a true 'parser.' It is a simple processing library for XBEL (XML Bookmark Exchange Language).

## What is XML Bookmark Exchange Language

From Wikipedia:

The XML Bookmark Exchange Language (XBEL), is an open XML standard for sharing Internet URIs, also known as bookmarks (or favorites in Internet Explorer).

Example

```xml
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xbel>
<xbel version="1.0">
    <folder folded="no">
        <title>Wikimedia resources</title>
        <folder folded="yes">
            <title>Wikimedia websites</title>
            <bookmark href="https://en.wikipedia.org/">
                <title>Wikipedia</title>
            </bookmark>
            <bookmark href="https://en.wikibooks.org/">
                <title>Wikibooks</title>
            </bookmark>
        </folder>
    </folder>
</xbel>
```

## Why?

Currently, some browser bookmark plugins are still adopting this XML extension format. For example, the well-known cross-browser bookmark sync plugin Floccus. This tool can quickly assist you in extracting Bookmarks and Folders from XBEL, allowing you to extend the use of this format further. If you are planning to develop versions in other languages, you can also refer to the included C# code.
