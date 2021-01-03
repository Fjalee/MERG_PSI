using System.IO;
using System.Windows.Forms;

namespace WebScraper
{
    public class FileLog : ILog
    {
        private readonly string _fileNameLogMsg = @"log_Msg.txt";
        private readonly string _fileNameLogAdInvalid = @"log_AdInvalid.txt";
        private readonly string _fileNameLogIEnCountInvalid = @"log_IEnCountInvalid.txt";
        private readonly string _fileNameLogCantParse = @"log_CantParse.txt";
        private readonly string _fileNameLogErrorNoDocument = @"log_ErrorNoDocument.txt";
        private readonly string _fileNameLogDnContainCoords = @"log_DnContainCoords.txt";

        public FileLog()
        {
            DelFileIfExist(_fileNameLogMsg);
            DelFileIfExist(_fileNameLogAdInvalid);
            DelFileIfExist(_fileNameLogIEnCountInvalid);
            DelFileIfExist(_fileNameLogCantParse);
            DelFileIfExist(_fileNameLogErrorNoDocument);
            DelFileIfExist(_fileNameLogDnContainCoords);
        }

        public void Msg(string message)
        {
            using (var w = File.AppendText(_fileNameLogMsg))
            {
                w.WriteLine(message);
            }
        }

        public void AdInvalid(string link, string mapLink, int numberOfRooms, double scrapedPrice, double pricePerSqM,
            double area, double latitude, double longitude, string municipality, string microdistrict, string street)
        {
            var message = $"Link|    {link}\n" +
                $"MapLink|    {mapLink}\n" +
                $"NumberOfRooms|    {numberOfRooms}\n" +
                $"ScrapedPrice|    {scrapedPrice}\n" +
                $"PricePerSqM|    {pricePerSqM}\n" +
                $"Area|    {area}\n" +
                $"Coordinates|    {latitude},{longitude}\n" +
                $"Municipality|    {municipality}\n" +
                $"Street|    {street}\n" +
                $"Microdisctrict|    {microdistrict}\n";

            using (var w = File.AppendText(_fileNameLogAdInvalid))
            {
                w.WriteLine(message);
            }
        }

        public void IEnCountInvalid(string link, int count, string name)
        {
            var message = $"Invalid IEnumerable count: {name} count is {count}\n{link}";

            using (var w = File.AppendText(_fileNameLogIEnCountInvalid))
            {
                w.WriteLine(message);
            }
        }

        public void CantParse(string valToParse)
        {
            var message = $"Couldn't parse value: \"{valToParse}\"";

            using (var w = File.AppendText(_fileNameLogCantParse))
            {
                w.WriteLine(message);
            }
        }

        public void ErrorNoDocument()
        {
            var message = "Didnt get IHTMLDocument first";

            using (var w = File.AppendText(_fileNameLogErrorNoDocument))
            {
                w.WriteLine(message);
            }

            MessageBox.Show("Didnt get IHTMLDocument first", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void DnContainCoords(string link)
        {
            var message = $"Link doesn't contain coordinates: \"{link}\"";

            using (var w = File.AppendText(_fileNameLogDnContainCoords))
            {
                w.WriteLine(message);
            }
        }

        private void DelFileIfExist(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
    }
}