using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin_UI.Droid;
using Xamarin_UI.Services;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace Xamarin_UI.Droid
{
    class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        List<CustomPin> customPins;

        public CustomMapRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            NativeMap.InfoWindowClick += OnInfoWindowClick;
            NativeMap.SetInfoWindowAdapter(this);
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Layout.pin9));
            return marker;
        }

        void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var customPin = GetCustomPin(e.Marker);
            if (customPin != null)
            {
                if (!string.IsNullOrWhiteSpace(customPin.Link))
                {
                    var url = Android.Net.Uri.Parse(customPin.Link);
                    var intent = new Intent(Intent.ActionView, url);
                    intent.AddFlags(ActivityFlags.NewTask);
                    Android.App.Application.Context.StartActivity(intent);
                }
            }
            else
            {
                throw new Exception("Custom pin not found");
            }
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            if (Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) is Android.Views.LayoutInflater inflater)
            {
                Android.Views.View view;

                var customPin = GetCustomPin(marker);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

                view = inflater.Inflate(Resource.Layout.XamarinMapInfoWindow, null);


                var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);
                var price = view.FindViewById<TextView>(Resource.Id.Price);
                var area = view.FindViewById<TextView>(Resource.Id.Area);
                var pricePerSqM = view.FindViewById<TextView>(Resource.Id.PricePerSqM);
                var numberOfRooms = view.FindViewById<TextView>(Resource.Id.NumberOfRooms);
                var floor = view.FindViewById<TextView>(Resource.Id.Floor);
                var buildingYear = view.FindViewById<TextView>(Resource.Id.BuildingYear);
                var image = view.FindViewById<ImageView>(Resource.Id.imageView3);

                if (infoSubtitle != null)
                {
                    infoSubtitle.Text = customPin.Address.ToString();
                }
                if (price != null)
                {
                    price.Text = customPin.Price.ToString() + " €";
                }
                if (pricePerSqM != null)
                {
                    pricePerSqM.Text = "(" + customPin.PricePerSqM.ToString() + "  €/m²)";
                }
                if (area != null)
                {
                    area.Text = "Plotas: " + customPin.Area.ToString() + " m²";
                }
                if (numberOfRooms != null)
                {
                    numberOfRooms.Text = "Kambariai: " + customPin.NumberOfRooms.ToString();
                }
                if (floor != null)
                {
                    floor.Text = "Aukštas: " + customPin.Floor.ToString();
                }
                if (buildingYear != null)
                {
                    if (customPin.BuildYear == 0)
                    {
                        buildingYear.Text = "Statybų metai: Nenurodyta";
                    }
                    else
                    {
                        buildingYear.Text = "Statybų metai: " + customPin.BuildYear.ToString() + " m.";
                    }
                }
                if (image != null)
                {
                    var imageBitmap = GetImageBitmapFromUrl(customPin.Image);
                    if (imageBitmap == null)
                    {
                        image.SetBackgroundResource(Resource.Layout.img5);
                    }
                    else
                    {
                        image.SetImageBitmap(imageBitmap);
                    }
                }
                return view;
            }
            return null;
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;
            if (!(url == "null"))
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }
            }
            return imageBitmap;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        CustomPin GetCustomPin(Marker annotation)
        {
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
            foreach (var pin in customPins.Where(pin => pin.Position == position))
            {
                return pin;
            }

            return null;
        }
    }
}
