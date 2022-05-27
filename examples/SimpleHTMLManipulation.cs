using System;
using System.Threading.Tasks;
using AngleSharp;

public class SimpleHTMLManipulation
{
    static async Task Example()
    {
        var config = Configuration.Default;
        var context = BrowsingContext.New(config);

        var document = await context.OpenAsync( req => req.Content(
            "<h1>Example title</h1><p>Just a paragraph</p>"
        ));

        Console.WriteLine("Serializing the (original) document:");
        Console.WriteLine(document.DocumentElement.OuterHtml);

        var p = document.CreateElement("p");
        p.TextContent = "This is another paragraph";

        document.Body.AppendChild(p);
        Console.WriteLine(document.DocumentElement.OuterHtml);
    }
}