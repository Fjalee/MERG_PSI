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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Windows;

namespace MERG_PSI{
    public partial class Form1 : Form{
        private List<string> tempList = new List<string>();
        WebScraper ws = new WebScraper();

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

