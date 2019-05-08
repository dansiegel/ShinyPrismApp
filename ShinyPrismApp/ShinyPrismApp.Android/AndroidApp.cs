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
using Shiny;
using ShinyPrismApp.Services;

namespace ShinyPrismApp.Droid
{
    [Application]
    class AndroidApp : Application
    {
        public AndroidApp()
        {
        }

        protected AndroidApp(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            AndroidShinyHost.Init(this, new ShinyStartup());
        }
    }
}