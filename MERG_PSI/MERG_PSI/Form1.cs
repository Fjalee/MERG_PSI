using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MERG_PSI
{
    public partial class Form1 : Form
    {
        private readonly GMapOverlay markOverlay = new GMapOverlay("marker");
        public Form1()
        {
            InitializeComponent();
            var data = (new Data()).SampleData;
            Map_Load();
            Load_markers(data);

        }

        private void Map_Load()
        {
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap; 
            map.Position = new PointLatLng(55.233400, 23.894970);
            //map.MinZoom = 1;
            //map.MaxZoom = 24;
            //map.Zoom = 5;
        }

        private void Load_markers(List<RealEstate> filteredList)
        {
            var darray = new double[2];

            markOverlay.Markers.Clear();


            foreach (var i in filteredList)
            {
                var c = i.MapCoords.Split(',');
                darray[0] = double.Parse(c[0]);
                darray[1] = double.Parse(c[1]);
                var marker = new GMarkerGoogle(new PointLatLng(darray[0], darray[1]), GMarkerGoogleType.red);
                marker.ToolTip = new GMapRoundedToolTip(marker);
                marker.ToolTipText = $"Kambariai: {i.NumberOfRooms}, miestas: {i.Municipality}, plotas: {i.Area}, kaina: {i.PricePerSqM}\n";
                markOverlay.Markers.Add(marker);
            }
            map.Overlays.Add(markOverlay);
            
        }

       
        #region TextBox Input 
        private void Municipality_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;
            if (!char.IsControl(ch) && !char.IsLetter(ch) && !char.IsWhiteSpace(ch) && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void Street_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;
            if (!char.IsControl(ch) && !char.IsLetter(ch) && !char.IsWhiteSpace(ch) && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void PriceFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PriceTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AreaFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AreaTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void PricePerSqMFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void PricePerSqMTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void BuildYearFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void BuildYearTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void NumberOfRoomsFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void NumberOfRoomsTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion
        #region Prompt text

        private void PriceFrom_Enter(object sender, EventArgs e)
        {
            if (priceFrom.Text == "Nuo")
            {
                priceFrom.Text = "";
                priceFrom.ForeColor = Color.Black;
            }
        }

        private void PriceFrom_Leave(object sender, EventArgs e)
        {
            if (priceFrom.Text == "")
            {
                priceFrom.Text = "Nuo";
                priceFrom.ForeColor = Color.Silver;
            }
        }

        private void PriceTo_Enter(object sender, EventArgs e)
        {
            if (priceTo.Text == "Iki")
            {
                priceTo.Text = "";
                priceTo.ForeColor = Color.Black;
            }
        }

        private void PriceTo_Leave(object sender, EventArgs e)
        {
            if (priceTo.Text == "")
            {
                priceTo.Text = "Iki";
                priceTo.ForeColor = Color.Silver;
            }
        }
        private void PricePerSqMFrom_Enter(object sender, EventArgs e)
        {
            if (pricePerSqMFrom.Text == "Nuo")
            {
                pricePerSqMFrom.Text = "";
                pricePerSqMFrom.ForeColor = Color.Black;
            }
        }
        private void PricePerSqMFrom_Leave(object sender, EventArgs e)
        {
            if (pricePerSqMFrom.Text == "")
            {
                pricePerSqMFrom.Text = "Nuo";
                pricePerSqMFrom.ForeColor = Color.Silver;
            }
        }
        private void PricePerSqMTo_Enter(object sender, EventArgs e)
        {
            if (pricePerSqMTo.Text == "Iki")
            {
                pricePerSqMTo.Text = "";
                pricePerSqMTo.ForeColor = Color.Black;
            }
        }
        private void PricePerSqMTo_Leave(object sender, EventArgs e)
        {
            if (pricePerSqMTo.Text == "")
            {
                pricePerSqMTo.Text = "Iki";
                pricePerSqMTo.ForeColor = Color.Silver;
            }
        }
        private void BuildYearFrom_Enter(object sender, EventArgs e)
        {
            if (buildYearFrom.Text == "Nuo")
            {
                buildYearFrom.Text = "";
                buildYearFrom.ForeColor = Color.Black;
            }
        }
        private void BuildYearFrom_Leave(object sender, EventArgs e)
        {
            if (buildYearFrom.Text == "")
            {
                buildYearFrom.Text = "Nuo";
                buildYearFrom.ForeColor = Color.Silver;
            }
        }
        private void BuildYearTo_Enter(object sender, EventArgs e)
        {
            if (buildYearTo.Text == "Iki")
            {
                buildYearTo.Text = "";
                buildYearTo.ForeColor = Color.Black;
            }
        }
        private void BuildYearTo_Leave(object sender, EventArgs e)
        {
            if (buildYearTo.Text == "")
            {
                buildYearTo.Text = "Iki";
                buildYearTo.ForeColor = Color.Silver;
            }
        }
        private void NumberOfRoomsFrom_Enter(object sender, EventArgs e)
        {
            if (numberOfRoomsFrom.Text == "Nuo")
            {
                numberOfRoomsFrom.Text = "";
                numberOfRoomsFrom.ForeColor = Color.Black;
            }
        }
        private void NumberOfRoomsFrom_Leave(object sender, EventArgs e)
        {
            if (numberOfRoomsFrom.Text == "")
            {
                numberOfRoomsFrom.Text = "Nuo";
                numberOfRoomsFrom.ForeColor = Color.Silver;
            }
        }
        private void NumberOfRoomsTo_Enter(object sender, EventArgs e)
        {
            if (numberOfRoomsTo.Text == "Iki")
            {
                numberOfRoomsTo.Text = "";
                numberOfRoomsTo.ForeColor = Color.Black;
            }
        }
        private void NumberOfRoomsTo_Leave(object sender, EventArgs e)
        {
            if (numberOfRoomsTo.Text == "")
            {
                numberOfRoomsTo.Text = "Iki";
                numberOfRoomsTo.ForeColor = Color.Silver;
            }
        }
        private void AreaFrom_Enter(object sender, EventArgs e)
        {
            if (areaFrom.Text == "Nuo")
            {
                areaFrom.Text = "";
                areaFrom.ForeColor = Color.Black;
            }
        }

        private void AreaFrom_Leave(object sender, EventArgs e)
        {
            if (areaFrom.Text == "")
            {
                areaFrom.Text = "Nuo";
                areaFrom.ForeColor = Color.Silver;
            }
        }

        private void AreaTo_Enter(object sender, EventArgs e)
        {
            if (areaTo.Text == "Iki")
            {
                areaTo.Text = "";
                areaTo.ForeColor = Color.Black;
            }
        }

        private void AreaTo_Leave(object sender, EventArgs e)
        {
            if (areaTo.Text == "")
            {
                areaTo.Text = "Iki";
                areaTo.ForeColor = Color.Silver;
            }
        }

        #endregion


        private void Search_Click(object sender, EventArgs e)
        {
            var inspection = new Inspection();
            var filtersValues = new List<string> {priceFrom.Text, priceTo.Text, areaFrom.Text, areaTo.Text, municipality.Text,street.Text, pricePerSqMFrom.Text, pricePerSqMTo.Text, buildYearFrom.Text,buildYearTo.Text,numberOfRoomsFrom.Text,numberOfRoomsTo.Text};
            var listOfRealEstate = new Data().SampleData;
            var noInfoBuild = noInfoBuildYear.Checked;
            var noInfoRooms = noInfoRoomNumber.Checked;
            var filteredList = inspection.GetFilteredListOFRealEstate(listOfRealEstate, filtersValues, noInfoBuild, noInfoRooms);
            Load_markers(filteredList);



        }
        //private List<String> GetAdress(PointLatLng point)
        //{
        //    List<Placemark> placemarks = null;
        //    var statusCode = GMapProviders.GoogleMap.GetPlacemarks(point, out placemarks);
        //    if (statusCode == GeoCoderStatusCode.OK && placemarks != null)
        //    {
        //        List<String> addresses = new List<string>();
        //        foreach (var placemark in placemarks)
        //        {
        //            addresses.Add(placemark.Address);
        //        }
        //        return addresses;
        //    }
        //    return null;
        //}


        //       //var address = GetAdress(point)
        //       //String.Join(", ", address.ToArray())
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
