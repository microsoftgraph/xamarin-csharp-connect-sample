//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
//See LICENSE in the project root for license information.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamarinConnect;

namespace ConnectUnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestComposePersonalizedMail()
        {
            App.Username = "MOD Administrator";
            var testMessage = MainPage.ComposePersonalizedMail();
            StringAssert.Contains(testMessage, "Hello, MOD Administrator!");

        }
    }
}
