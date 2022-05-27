using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

// include AngleSharp library to work with the HTML page results

public static class PortugueseDictionary
{
    static readonly HttpClient client = new HttpClient();
    private static string response;

    static public async Task GetDefinition(string word)
    {
        try
        {
            string uri = "https://www.dicio.com.br/" + word.ToLower() + "/";
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
        List<string> forbiddenStrings = new List<string>() {
            " ", "\n", "\t", "<script>", "</script>", "{", "}", "(", ")", "[", "]", 
            "<html>", "</html>", "<style>", "</style>", "class=", "id=" 
        };

        List<string> validLines = new List<string>();
        Console.WriteLine(response);
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