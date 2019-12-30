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

[assembly:ExportRenderer(typeof(BorderEntry),typeof(PLBorderEntry))]
namespace VisualView.Droid.CustomRender
{
    class PLBorderEntry:EntryRenderer
    {
        public PLBorderEntry(Context context):base(context)
        {
                
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control.FocusChange += Control_FocusChange;

            var shap = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
            shap.Paint.Color = Xamarin.Forms.Color.Black.ToAndroid();
            shap.Paint.SetStyle(Android.Graphics.Paint.Style.Stroke);

            GradientDrawable gd = new GradientDrawable();
            gd.SetCornerRadius(10);
            gd.SetStroke(2, Android.Graphics.Color.Black);
            gd.SetColor(Color.White.ToAndroid());

            Control.Background = gd;
        }

        private void Control_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetCornerRadius(10);
                gd.SetStroke(2, Android.Graphics.Color.Blue);
                gd.SetColor(Color.White.ToAndroid());
                Control.SetBackground(gd);
                Control.SetTextColor(Android.Graphics.Color.Black);
            }
            else
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetCornerRadius(10);
                gd.SetStroke(2, Android.Graphics.Color.Black);
                gd.SetColor(Color.White.ToAndroid());
                Control.SetBackground(gd);
                Control.SetTextColor(Android.Graphics.Color.Blue);
            }
        }
    }
}