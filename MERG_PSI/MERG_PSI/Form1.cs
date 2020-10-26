using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MERG_PSI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var tekstas = "";
            var Data = (new Data()).SampleData;
            foreach (var eilute in Data)
            {
                tekstas = tekstas + eilute;
            }
            richTextBox1.Text = tekstas;
            map_Load();
            load_markers(Data);
        }

        private void map_Load()
        {
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap; 
            map.Position = new PointLatLng(55.233400, 23.894970);
            //map.MinZoom = 1;
            //map.MaxZoom = 24;
            //map.Zoom = 5;
        }

        private void load_markers(List<RealEstate> filteredList)
        {
            var markOverlay = new GMapOverlay("marker");
            double[] darray = new double[2];

            markOverlay.Markers.Clear();
            foreach (var i in filteredList)
            {
                string[] c = i.MapCoords.Split(',');
                darray[0] = Convert.ToDouble(c[0]);
                darray[1] = Convert.ToDouble(c[1]);
                var marker = new GMarkerGoogle(new PointLatLng(darray[0], darray[1]), GMarkerGoogleType.red);
                marker.ToolTip = new GMapRoundedToolTip(marker);
                marker.ToolTipText = $"Kambariai: {i.NumberOfRooms.ToString()}, miestas: {i.Municipality.ToString()}, plotas: {i.Area.ToString()}, kaina: {i.PricePerSqM.ToString()}\n";
                markOverlay.Markers.Add(marker);
            }
            map.Overlays.Add(markOverlay);
        }

        #region TextBox Input 
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
        private void pricePerSqMFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void pricePerSqMTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void buildYearFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void buildYearTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void numberOfRoomsFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void numberOfRoomsTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion
        #region Prompt text

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
        private void pricePerSqMFrom_Enter(object sender, EventArgs e)
        {
            if (pricePerSqMFrom.Text == "Nuo")
            {
                pricePerSqMFrom.Text = "";
                pricePerSqMFrom.ForeColor = Color.Black;
            }
        }
        private void pricePerSqMFrom_Leave(object sender, EventArgs e)
        {
            if (pricePerSqMFrom.Text == "")
            {
                pricePerSqMFrom.Text = "Nuo";
                pricePerSqMFrom.ForeColor = Color.Silver;
            }
        }
        private void pricePerSqMTo_Enter(object sender, EventArgs e)
        {
            if (pricePerSqMTo.Text == "Iki")
            {
                pricePerSqMTo.Text = "";
                pricePerSqMTo.ForeColor = Color.Black;
            }
        }
        private void pricePerSqMTo_Leave(object sender, EventArgs e)
        {
            if (pricePerSqMTo.Text == "")
            {
                pricePerSqMTo.Text = "Iki";
                pricePerSqMTo.ForeColor = Color.Silver;
            }
        }
        private void buildYearFrom_Enter(object sender, EventArgs e)
        {
            if (buildYearFrom.Text == "Nuo")
            {
                buildYearFrom.Text = "";
                buildYearFrom.ForeColor = Color.Black;
            }
        }
        private void buildYearFrom_Leave(object sender, EventArgs e)
        {
            if (buildYearFrom.Text == "")
            {
                buildYearFrom.Text = "Nuo";
                buildYearFrom.ForeColor = Color.Silver;
            }
        }
        private void buildYearTo_Enter(object sender, EventArgs e)
        {
            if (buildYearTo.Text == "Iki")
            {
                buildYearTo.Text = "";
                buildYearTo.ForeColor = Color.Black;
            }
        }
        private void buildYearTo_Leave(object sender, EventArgs e)
        {
            if (buildYearTo.Text == "")
            {
                buildYearTo.Text = "Iki";
                buildYearTo.ForeColor = Color.Silver;
            }
        }
        private void numberOfRoomsFrom_Enter(object sender, EventArgs e)
        {
            if (numberOfRoomsFrom.Text == "Nuo")
            {
                numberOfRoomsFrom.Text = "";
                numberOfRoomsFrom.ForeColor = Color.Black;
            }
        }
        private void numberOfRoomsFrom_Leave(object sender, EventArgs e)
        {
            if (numberOfRoomsFrom.Text == "")
            {
                numberOfRoomsFrom.Text = "Nuo";
                numberOfRoomsFrom.ForeColor = Color.Silver;
            }
        }
        private void numberOfRoomsTo_Enter(object sender, EventArgs e)
        {
            if (numberOfRoomsTo.Text == "Iki")
            {
                numberOfRoomsTo.Text = "";
                numberOfRoomsTo.ForeColor = Color.Black;
            }
        }
        private void numberOfRoomsTo_Leave(object sender, EventArgs e)
        {
            if (numberOfRoomsTo.Text == "")
            {
                numberOfRoomsTo.Text = "Iki";
                numberOfRoomsTo.ForeColor = Color.Silver;
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

        #endregion


        private void search_Click(object sender, EventArgs e)
        {
            var Inspection = new Inspection();
            var filtersValues = new List<String> {priceFrom.Text, priceTo.Text, areaFrom.Text, areaTo.Text, municipality.Text,street.Text, pricePerSqMFrom.Text, pricePerSqMTo.Text, buildYearFrom.Text,buildYearTo.Text,numberOfRoomsFrom.Text,numberOfRoomsTo.Text};
            var ListOfRealEstate = new Data().SampleData;
            var noInfoBuild = noInfoBuildYear.Checked;
            var noInfoRooms = noInfoRoomNumber.Checked;
            var filteredList = Inspection.GetFilteredListOFRealEstate(ListOfRealEstate, filtersValues, noInfoBuild, noInfoRooms);
            richTextBox1.Text = ListToDisplay(filteredList); 

            load_markers(filteredList);

        }
        private String ListToDisplay (List<RealEstate> RealEstateList)
        {
            var textToPrint = new StringBuilder();
            foreach (var realEstate in RealEstateList)
            {
                textToPrint.Append(realEstate);
            }
            return textToPrint.ToString();
        }

        /*
        private void showAdList_Click(object sender, EventArgs e)
        {
            this.Hide();
            var openForm2 = new Form2();
            openForm2.ShowDialog();
            this.Close();
        }*/
    }
}
