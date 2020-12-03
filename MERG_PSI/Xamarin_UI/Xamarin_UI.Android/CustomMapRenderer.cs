using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;
using Xamarin_UI.services;

namespace Xamarin_UI.Droid
{
    class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        List<CustomPin> customPins;
        Context con;
        public CustomMapRenderer(Context context) : base(context)
        {
            con = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {

            base.OnElementChanged(e);

            con.SetTheme(5);
            if (e.OldElement != null)
            {
               // NativeMap.InfoWindowClick -= OnInfoWindowClick;
               NativeMap.InfoWindowClick -=  OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (Xamarin_UI.services.CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
            }
        }
        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            //NativeMap.InfoWindowClick += OnInfoWindowClick;
            NativeMap.SetInfoWindowAdapter(this);
        }
        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            //marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin));
            return marker;
        }

        void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var customPin = GetCustomPin(e.Marker);
            //if (customPin == null)
            //{
            //    throw new Exception("Custom pin not found");
            //}

            //if (!string.IsNullOrWhiteSpace(customPin.Url))
            //{
            //    var url = Android.Net.Uri.Parse(customPin.Url);
            //    var intent = new Intent(Intent.ActionView, url);
            //    intent.AddFlags(ActivityFlags.NewTask);
            //    Android.App.Application.Context.StartActivity(intent);
            //}
        }

        private object GetCustomPin(Marker marker)
        {
            return marker;
         }

        //private object GetCustomPin(Marker marker)
        //{
        //    throw new NotImplementedException();
        //}

        //public Android.Views.View GetInfoContents(Marker marker)
        //{
        //    var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
        //    if (inflater != null)
        //    {
        //        Android.Views.View view;

        //        var customPin = GetCustomPin(marker);
        //        if (customPin == null)
        //        {
        //            throw new Exception("Custom pin not found");
        //        }

        //        if (customPin.Name.Equals("Xamarin"))
        //        {
        //            view = inflater.Inflate(Resource.Layout.XamarinMapInfoWindow, null);
        //        }
        //        else
        //        {
        //            view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
        //        }

        //        var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
        //        var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

        //        if (infoTitle != null)
        //        {
        //            infoTitle.Text = marker.Title;
        //        }
        //        if (infoSubtitle != null)
        //        {
        //            infoSubtitle.Text = marker.Snippet;
        //        }

        //        return view;
        //    }
        //    return null;
        //}

        public View GetInfoWindow(Marker marker)
        {
            throw new NotImplementedException();
        }

        public View GetInfoContents(Marker marker)
        {
            throw new NotImplementedException();
        }
    }


        //protected override void OnMapReady(GoogleMap map)
        //{
        //    base.OnMapReady(map);

        //    NativeMap.InfoWindowClick += OnInfoWindowClick;
        //    NativeMap.SetInfoWindowAdapter(this);
        //}

    
}