using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebScraper
{
    public partial class FormsLog : Form, ILog
    {
        public FormsLog()
        {
            this.Show();
            InitializeComponent();
        }

        public void Msg(string message)
        {
            logTextBox.AppendText("\n" + message);
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

            logTextBox.AppendText("\n" + message);
        }

        public void IEnCountInvalid(string link, int count, string name)
        {
            var message = $"Invalid IEnumerable count: {name} count is {count}\n{link}";

            logTextBox.AppendText("\n" + message);
        }

        public void CantParse(string valToParse)
        {
            var message = $"Couldn't parse value: \"{valToParse}\"";

            logTextBox.AppendText("\n" + message);
        }

        public void ErrorNoDocument()
        {
            var message = "Didnt get IHTMLDocument first";

            logTextBox.AppendText("\n" + message);

            MessageBox.Show("Didnt get IHTMLDocument first", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void DnContainCoords(string link)
        {
            var message = $"Link doesn't contain coordinates: \"{link}\"";

            logTextBox.AppendText("\n" + message);
        }
    }
}
