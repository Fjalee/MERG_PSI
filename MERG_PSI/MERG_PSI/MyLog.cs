using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MERG_PSI
{
    static class MyLog
    {
        static string _fileNameLogMsg = @"log_Msg.txt";
        static string _fileNameLogAdInvalid = @"log_AdInvalid.txt";
        static string _fileNameLogIEnCountInvalid = @"log_IEnCountInvalid.txt";
        static string _fileNameLogCantParse = @"log_CantParse.txt";
        static string _fileNameLogErrorNoDocument = @"log_ErrorNoDocument.txt";
        static string _fileNameLogDnContainCoords = @"log_DnContainCoords.txt";

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
            using (StreamWriter w = File.AppendText(_fileNameLogMsg))
            {
                w.WriteLine(message);
            }
        }
       
        static public void AdInvalid(string link, string mapLink, int numberOfRooms, double scrapedPrice, double pricePerSqM, double area, string municipality, string street)
        {
            var message = $"Link|    {link}\n" +
                $"MapLink|    {mapLink}\n" +
                $"NumberOfRooms|    {numberOfRooms}\n" +
                $"ScrapedPrice|    {scrapedPrice}\n" +
                $"PricePerSqM|    {pricePerSqM}\n" +
                $"Area|    {area}\n" +
                $"Municipality|    {municipality}\n" +
                $"Street|    {street}\n";

            using (StreamWriter w = File.AppendText(_fileNameLogAdInvalid))
            {
                w.WriteLine(message);
            }
        }
        
        static public void IEnCountInvalid(string link, int count, string name)
        {
            var message = $"Invalid IEnumerable count: {name} count is {count}\n{link}";

            using (StreamWriter w = File.AppendText(_fileNameLogIEnCountInvalid))
            {
                w.WriteLine(message);
            }
        }
        
        static public void CantParse(string valToParse)
        {
            var message = $"Couldn't parse value: \"{valToParse}\"";

            using (StreamWriter w = File.AppendText(_fileNameLogCantParse))
            {
                w.WriteLine(message);
            }
        }

        static public void ErrorNoDocument()
        {
            var message = "Didnt get IHTMLDocument first";

            using (StreamWriter w = File.AppendText(_fileNameLogErrorNoDocument))
            {
                w.WriteLine(message);
            }

            MessageBox.Show("Didnt get IHTMLDocument first", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static public void DnContainCoords(string link)
        {
            var message = $"Link doesn't contain coordinates: \"{link}\"";

            using (StreamWriter w = File.AppendText(_fileNameLogDnContainCoords))
            {
                w.WriteLine(message);
            }
        }

        static private void DelFileIfExist(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
    }
}
