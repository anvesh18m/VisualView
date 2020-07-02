using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace innomick.CustomeControls
{
    public class CFrame : Frame
    {
        public static new readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CFrame), typeof(CornerRadius), typeof(CFrame));

        public CFrame()
        {
            // MK Clearing default values (e.g. on iOS it's 5)
            base.CornerRadius = 0;
        }

        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
