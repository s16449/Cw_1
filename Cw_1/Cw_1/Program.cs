using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw_1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var strona = "https://pl.prefa.com/kontakt/panstwa-osoba-do-kontaktu-w-prefa/";
            var result = await client.GetAsync(strona);

            if (result.IsSuccessStatusCode)
            {
                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z0-9]+\\.*[a-z0-9]+@[a-z0-9]+\\.[a-z]+\\.*[a-z]+", RegexOptions.IgnoreCase);
                var matches = regex.Matches(html);
                foreach (var m in matches)
                {
                    Console.WriteLine("Adres ze strony " + strona + " : " + m);
                }
            }
        }
    }
}