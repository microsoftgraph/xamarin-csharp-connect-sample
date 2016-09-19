# Microsoft Graph Connect Sample for Xamarin Forms

##Table of contents

* [Introduction](#introduction)
* [Prerequisites](#prerequisites)
* [Register and configure the app](#register)
* [Build and debug](#build)
* [Questions and comments](#questions)
* [Additional resources](#additional-resources)

<a name="introduction"></a>
##Introduction

This sample shows how to connect a Xamarin Forms app to a Microsoft work or school (Azure Active Directory) or personal (Microsoft) account using the Microsoft Graph API to send an email. It uses the [Microsoft Graph .NET Client SDK](https://github.com/microsoftgraph/msgraph-sdk-dotnet) to work with data returned by Microsoft Graph.

In addition, the sample uses the [Microsoft Authentication Library (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client/) for authentication. The MSAL SDK provides features for working with the [Azure AD v2.0 endpoint](https://msdn.microsoft.com/office/office365/howto/authenticate-Office-365-APIs-using-v2), which enables developers to write a single code flow that handles authentication for both users' work or school and personal accounts.

If you'd like to work with MSAL in a Xamarin Forms app of your own, follow [these instructions for setting up a Xamarin Forms project with MSAL](https://github.com/microsoftgraph/xamarin-csharp-connect-sample/wiki/Set-up-a-Xamarin-Forms-project-to-use-the-MSAL-.NET-SDK).

 > **Note** The MSAL SDK is currently in prerelease, and as such should not be used in production code. It is used here for illustrative purposes only.


<a name="prerequisites"></a>
## Prerequisites ##

This sample requires the following:  

  * [Visual Studio 2015](https://www.visualstudio.com/downloads) 
  * [Xamarin for Visual Studio](https://www.xamarin.com/visual-studio)
  * Windows 10 ([development mode enabled](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
  * Either a [Microsoft](https://www.outlook.com) or [Office 365 for business account](https://msdn.microsoft.com/office/office365/howto/setup-development-environment#bk_Office365Account)

If you want to run the iOS project in this sample, you'll need the following:

  * The latest iOS SDK
  * The latest version of Xcode
  * Mac OS X Yosemite(10.10) & above 
  * [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/)
  * A [Xamarin Mac agent connected to Visual Studio](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)

You can use the [Visual Studio Emulator for Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) if you want to run the Android project.

<a name="register"></a>
##Register and configure the app

1. Sign into the [App Registration Portal](https://apps.dev.microsoft.com/) using either your personal or work or school account.
2. Select **Add an app**.
3. Enter a name for the app, and select **Create application**.
	
	The registration page displays, listing the properties of your app.
 
4. Under **Platforms**, select **Add platform**.
5. Select **Mobile application**.
6. Copy the Client Id (App Id) value to the clipboard. You'll need to enter these values into the sample app.

	The app id is a unique identifier for your app.

7. Select **Save**.

<a name="build"></a>
## Build and debug ##

**Note:** If you see any errors while installing packages during step 2, make sure the local path where you placed the solution is not too long/deep. Moving the solution closer to the root of your drive resolves this issue.

1. Open the App.cs file inside the **XamarinConnect (Portable)** project of the solution.

    ![](/readme-images/Appdotcs.png "Open App.cs file in XamarinConnect project")

2. After you've loaded the solution in Visual Studio, configure the sample to use the client id that you registered by making this the value of the **ClientId** variable in the App.cs file.


    ![](/readme-images/appId.png "Client ID value in App.cs file")

3. Select the project that you want to run. If you select the Universal Windows Platform option, you can run the sample on the local machine. If you want to run the iOS project, you'll need to connect to a [Mac that has the Xamarin tools](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/) installed on it. (You can also open this solution in Xamarin Studio on a Mac and run the sample directly from there.) You can use the [Visual Studio Emulator for Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) if you want to run the Android project. 

    ![](/readme-images/SelectProject.png "Select project in Visual Studio")

4. Press F5 to build and debug. Run the solution and sign in with either your personal or work or school account.
    > **Note** You might have to open the Build Configuration Manager to make sure that the Build and Deploy steps are selected for the UWP project.

| UWP | Android | iOS |
| --- | ------- | ----|
| <img src="/readme-images/UWP.png" alt="Connect sample on UWP" width="100%" /> | <img src="/readme-images/Droid.png" alt="Connect sample on Android" width="100%" /> | <img src="/readme-images/iOS.png" alt="Connect sample on iOS" width="100%" /> |

###Summary of key methods

The code in the main page of the app is relatively straight-forward and self-explanatory, as the calls for authentication and email service actually occur in the helper classes. The main page code primarily consists of event handlers for the two buttons:

- **OnSignInSignOut**
	
	When the Text value of this button is "connect," this method calls the **GetAuthenticatedClient** method to acquire a **GraphServicesClient** object representing the current user, which it uses to set user email address and display name. If this is successful, it also enables the **send mail** button and the text box where the user can enter an email address, and populates that text box with the user's own email address.

- **MailButton_Click**
	
	This method calls the **ComposeAndSendMailAsync** method, using the email address and display name variables set during **ConnectButton_Click**. If this method call is successful, it also updates the UI text accordingly.

With that in mind, it's worth looking at two methods in the helper classes in a little more detail:

- **GetAuthenticatedClient**
	
	This method of the **AuthenticationHelper** class authenticates the user with the Microsoft Authentication Library (MSAL).

	It does this by retrieving an authentication token from an MSAL **PublicClientApplication** object and then passing that token to a Microsoft Graph **DelegateAuthenticationProvider** object.

	The **SignInCurrentUserAsync** method on the main page can then read the user from this **GraphServicesClient** object and set the user email address and display name.

- **ComposeAndSendMailAsync**

	This method of the **MailHelper** class composes and sends the sample email.

<a name="contributing"></a>
## Contributing ##

If you'd like to contribute to this sample, see [CONTRIBUTING.MD](/CONTRIBUTING.md).

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<a name="questions"></a>
## Questions and comments

We'd love to get your feedback about the Microsoft Graph Connect Sample for Xamarin Forms project. You can send your questions and suggestions to us in the [Issues](https://github.com/MicrosoftGraph/xamarin-csharp-connect-sample/issues) section of this repository.

Your feedback is important to us. Connect with us on [Stack Overflow](http://stackoverflow.com/questions/tagged/office365+or+microsoftgraph). Tag your questions with [MicrosoftGraph].

<a name="additional-resources"></a>
## Additional resources ##

- [Other Microsoft Graph Connect samples](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Microsoft Graph overview](http://graph.microsoft.io)
- [Office developer code samples](http://dev.office.com/code-samples)
- [Office dev center](http://dev.office.com/)


## Copyright
Copyright (c) 2016 Microsoft. All rights reserved.


