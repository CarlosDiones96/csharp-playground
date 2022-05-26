using System;
using System.Net.Http;
using System.Threading.Tasks;

public static class PortugueseDictionary
{
    static readonly HttpClient client = new HttpClient();
    private static string response;

    static public async Task GetDefinition(string word)
    {
        try
        {
            string uri = "https://pt.wiktionary.org/wiki/" + word.ToLower();
            response = await client.GetStringAsync(uri);
            FormatResponse();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine();
            Console.WriteLine("Ocorreu um erro: {0}", ex.Message);
        }
    }

    private static void FormatResponse()
    {
        // StripStartTags(response);
        // StripEndTags(response);

        int start = response.IndexOf("<div id=\"bodyContent\" class=\"vector-body\">");
        
        if(start >= 0){
            response = response.Substring(start + 1);
            response = response.Replace(" ", "||");
        }
    
        Console.WriteLine(response);
        Console.WriteLine("\n\n\n");
    }

    private static string StripStartTags(string item)
    {
        if (item.Trim().StartsWith("<"))
        {
            int lastLocation = item.IndexOf(">");
            if (lastLocation >= 0)
            {
                item = item.Substring(lastLocation + 1);
                item = StripStartTags(item);
            }
        }
        return item;
    }

    private static string StripEndTags(string item)
    {
        bool found = false;
        if (item.Trim().EndsWith(">"))
        {
            int lastLocation = item.LastIndexOf("</");
            if (lastLocation >= 0)
            {
                found = true;
                item = item.Substring(0, lastLocation);
            }
        }

        if(found)
        {
            item = StripEndTags(item);
        }

        return item;
    }


}