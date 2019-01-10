using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UtilLib {
    public class HtmlInfoService {

        public string Url { get; private set; }

        private readonly HtmlWeb web;

        public HtmlInfoService(string url ) {
            this.Url = url;
            this.web = new HtmlWeb();
        }

        public async Task<List<string>> GetLinksAsync() {
            var document = await web.LoadFromWebAsync(Url);
            List<string> links = new List<string>();
            foreach(HtmlNode link in document.DocumentNode.SelectNodes("//a[@href]")) {
                links.Add(link.Attributes["href"].Value);
            }
            return links;
        }

        public async Task<Dictionary<string, int>> GetTagStatisticsAsync() {
            var document = await web.LoadFromWebAsync(Url);
            Dictionary<string, int> statistics = new Dictionary<string, int>();
            CollectTagStatistics(statistics, document.DocumentNode);
            return statistics;
        }

        private void CollectTagStatistics(Dictionary<string, int> tagStatistics, HtmlNode node) {
            FillStatistics(tagStatistics, node.Name);
            foreach (HtmlNode childNode in node.ChildNodes) {
                CollectTagStatistics(tagStatistics, childNode);
            }
        }

        private  void FillStatistics(Dictionary<string, int> tagStatistics, string name) {
            if (tagStatistics.ContainsKey(name)) {
                tagStatistics[name]++;
            } else {
                tagStatistics.Add(name, 1);
            }
        }
    }
}
