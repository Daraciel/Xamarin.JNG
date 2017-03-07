using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.JNG.Controls;
using Xamarin.JNG.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Ads;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobRenderer))]

namespace Xamarin.JNG.Droid.Renderers
{
    public class AdMobRenderer : ViewRenderer<AdMobView, AdView>
    {
        string adUnitId = string.Empty;
        AdSize adSize = AdSize.SmartBanner;
        AdView adView;

        AdView CreateNativeControl()
        {
            if (adView != null)
                return adView;

            //adUnitId = Context.Resources.GetString(Resource.String.banner_ad_unit_id);
            adUnitId = "ca-app-pub-1175806119674976/7508647842";
            adView = new AdView(Context);
            adView.AdSize = adSize;
            adView.AdUnitId = adUnitId;

            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);

            adView.LayoutParameters = adParams;

            adView.LoadAd(new AdRequest
                            .Builder()
                            .Build());
            return adView;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                CreateNativeControl();
                SetNativeControl(adView);
            }
        }
    }
}