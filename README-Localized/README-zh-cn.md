# <a name="microsoft-graph-connect-sample-for-xamarin-forms"></a>Xamarin Forms 的 Microsoft Graph 连接示例

##<a name="table-of-contents"></a>目录

* [简介](#introduction)
* [先决条件](#prerequisites)
* [注册和配置应用](#register)
* [构建和调试](#build)
* [问题和意见](#questions)
* [其他资源](#additional-resources)

<a name="introduction"></a>
##<a name="introduction"></a>简介

此示例演示如何通过使用 Microsoft Graph API 发送电子邮件来将 Xamarin Forms 应用连接到 Microsoft 工作或学校 (Azure Active Directory) 或个人 (Microsoft) 帐户。它使用 [Microsoft Graph .NET Client SDK](https://github.com/microsoftgraph/msgraph-sdk-dotnet) 以结合使用由 Microsoft Graph 返回的数据。

此外，此示例使用 [Microsoft 身份验证库 (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client/) 进行身份验证。MSAL SDK 提供可使用 [Azure AD v2.0 终结点](https://msdn.microsoft.com/office/office365/howto/authenticate-Office-365-APIs-using-v2)的功能，借助该终结点，开发人员可以编写单个代码流来处理对用户的工作或学校和个人帐户的身份验证。

如果想要在你自己的 Xamarin Forms 应用中使用 MSAL，请遵循 [使用 MSAL 设置 Xamarin Forms 项目的这些说明](https://github.com/microsoftgraph/xamarin-csharp-connect-sample/wiki/Set-up-a-Xamarin-Forms-project-to-use-the-MSAL-.NET-SDK)。

 > **注意** MSAL SDK 目前处于预发布状态，因此，不应该在生产代码中使用。在此处仅用于说明目的。


<a name="prerequisites"></a>
## <a name="prerequisites"></a>先决条件 ##

此示例需要以下各项：  

  * [Visual Studio 2015](https://www.visualstudio.com/downloads) 
  * [Visual Studio 的 Xamarin](https://www.xamarin.com/visual-studio)
  * Windows 10（[已启用开发模式](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx)）
  * [Microsoft](https://www.outlook.com) 或 [Office 365 商业版帐户](https://msdn.microsoft.com/office/office365/howto/setup-development-environment#bk_Office365Account)

如果想要在此示例中运行 iOS 项目，则要求如下：

  * 最新的 iOS SDK
  * Xcode 的最新版本
  * Mac OS X Yosemite (10.10) 和更高版本 
  * [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/)
  * [连接到 Visual Studio 的 Xamarin Mac 代理](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)

如果想要运行 Android 项目，可以使用 [适用于 Android 的 Visual Studio 模拟器](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx)。

<a name="register"></a>
##<a name="register-and-configure-the-app"></a>注册和配置应用

1. 使用个人或工作或学校帐户登录到 [应用注册门户](https://apps.dev.microsoft.com/)。
2. 选择“**添加应用**”。
3. 为应用输入名称，并选择“**创建应用程序**”。
    
    将显示注册页，其中列出应用的属性。
 
4. 在“**平台**”下，选择“**添加平台**”。
5. 选择“**移动应用程序**”。
6. 将客户端 ID（应用 ID）值复制到剪贴板。将需要在示例应用中输入这些值。

    应用 ID 是应用的唯一标识符。

7. 选择“**保存**”。

<a name="build"></a>
## <a name="build-and-debug"></a>构建和调试 ##

**注意：**如果在步骤 2 安装程序包时出现任何错误，请确保放置该解决方案的本地路径并未太长/太深。将解决方案移动到更接近驱动器根目录的位置可以解决此问题。

1. 打开解决方案的 **XamarinConnect（可移植）**项目内的 App.cs 文件。

    ![](/readme-images/Appdotcs.png "Open App.cs file in XamarinConnect project")

2. 在 Visual Studio 中加载解决方案后，通过将注册的客户端 ID 生成为 App.cs 文件中的 **ClientId** 变量来配置使用注册的客户端 ID 的示例。


    ![](/readme-images/appId.png "Client ID value in App.cs file")

3. 选择想要运行的项目。如果选择“通用 Windows 平台”选项，则可以在本地计算机上运行示例。如果想要运行 iOS 项目，则需连接到安装在其上的 [具有 Xamarin 工具的 Mac](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)。（还可以在 Mac 上的 Xamarin Studio 中打开此解决方案并直接从此处运行示例。）如果想要运行 Android 项目，可以使用[适用于 Android 的 Visual Studio 模拟器](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx)。 

    ![](/readme-images/SelectProject.png "Select project in Visual Studio")

4. 按 F5 进行构建和调试。运行此解决方案并使用个人或工作或学校帐户登录。
    > **注意** 可能需要打开生成配置管理器，以确保为 UWP 项目选择“生成”和“部署”步骤。

| UWP | Android | iOS |
| --- | ------- | ----|
| <img src="/readme-images/UWP.png" alt="Connect sample on UWP" width="100%" /> | <img src="/readme-images/Droid.png" alt="Connect sample on Android" width="100%" /> | <img src="/readme-images/iOS.png" alt="Connect sample on iOS" width="100%" /> |

###<a name="summary-of-key-methods"></a>密钥方法摘要

应用主页中的代码相对简单且一目了然，因为对身份验证和电子邮件服务的调用实际出现在帮助程序类中。主页代码主要包括两个按钮的事件处理程序：

- **OnSignInSignOut**
    
    当该按钮的文本值为“连接”时，该方法将调用 **GetAuthenticatedClient** 方法以获取表示当前用户的 **GraphServicesClient** 对象（它将使用该对象设置用户电子邮件地址和显示名称）。如果此操作成功，它还会启用“**发送邮件**”按钮和文本框（用户可以在此处输入电子邮件地址，并使用用户自己的电子邮件地址填充该文本框）。

- **MailButton_Click**
    
    此方法通过在 **ConnectButton_Click** 过程中使用电子邮件地址和显示名称变量设置来调用 **ComposeAndSendMailAsync** 方法。如果此方法调用成功，它还将据此更新 UI 文本。

明确这一点后，更详细了解帮助程序类中的两种方法是有必要的：

- **GetAuthenticatedClient**
    
    **AuthenticationHelper** 类的此方法使用 Microsoft 身份验证库 (MSAL).对用户进行身份验证。

    它通过检索 MSAL **PublicClientApplication** 对象的身份验证令牌，然后将该令牌传递给 Microsoft Graph **DelegateAuthenticationProvider** 对象来实现此操作。

    然后，主页上的 **SignInCurrentUserAsync** 方法可以从该 **GraphServicesClient** 对象读取用户，并设置用户电子邮件地址和显示名称。

- **ComposeAndSendMailAsync**

    **MailHelper** 类的此方法撰写并发送示例电子邮件。

<a name="contributing"></a>
## <a name="contributing"></a>参与 ##

如果想要参与本示例，请参阅 [CONTRIBUTING.MD](/CONTRIBUTING.md)。

此项目采用 [Microsoft 开源行为准则](https://opensource.microsoft.com/codeofconduct/)。有关详细信息，请参阅 [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)（行为准则常见问题解答），有任何其他问题或意见，也可联系 [opencode@microsoft.com](mailto:opencode@microsoft.com)。

<a name="questions"></a>
## <a name="questions-and-comments"></a>问题和意见

我们乐意倾听你有关 Xamarin Forms 项目的 Microsoft Graph 连接示例的反馈。你可以在该存储库中的 [问题](https://github.com/MicrosoftGraph/xamarin-csharp-connect-sample/issues) 部分将问题和建议发送给我们。

你的反馈对我们意义重大。请在 [Stack Overflow](http://stackoverflow.com/questions/tagged/office365+or+microsoftgraph) 上与我们联系。使用 [MicrosoftGraph] 标记出你的问题。

<a name="additional-resources"></a>
## <a name="additional-resources"></a>其他资源 ##

- [其他 Microsoft Graph Connect 示例](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Microsoft Graph 概述](http://graph.microsoft.io)
- [Office 开发人员代码示例](http://dev.office.com/code-samples)
- [Office 开发人员中心](http://dev.office.com/)


## <a name="copyright"></a>版权
版权所有 (c) 2016 Microsoft。保留所有权利。


