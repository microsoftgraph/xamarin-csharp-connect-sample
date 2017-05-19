# <a name="microsoft-graph-connect-sample-for-xamarin-forms"></a>Microsoft Graph Connect 範例 (適用於 Xamarin Forms)

##<a name="table-of-contents"></a>目錄

* [簡介](#introduction)
* [必要條件](#prerequisites)
* [註冊和設定應用程式](#register)
* [建置及偵錯](#build)
* [問題和建議](#questions)
* [其他資源](#additional-resources)

<a name="introduction"></a>
##<a name="introduction"></a>簡介

這個範例示範如何使用 Microsoft Graph API 將 Xamarin Forms 應用程式連線至 Microsoft 工作或學校 (Azure Active Directory) 或個人 (Microsoft) 帳戶，以傳送郵件。它會使用 [Microsoft Graph.NET 用戶端 SDK](https://github.com/microsoftgraph/msgraph-sdk-dotnet)，使用 Microsoft Graph 所傳回的資料。

此外，範例會使用 [Microsoft 驗證程式庫 (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client/) 進行驗證。MSAL SDK 提供功能以使用 [Azure AD v2.0 端點](https://msdn.microsoft.com/office/office365/howto/authenticate-Office-365-APIs-using-v2)，可讓開發人員撰寫單一程式碼流程，處理使用者的工作或學校和個人帳戶的驗證。

如果您想要在自己的 Xamarin Forms 應用程式中使用 MSAL，請遵循[這些指示以設定 Xamarin Forms 專案與 MSAL](https://github.com/microsoftgraph/xamarin-csharp-connect-sample/wiki/Set-up-a-Xamarin-Forms-project-to-use-the-MSAL-.NET-SDK)。

 > **附註** MSAL SDK 目前是發行前版本，因此不應該用於實際執行程式碼。在這裡僅供說明目的使用。


<a name="prerequisites"></a>
## <a name="prerequisites"></a>必要條件 ##

此範例需要下列項目：  

  * [Visual Studio 2015](https://www.visualstudio.com/downloads) 
  * [Xamarin for Visual Studio](https://www.xamarin.com/visual-studio)
  * Windows 10 ([已啟用開發模式](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
  * [Microsoft](https://www.outlook.com) 或[商務用 Office 365 帳戶](https://msdn.microsoft.com/office/office365/howto/setup-development-environment#bk_Office365Account)

如果您想要執行這個範例中的 iOS 專案，您需要下列項目：

  * 最新的 iOS SDK
  * 最新版本的 Xcode
  * Mac OS X Yosemite(10.10) 和更新版本 
  * [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/)
  * [連接至 Visual Studio 的 Xamarin Mac 代理程式](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)

如果您想要執行 Android 專案，您可以使用[適用於 Android 的 Visual Studio 模擬器](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx)。

<a name="register"></a>
##<a name="register-and-configure-the-app"></a>註冊和設定應用程式

1. 使用您的個人或工作或學校帳戶登入[應用程式註冊入口網站](https://apps.dev.microsoft.com/)。
2. 選取 [新增應用程式]****。
3. 為應用程式輸入名稱，然後選取 [建立應用程式]****。
    
    [註冊] 頁面隨即顯示，列出您的應用程式的屬性。
 
4. 在 [平台]**** 底下，選取 [新增平台]****。
5. 選取 [行動應用程式]****。
6. 將用戶端識別碼 (應用程式識別碼) 值複製到剪貼簿。您必須將這些值輸入範例應用程式中。

    應用程式識別碼是您的應用程式的唯一識別碼。

7. 選取 [儲存]****。

<a name="build"></a>
## <a name="build-and-debug"></a>建置和偵錯 ##

**附註︰**如果您在步驟 2 安裝封裝時看到任何錯誤，請確定您放置解決方案的本機路徑不會太長/太深。將解決方案移靠近您的磁碟機根目錄可解決這個問題。

1. 開啟解決方案的 **XamarinConnect (可攜式)** 專案內的 App.cs 檔案。

    ![](/readme-images/Appdotcs.png "Open App.cs file in XamarinConnect project")

2. 在 Visual Studio 中載入解決方案之後，設定範例以使用用戶端識別碼，該識別碼是您藉由讓其成為 App.cs 檔案中的 **ClientId** 變數的值來註冊的。


    ![](/readme-images/appId.png "Client ID value in App.cs file")

3. 選取您要執行的專案。如果您選取 [通用 Windows 平台] 選項，您可以在本機機器上執行範例。如果您想要執行 iOS 專案，您必須連接至[已安裝 Xamarin 工具的 Mac](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)。(您也可以在 Mac 上，在 Xamarin Studio 中開啟此解決方案，然後直接從那裡執行範例。)如果您想要執行 Android 專案，您可以使用[適用於 Android 的 Visual Studio 模擬器](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx)。 

    ![](/readme-images/SelectProject.png "Select project in Visual Studio")

4. 按 F5 進行建置和偵錯。執行解決方案並且登入您的個人或工作或學校帳戶。
    > **附註** 您可能必須開啟組建組態管理員，以確定針對 UWP 專案選取建置和部署步驟。

| UWP | Android | iOS |
| --- | ------- | ----|
| <img src="/readme-images/UWP.png" alt="Connect sample on UWP" width="100%" /> | <img src="/readme-images/Droid.png" alt="Connect sample on Android" width="100%" /> | <img src="/readme-images/iOS.png" alt="Connect sample on iOS" width="100%" /> |

###<a name="summary-of-key-methods"></a>主要方法的摘要

應用程式的主頁面中的程式碼相當直覺且淺顯易懂，因為驗證和電子郵件服務的呼叫確實在協助程式類別中發生。主頁面程式碼主要包含兩個按鈕的事件處理常式：

- **OnSignInSignOut**
    
    當此按鈕的文字值為「連接」時，此方法會呼叫 **GetAuthenticatedClient** 方法以取得 **GraphServicesClient** 物件，代表目前的使用者，用來設定使用者電子郵件地址和顯示名稱。如果成功，它也可以啟用 [傳送郵件]**** 按鈕和使用者可以在其中輸入電子郵件地址的文字方塊，並且在該文字方塊中填入使用者自己的電子郵件地址。

- **MailButton_Click**
    
    這個方法會呼叫 **ComposeAndSendMailAsync** 方法，使用在 **ConnectButton_Click** 期間設定的電子郵件地址和顯示名稱變數。如果這個方法呼叫成功，它也會據以更新 UI 文字。

謹記這一點，再詳細一些查看協助程式類別中的兩種方法很值得：

- **GetAuthenticatedClient**
    
    **AuthenticationHelper** 類別的這個方法會使用 Microsoft 驗證程式庫 (MSAL) 驗證使用者。

    其作法是從 MSAL **PublicClientApplication** 物件擷取驗證權杖，然後將該權杖傳遞至 Microsoft Graph **DelegateAuthenticationProvider** 物件。

    然後主頁面上的 **SignInCurrentUserAsync** 方法可以從這個 **GraphServicesClient** 物件讀取使用者，然後設定使用者的電子郵件地址和顯示名稱。

- **ComposeAndSendMailAsync**

    **MailHelper** 類別的這個方法會撰寫並傳送範例電子郵件。

<a name="contributing"></a>
## <a name="contributing"></a>參與 ##

如果您想要參與這個範例，請參閱 [CONTRIBUTING.MD](/CONTRIBUTING.md)。

此專案已採用 [Microsoft 開放原始碼執行](https://opensource.microsoft.com/codeofconduct/)。如需詳細資訊，請參閱[程式碼執行常見問題集](https://opensource.microsoft.com/codeofconduct/faq/)，如果有其他問題或意見，請連絡 [opencode@microsoft.com](mailto:opencode@microsoft.com)。

<a name="questions"></a>
## <a name="questions-and-comments"></a>問題和建議

我們很樂於收到您對於 Microsoft Graph Connect 範例 (適用於 Xamarin Forms) 專案的意見反應。您可以在此儲存機制的[問題](https://github.com/MicrosoftGraph/xamarin-csharp-connect-sample/issues)區段中，將您的問題及建議傳送給我們。

我們很重視您的意見。請透過 [Stack Overflow](http://stackoverflow.com/questions/tagged/office365+or+microsoftgraph) 與我們連絡。以 [MicrosoftGraph] 標記您的問題。

<a name="additional-resources"></a>
## <a name="additional-resources"></a>其他資源 ##

- [其他 Microsoft Graph connect 範例](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Microsoft Graph 概觀](http://graph.microsoft.io)
- [Office 開發人員程式碼範例](http://dev.office.com/code-samples)
- [Office 開發人員中心](http://dev.office.com/)


## <a name="copyright"></a>著作權
Copyright (c) 2016 Microsoft.著作權所有，並保留一切權利。


