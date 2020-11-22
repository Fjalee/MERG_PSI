using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace WebScraper
{
    static class MyLog
    {
        static readonly string _fileNameLogMsg = @"log_Msg.txt";
        static readonly string _fileNameLogAdInvalid = @"log_AdInvalid.txt";
        static readonly string _fileNameLogIEnCountInvalid = @"log_IEnCountInvalid.txt";
        static readonly string _fileNameLogCantParse = @"log_CantParse.txt";
        static readonly string _fileNameLogErrorNoDocument = @"log_ErrorNoDocument.txt";
        static readonly string _fileNameLogDnContainCoords = @"log_DnContainCoords.txt";

        static readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();

        static MyLog()
        {
            DelFileIfExist(_fileNameLogMsg);
            DelFileIfExist(_fileNameLogAdInvalid);
            DelFileIfExist(_fileNameLogIEnCountInvalid);
            DelFileIfExist(_fileNameLogCantParse);
            DelFileIfExist(_fileNameLogErrorNoDocument);
            DelFileIfExist(_fileNameLogDnContainCoords);
        }

        static public void Msg(string message)
        {
            ThreadSafeWrite(message);
        }

        static public void AdInvalid(string link, string mapLink, int numberOfRooms, double scrapedPrice, double pricePerSqM, double area, string municipality, string street, string mapCoords)
        {
            var message = $"Link|    {link}\n" +
                $"MapLink|    {mapLink}\n" +
                $"NumberOfRooms|    {numberOfRooms}\n" +
                $"ScrapedPrice|    {scrapedPrice}\n" +
                $"PricePerSqM|    {pricePerSqM}\n" +
                $"Area|    {area}\n" +
                $"MapCoodinates|    {mapCoords}\n" +
                $"Municipality|    {municipality}\n" +
                $"Street|    {street}\n";

            ThreadSafeWrite(message);
        }

        static public void IEnCountInvalid(string link, int count, string name)
        {
            var message = $"Invalid IEnumerable count: {name} count is {count}\n{link}";

            ThreadSafeWrite(message);
        }

        static public void CantParse(string valToParse)
        {
            var message = $"Couldn't parse value: \"{valToParse}\"";

            ThreadSafeWrite(message);
        }

        static public void ErrorNoDocument()
        {
            var message = "Didnt get IHTMLDocument first";

            ThreadSafeWrite(message);

            MessageBox.Show("Didnt get IHTMLDocument first", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static public void DnContainCoords(string link)
        {
            var message = $"Link doesn't contain coordinates: \"{link}\"";

            ThreadSafeWrite(message);
        }

        static private void DelFileIfExist(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        static private void ThreadSafeWrite(string text)
        {
            _rwLock.EnterWriteLock();

            try
            {
                using (var w = File.AppendText(_fileNameLogMsg))
                {
                    w.WriteLine(text);
                }
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }
    }
}
