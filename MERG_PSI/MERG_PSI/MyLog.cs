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
        //fix relative path
        static string _fileName = @"C:\Users\Rytis\Documents\MyDocuments\MyApps\MERG_PSI\MERG_PSI\MERG_PSI\bin\Debug\log.txt";

        static MyLog()
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
        }
        
        static public void Msg(string message)
        {
            using (StreamWriter w = File.AppendText(_fileName))
            {
                w.WriteLine(message);
            }
        }
       
        static public void AdInvalid(string link, string mapLink, int numberOfRooms, double scrapedPrice, double pricePerSqM, double area, string municipality, string street)
        {
            using (StreamWriter w = File.AppendText(_fileName))
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

                w.WriteLine(message);
            }
        }
        
        static public void IEnCountInvalid(string link, int count, string name)
        {
            using (StreamWriter w = File.AppendText(_fileName))
            {
                var message = $"Invalid IEnumerable count: {name} count is {count}\n{link}\n\n";

                w.WriteLine(message);
            }
        }
        
        static public void CantParse(string valToParse)
        {
            using (StreamWriter w = File.AppendText(_fileName))
            {
                var message = $"Couldn't parse value: \"{valToParse}\"\n\n";

                w.WriteLine(message);
            }
        }

        static public void ErrorNoDocument()
        {
            using (StreamWriter w = File.AppendText(_fileName))
            {
                w.WriteLine("Didnt get IHTMLDocument first");
            }

            MessageBox.Show("Didnt get IHTMLDocument first", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
