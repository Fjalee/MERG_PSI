using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms.ToolTips;

namespace MERG_PSI
{
    public partial class Form1 : Form
    {
        GMapOverlay markOverlay = new GMapOverlay("marker");
        public Form1()
        {
            //var markOverly = new GMapOverlay("marker");
            InitializeComponent();
            map_Load();
            

            webBrowser2.Navigate("http://maps.google.com/maps?q=Lietuva%22");
            webBrowser2.ScriptErrorsSuppressed = true;
            
            /*
            var tekstas = "";
            var Data = (new Data()).SampleData;
            Data.Add();
            foreach (var eilute in Data)
            {
                tekstas = tekstas + eilute;
            }
            richTextBox1.Text = tekstas;
            */
            //load_markers();
        }

        private void map_Load()
        {
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap; //or BingMap
            //map.SetPositionByKeywords("Kaunas, Lithuania");
            map.Position = new PointLatLng(55.233400, 23.894970);//kaunas
            map.MinZoom = 1;
            map.MaxZoom = 24;
            map.Zoom = 5;
            

        }

        private void load_markers(List<RealEstate> filteredList)
        {
            double[] darray = new double[2];

            markOverlay.Markers.Clear();
            foreach (var i in filteredList)
            {
                string[] c = i.Coordinates.Split(',');
                darray[0] = Convert.ToDouble(c[0]);
                darray[1] = Convert.ToDouble(c[1]);
                var marker = new GMarkerGoogle(new PointLatLng(darray[0],darray[1]), GMarkerGoogleType.red);
                marker.ToolTip = new GMapRoundedToolTip(marker);
                marker.ToolTipText = $"Kambariai: {i.NumberOfRooms.ToString()}, miestas: {i.City.ToString()}, plotas: {i.Area.ToString()}, kaina: {i.PricePerSqM.ToString()}\n";
                markOverlay.Markers.Add(marker);
            }
            map.Overlays.Add(markOverlay);

        }

        ///----------------------------------------------------------------------------------------------------
        private void municipality_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;
            if (!char.IsControl(ch) && !char.IsLetter(ch) && !char.IsWhiteSpace(ch) && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void street_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;
            if (!char.IsControl(ch) && !char.IsLetter(ch) && !char.IsWhiteSpace(ch) && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void priceFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void priceTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void areaFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void areaTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //--------------------------------------------------------------------------------------------------

        private void priceFrom_Enter(object sender, EventArgs e)
        {
            if (priceFrom.Text == "Nuo")
            {
                priceFrom.Text = "";
                priceFrom.ForeColor = Color.Black;
            }
        }

        private void priceFrom_Leave(object sender, EventArgs e)
        {
            if (priceFrom.Text == "")
            {
                priceFrom.Text = "Nuo";
                priceFrom.ForeColor = Color.Silver;
            }
        }

        private void priceTo_Enter(object sender, EventArgs e)
        {
            if (priceTo.Text == "Iki")
            {
                priceTo.Text = "";
                priceTo.ForeColor = Color.Black;
            }
        }

        private void priceTo_Leave(object sender, EventArgs e)
        {
            if (priceTo.Text == "")
            {
                priceTo.Text = "Iki";
                priceTo.ForeColor = Color.Silver;
            }
        }

        private void areaFrom_Enter(object sender, EventArgs e)
        {
            if (areaFrom.Text == "Nuo")
            {
                areaFrom.Text = "";
                areaFrom.ForeColor = Color.Black;
            }
        }

        private void areaFrom_Leave(object sender, EventArgs e)
        {
            if (areaFrom.Text == "")
            {
                areaFrom.Text = "Nuo";
                areaFrom.ForeColor = Color.Silver;
            }
        }

        private void areaTo_Enter(object sender, EventArgs e)
        {
            if (areaTo.Text == "Iki")
            {
                areaTo.Text = "";
                areaTo.ForeColor = Color.Black;
            }
        }

        private void areaTo_Leave(object sender, EventArgs e)
        {
            if (areaTo.Text == "")
            {
                areaTo.Text = "Iki";
                areaTo.ForeColor = Color.Silver;
            }
        }

        //-------------------------------------------------------------------------------------

        /* private void showAdList_Click(object sender, EventArgs e)
         {
             this.Hide();
             var openForm2 = new Form2();
             openForm2.ShowDialog();
             this.Close();
         }*/

        private void search_Click(object sender, EventArgs e)
        {
            var Inspection = new Inspection();
            var TextBoxes = new List<TextBox> { priceFrom, priceTo, areaFrom, areaTo, municipality };
            var ListOfRealEstate = new Data().SampleData;
            richTextBox1.Text = ListToDisplay(Inspection.GetFilteredList(ListOfRealEstate, TextBoxes));
            var list = Inspection.GetFilteredList(ListOfRealEstate, TextBoxes);

            load_markers(list);
            var town = municipality.Text;
            var streetName = street.Text;
            webBrowser2.ScriptErrorsSuppressed = true;
            try
            {
                var location = new StringBuilder("http://maps.google.com/maps?q=%22");
                if (town != string.Empty)
                {
                    location.Append(town + "," + "+");
                }
                if (streetName != string.Empty)
                {
                    location.Append(streetName + "," + "+");
                }
                webBrowser2.Navigate(location.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "error");
            }
            
        }

        private void municipality_TextChanged(object sender, EventArgs e)
        {

        }

        private void advSearch_Click(object sender, EventArgs e)
        {
              /*var Filter=  new Filters();
              var list = Filter.getSampleData();
              richTextBox1.Text = filteredList.ToString();*/
        }
        private String ListToDisplay (List<RealEstate> RealEstateList)
        {
            var tekstas = "";
            foreach (var eilute in RealEstateList)
            {
                tekstas = tekstas + eilute;
            }
            return tekstas;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        /*
         It looks like you have enabled Internet Explorer Compatibility View. Google Maps will not work correctly unless this is turned off.
        */
    }
}
