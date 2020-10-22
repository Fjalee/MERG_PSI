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
        static string _fileName = @"log.txt";

        static private List<string> _logMsg = new List<string>();
        static private List<string> _logAdInvalid = new List<string>();
        static private List<string> _logIEnCountInvalid = new List<string>();
        static private List<string> _logCantParse = new List<string>();
        static private List<string> _logErrorNoDocument = new List<string>();
        static private List<string> _logDnContainCoords = new List<string>();

        static MyLog()
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
        }
        
        static public void Msg(string message)
        {
            _logMsg.Add(message + "\n");
        }
       
        static public void AdInvalid(string link, string mapLink, int numberOfRooms, double scrapedPrice, double pricePerSqM, double area, string municipality, string street)
        {
            var message = "Invalid Ad:\n" + 
                $"Link|    {link}\n" +
                $"MapLink|    {mapLink}\n" +
                $"NumberOfRooms|    {numberOfRooms}\n" +
                $"ScrapedPrice|    {scrapedPrice}\n" +
                $"PricePerSqM|    {pricePerSqM}\n" +
                $"Area|    {area}\n" +
                $"Municipality|    {municipality}\n" +
                $"Street|    {street}\n" +
                $"\n";

            _logAdInvalid.Add(message);
        }
        
        static public void IEnCountInvalid(string link, int count, string name)
        {
            var message = $"Invalid IEnumerable count: {name} count is {count}\n{link}\n";

            _logIEnCountInvalid.Add(message);
        }
        
        static public void CantParse(string valToParse)
        {
            var message = $"Couldn't parse value: \"{valToParse}\"\n";

            _logCantParse.Add(message);
        }

        static public void ErrorNoDocument()
        {
            var message = "Didnt get IHTMLDocument first\n";

            _logErrorNoDocument.Add(message);

            MessageBox.Show("Didnt get IHTMLDocument first", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static public void DnContainCoords(string link)
        {
            var message = $"Link doesn't contain coordinates: \"{link}\"\n";

            _logDnContainCoords.Add(message);
        }

        static public void WriteToFile()
        {
            if (_logMsg.Any())
            {
                WriteLineIndcNewLogList("Message");
            }
            WriteAllListElement(_logMsg);

            if (_logAdInvalid.Any())
            {
                WriteLineIndcNewLogList("Ad Invalid");
            }
            WriteAllListElement(_logAdInvalid);

            if (_logIEnCountInvalid.Any())
            {
                WriteLineIndcNewLogList("IEn Count Invalid");
            }
            WriteAllListElement(_logIEnCountInvalid);

            if (_logCantParse.Any())
            {
                WriteLineIndcNewLogList("Can't Parse");
            }
            WriteAllListElement(_logCantParse);

            if (_logErrorNoDocument.Any())
            {
                WriteLineIndcNewLogList("Error: No Document");
            }
            WriteAllListElement(_logErrorNoDocument);

            if (_logDnContainCoords.Any())
            {
                WriteLineIndcNewLogList("Doesn't Contain Coords");
            }
            WriteAllListElement(_logDnContainCoords);
        }

        static private void WriteAllListElement(List<string> list)
        {
            using (StreamWriter w = File.AppendText(_fileName))
            {
                foreach (var element in list)
                {
                    w.WriteLine(element);
                }
            }
        }

        static private void WriteLineIndcNewLogList(string newListIndicator)
        {
            using (StreamWriter w = File.AppendText(_fileName))
            {
                w.WriteLine($"\n-------------------------------\n{newListIndicator}\n\n");
            }
        }
    }
}
