using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using MERG_BackEnd;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms_UI
{
    public partial class Form1 : Form
    {
        private readonly GMapOverlay _markOverlay = new GMapOverlay("marker");
        private readonly List<RealEstate> _data = new Data().SampleData;

        public Form1()
        {
            InitializeComponent();
            MapLoad();
            LoadMarkers(_data);
        }

        private void MapLoad()
        {
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            map.Position = new PointLatLng(55.233400, 23.894970);
        }

        private void LoadMarkers(List<RealEstate> filteredList)
        {
            _markOverlay.Markers.Clear();
            map.Overlays.Remove(_markOverlay);
            foreach (var ad in filteredList)
            {
                var marker = new GMarkerGoogle(new PointLatLng(ad.Latitude, ad.Longitude), GMarkerGoogleType.red);
                marker.ToolTip = new GMapRoundedToolTip(marker);
                marker.ToolTipText = ad.ToString();
                marker.ToolTip.Fill = Brushes.Black;
                marker.ToolTip.Foreground = Brushes.White;
                marker.ToolTip.Stroke = Pens.Black;
                marker.ToolTip.TextPadding = new Size(20, 20);
                _markOverlay.Markers.Add(marker);
            }
            map.Overlays.Add(_markOverlay);
        }

        #region TextBox Input 
        private void Municipality_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigitLetter(e);
        }

        private void Street_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigitLetter(e);
        }

        private void PriceFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void PriceTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void AreaFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void AreaTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void PricePerSqMFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void PricePerSqMTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void BuildYearFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void BuildYearTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void NumberOfRoomsFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void NumberOfRoomsTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void AllowOnlyKeysControlDigit(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AllowOnlyKeysControlDigitLetter(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }


        #endregion
        #region Prompt text

        private void PriceFrom_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(priceFrom, "Nuo", "", Color.Black);
        }

        private void PriceFrom_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(priceFrom, "", "Nuo", Color.Silver);
        }

        private void PriceTo_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(priceTo, "Iki", "", Color.Black);
        }

        private void PriceTo_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(priceTo, "", "Iki", Color.Silver);
        }

        private void PricePerSqMFrom_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(pricePerSqMFrom, "Nuo", "", Color.Black);
        }

        private void PricePerSqMFrom_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(pricePerSqMFrom, "", "Nuo", Color.Silver);
        }

        private void PricePerSqMTo_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(pricePerSqMTo, "Iki", "", Color.Black);
        }

        private void PricePerSqMTo_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(pricePerSqMTo, "", "Iki", Color.Silver);
        }

        private void BuildYearFrom_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(buildYearFrom, "Nuo", "", Color.Black);
        }

        private void BuildYearFrom_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(buildYearFrom, "", "Nuo", Color.Silver);
        }

        private void BuildYearTo_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(buildYearTo, "Iki", "", Color.Black);
        }

        private void BuildYearTo_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(buildYearTo, "", "Iki", Color.Silver);
        }

        private void NumberOfRoomsFrom_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(numberOfRoomsFrom, "Nuo", "", Color.Black);
        }

        private void NumberOfRoomsFrom_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(numberOfRoomsFrom, "", "Nuo", Color.Silver);
        }

        private void NumberOfRoomsTo_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(numberOfRoomsTo, "Iki", "", Color.Black);
        }

        private void NumberOfRoomsTo_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(numberOfRoomsTo, "", "Iki", Color.Silver);
        }

        private void AreaFrom_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(areaFrom, "Nuo", "", Color.Black);
        }

        private void AreaFrom_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(areaFrom, "", "Nuo", Color.Silver);
        }

        private void AreaTo_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(areaTo, "Iki", "", Color.Black);
        }

        private void AreaTo_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(areaTo, "", "Iki", Color.Silver);
        }
        
        private void SetupTextBoxIf(TextBox textBox, string ifText, string textToSet, Color color)
        {
            if (textBox.Text == ifText)
            {
                textBox.Text = textToSet;
                textBox.ForeColor = color;
            }
        }

        #endregion
        
        private void Search_Click(object sender, EventArgs e)
        {
            var inspection = new Inspection();
            var listOfRealEstate = new Data().SampleData;
            var filtersValue = GetFiltersValue();
            var filteredList = inspection.GetFilteredListOFRealEstate(listOfRealEstate, filtersValue);
            LoadMarkers(filteredList);
        }

        private FiltersValue GetFiltersValue()
        {
            return new FiltersValue(municipality: municipality.Text, microdistrict: microdistrict.Text, street: street.Text,
               priceFrom: priceFrom.Text.ConvertToInt(), priceTo: priceTo.Text.ConvertToInt(),
              areaFrom: areaFrom.Text.ConvertToInt(), areaTo: areaTo.Text.ConvertToInt(),
              buildYearFrom: buildYearFrom.Text.ConvertToInt(), buildYearTo: buildYearTo.Text.ConvertToInt(),
              numberOfRoomsFrom: numberOfRoomsFrom.Text.ConvertToInt(), numberOfRoomsTo: numberOfRoomsTo.Text.ConvertToInt(),
              pricePerSqMFrom: pricePerSqMFrom.Text.ConvertToInt(), pricePerSqMTo: pricePerSqMTo.Text.ConvertToInt(),
              noBuildYearInfo: noInfoBuildYear.Checked, noNumberOfRoomsInfo: noInfoRoomNumber.Checked);
        }

        private void Map_OnMarkerDoubleClick_1(GMapMarker item, MouseEventArgs e)
        {
            var tools = new MERG_BackEnd.Tools();
            tools.OpenLinks(item.Position.Lat, item.Position.Lng, _data);
        }
    }
}