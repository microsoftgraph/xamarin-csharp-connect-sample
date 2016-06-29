//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
//See LICENSE in the project root for license information.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamarinConnect;

namespace ConnectUnitTests
{
    [TestClass]
    public class UnitTests
    {
        private static string AccessToken = null;
        private static string ClientId = System.Environment.GetEnvironmentVariable("test_client_id");
        private static string UserName = System.Environment.GetEnvironmentVariable("test_user_name");
        private static string Password = System.Environment.GetEnvironmentVariable("test_password");
        private static string ContentType = "application/x-www-form-urlencoded";
        private static string GrantType = "password";
        private static string TokenEndpoint = "https://login.microsoftonline.com/common/oauth2/token";
        private static string ResourceId = "https%3A%2F%2Fgraph.microsoft.com%2F";

        [TestMethod]
        public void TestComposePersonalizedMail()
        {
            App.Username = "MOD Administrator";
            var testMessage = MainPage.ComposePersonalizedMail();
            StringAssert.Contains(testMessage, "Hello, MOD Administrator!");

        }


        [TestMethod]
        public void getAccessTokenUsingPasswordGrant()
        {
            JObject jResult = null;
            String urlParameters = String.Format(
                    "grant_type={0}&resource={1}&client_id={2}&username={3}&password={4}",
                    GrantType,
                    ResourceId,
                    ClientId,
                    UserName,
                    Password
            );

            HttpClient client = new HttpClient();
            var createBody = new StringContent(urlParameters, System.Text.Encoding.UTF8, ContentType);
            Task<HttpResponseMessage> requestTask = client.PostAsync(TokenEndpoint, createBody);
            requestTask.Wait();
            HttpResponseMessage response = requestTask.Result;

            if (response.IsSuccessStatusCode)
            {
                Task<string> responseTask = response.Content.ReadAsStringAsync();
                responseTask.Wait();
                string responseContent = responseTask.Result;
                jResult = JObject.Parse(responseContent);
            }
            AccessToken = (string)jResult["access_token"];

            if (!String.IsNullOrEmpty(AccessToken))
            {
                //Set AuthenticationHelper values so that the regular MSAL auth flow won't be triggered.
                AuthenticationHelper.TokenForUser = AccessToken;
                AuthenticationHelper.expiration = DateTimeOffset.UtcNow.AddHours(5);
            }

            Assert.IsNotNull(AccessToken);
        }

        [TestMethod]
        public void sendMessage()
        {
            var mailHelper = new MailHelper();
            bool isComplete = false;
            try
            {
                Task mailTask = mailHelper.ComposeAndSendMailAsync("Email sent from test in xamarin connect sample", "<html><body>The body of the test email</body ></html>", "admin@mod182601.onmicrosoft.com");
                mailTask.Wait();
                isComplete = mailTask.IsCompleted;

            }

            catch (Exception e)
            {
                Assert.Fail();
            }

            Assert.IsTrue(isComplete);
        }


    }
}
