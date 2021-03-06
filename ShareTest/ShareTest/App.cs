﻿using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ShareTest
{
    public class App : Application
    {
        public App()
        {
            var button = new Button
            {
                Text = "Share some text"
            };
                        
            var button1 = new Button
            {
                Text = "Share a link"
            };

            var button2 = new Button
            {
                Text = "Open browser"
            };

            var button3 = new Button
            {
                Text = "Share file"
            };

			var messageLabel = new Label ();

            button.Clicked += (sender, args) =>
            {
                CrossShare.Current.Share("Follow @JamesMontemagno on Twitter", "Share");
            };

            button1.Clicked += (sender, args) =>
            {
                CrossShare.Current.ShareLink("http://motzcod.es", "Checkout my blog", "MotzCod.es");
            };

            button2.Clicked += (sender, args) =>
            {
                CrossShare.Current.OpenBrowser("http://motzcod.es");
            };

            button3.Clicked += async (sender, args) =>
            {
				var fileUri = "https://developer.xamarin.com/recipes/android/data/adapters/offline.pdf";
				var fileName = "offline.pdf";

//				var fileUri = "https://xamarin.com/content/images/pages/branding/assets/xamagon.png";
//				var fileName = "xamagon.png";

				messageLabel.Text = string.Format("Downloading {0}, please wait...", fileName);

				if(await CrossShare.Current.ShareRemoteFile(fileUri, fileName))
					messageLabel.Text = "";
            };

			CrossShare.Current.ShareError += (s, e) => {
				messageLabel.Text = string.Format("Sharing failed: {0}", e.Exception.Message);
			};

            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            XAlign = TextAlignment.Center,
                            Text = "Welcome to Share Plugin Sample!"
                        }, button, button1, button2, button3, messageLabel

                    }
                }
            };
        }
                
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
