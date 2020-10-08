using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Text;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Windows;

namespace MERG_PSI{
    public partial class Form1 : Form{
        private List<string> tempList = new List<string>();
        private List<string> tempListt = new List<string>();
        adCardLinkScraper ws = new adCardLinkScraper("https://www.kampas.lt", "https://www.kampas.lt/?page=10", "k-ad-card-wide");


        public Form1()
        {
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            tempList = ws.getUrls();
            foreach (var temp in tempList){
                richTextBox3.AppendText(temp);
                richTextBox3.AppendText("\n\n*\n*\n*\n");
            }
        }
    }
}

