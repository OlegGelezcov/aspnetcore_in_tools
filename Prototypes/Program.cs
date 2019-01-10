using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Prototypes {
    class Program {
        static void Main(string[] args) {
            var task = GetLinks("https://stackoverflow.com/questions/2248411/get-all-links-on-html-page");
            var document = task.Result;
            var links = CollectLinks(document);
            var statistics = CollectTagStatistics(document);

            foreach(var kvp in statistics.OrderByDescending(kvp => kvp.Value).Select(kvp => kvp) ) {
                WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        private static async Task MakeRequest() {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://google.com");
            WriteLine("content headers:");
            foreach(var kvp in response.Headers) {
                WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
            }
            string contentString = await response.Content.ReadAsStringAsync();
            WriteLine("content:");
            WriteLine(contentString);
            using (StreamWriter writer = new StreamWriter("request.txt")) {
                await writer.WriteAsync(contentString);
            }
            WriteLine("done.");
        }

        private static async Task<HtmlDocument> GetLinks(string url) {
            HtmlWeb htmlWeb = new HtmlWeb();
            var document = await htmlWeb.LoadFromWebAsync(url);
            return document;
        }

        private static Dictionary<string, int> CollectTagStatistics(HtmlDocument document) {
            Dictionary<string, int> statistics = new Dictionary<string, int>();
            CollectTagStatistics(statistics, document.DocumentNode);
            return statistics;
        }

        private static List<string> CollectLinks(HtmlDocument document ) {
            List<string> links = new List<string>();
            foreach (HtmlNode link in document.DocumentNode.SelectNodes("//a[@href]")) {
                links.Add(link.Attributes["href"].Value);
            }
            return links;
        }

        private static void CollectTagStatistics(Dictionary<string, int> tagStatistics, HtmlNode node ) {
            FillStatistics(tagStatistics, node.Name);
            foreach(HtmlNode childNode in node.ChildNodes ) {
                CollectTagStatistics(tagStatistics, childNode);
            }
        }

        private static void FillStatistics(Dictionary<string, int> tagStatistics, string name ) {
            if(tagStatistics.ContainsKey(name)) {
                tagStatistics[name]++;
            } else {
                tagStatistics.Add(name, 1);
            }
        }
    }
}
