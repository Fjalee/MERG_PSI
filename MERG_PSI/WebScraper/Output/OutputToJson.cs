using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WebScraper
{
    public class OutputToJson : IOutput
    {
        private const string _filePath = @"scrapedData.txt";

        public async Task DoOutput(string jsonToOutput)
        {
            using (var writer = new StreamWriter(_filePath))
            {
                await writer.WriteAsync(jsonToOutput);
                writer.Close();
            }
        }
    }
}