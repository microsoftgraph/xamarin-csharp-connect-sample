//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
//See LICENSE in the project root for license information.

using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinConnect
{
    public class App : Application
    {
        public static PublicClientApplication IdentityClientApp = null;
        public static string ClientID = "ENTER_YOUR_CLIENT_ID";
        public static string[] Scopes = { "User.Read", "Mail.Send" };
        public static string Username = string.Empty;
        public static string UserEmail = string.Empty;
        public App()
        {
            IdentityClientApp = new PublicClientApplication(ClientID);
            MainPage = new NavigationPage(new XamarinConnect.MainPage());
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
