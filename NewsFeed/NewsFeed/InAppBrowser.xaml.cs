using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewsFeed
{
    public partial class InAppBrowser : ContentPage
    {
        public InAppBrowser(string url)
        {
            InitializeComponent();
			Browser.Source = url;
        }

		private void backClicked(object sender, EventArgs e)
        {
            // Check to see if there is anywhere to go back to
            if (Browser.CanGoBack)
            {
                Browser.GoBack();
            }
            else
            { // If not, leave the view
                Navigation.PopModalAsync();
            }
        }

        private void forwardClicked(object sender, EventArgs e)
        {
            if (Browser.CanGoForward)
            {
                Browser.GoForward();
            }
        }
        /*
         *  float startX = 0;
        float webViewWidth = 0;

        webView.Touch += (sender, e) => {
            if (e.Event.Action == Android.Views.MotionEventActions.Down) {
                webViewWidth = webView.Width;
                startX = e.Event.GetX ();
            }
            if (e.Event.Action == Android.Views.MotionEventActions.Up) {
                float movement = e.Event.GetX () - startX;
                float offset = webViewWidth / 2;

                if (Math.Abs (movement) > offset) {
                    if (movement < 0) {
                        System.Console.WriteLine ("Left swipe");
                        webView.GoBack ();
                    } else { 
                        System.Console.WriteLine ("Right swipe");
                        webView.GoForward ();
                    }
                }
            }
            e.Handled = false;
        };
        */

    }
}
