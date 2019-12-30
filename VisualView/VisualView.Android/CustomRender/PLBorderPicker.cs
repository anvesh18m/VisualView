using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VisualView.CustomRender;
using VisualView.Droid.CustomRender;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderPicker), typeof(PLBorderPicker))]
namespace VisualView.Droid.CustomRender
{
    class PLBorderPicker:PickerRenderer
    {
        public PLBorderPicker(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            var shap = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
            shap.Paint.Color = Xamarin.Forms.Color.Black.ToAndroid();
            shap.Paint.SetStyle(Android.Graphics.Paint.Style.Stroke);

            GradientDrawable gd = new GradientDrawable();
            gd.SetCornerRadius(10);
            gd.SetStroke(2, Android.Graphics.Color.Black);
            gd.SetColor(Color.White.ToAndroid());

            Control.Background = gd;
        }

    }
}