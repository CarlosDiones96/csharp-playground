using System;
using System.Threading.Tasks;

namespace csharp_playground
{
    class Program
    {
       static async Task Main(string[] args)
       {
           Console.WriteLine("Dicionário de Língua Portuguesa\n-----------------------------------------------------------");
           Console.WriteLine("Escreva uma palavra para buscar sua definição");
           Console.Write(">> ");
           string word = Console.ReadLine();
           
           await PortugueseDictionary.GetDefinition(word.ToLower());
       }
    }
   
}
