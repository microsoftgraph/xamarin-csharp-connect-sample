# <a name="microsoft-graph-connect-sample-for-xamarin-forms"></a>Xamarin Forms 用 Microsoft Graph Connect のサンプル

##<a name="table-of-contents"></a>目次

* [はじめに](#introduction)
* [前提条件](#prerequisites)
* [アプリを登録して構成する](#register)
* [ビルドとデバッグ](#build)
* [質問とコメント](#questions)
* [その他のリソース](#additional-resources)

<a name="introduction"></a>
##<a name="introduction"></a>はじめに

このサンプルは、メールを送信するための Microsoft Graph API を使用して、Microsoft の職場または学校 (Azure Active Directory) アカウント、あるいは個人用 (Microsoft) アカウントに Xamarin Forms アプリを接続する方法を示します。[Microsoft Graph .NET クライアント SDK](https://github.com/microsoftgraph/msgraph-sdk-dotnet) を使用して、Microsoft Graph が返すデータを操作します。

また、サンプルでは認証に [Microsoft 認証ライブラリ (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client/) を使用します。MSAL SDK には、[Azure AD v2.0 エンドポイント](https://msdn.microsoft.com/office/office365/howto/authenticate-Office-365-APIs-using-v2)を操作するための機能が用意されており、開発者はユーザーの職場または学校のアカウント、および個人用アカウントの両方に対する認証を処理する 1 つのコード フローを記述することができます。

独自の Xamarin Forms アプリで MSAL を開発する場合は、[MSAL で Xamarin Forms プロジェクトをセットアップするためのこれらの手順](https://github.com/microsoftgraph/xamarin-csharp-connect-sample/wiki/Set-up-a-Xamarin-Forms-project-to-use-the-MSAL-.NET-SDK)を実行します。

 > **注** 現在、MSAL SDK はプレリリース段階であるため、運用コードでは使用できません。ここでは、例示目的のみに使用されています


<a name="prerequisites"></a>
## <a name="prerequisites"></a>前提条件 ##

このサンプルを実行するには次のものが必要です:  

  * [Visual Studio 2015](https://www.visualstudio.com/downloads) 
  * [Xamarin for Visual Studio](https://www.xamarin.com/visual-studio)
  * Windows 10 ([開発モードが有効](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
  * [Microsoft](https://www.outlook.com) または [Office 365 for Business アカウント](https://msdn.microsoft.com/office/office365/howto/setup-development-environment#bk_Office365Account)のいずれか

このサンプルで iOS プロジェクトを実行する場合は、以下のものが必要です:

  * 最新の iOS SDK
  * 最新バージョンの Xcode
  * Mac OS X Yosemite(10.10) 以上 
  * [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/)
  * [Visual Studio に接続されている Xamarin Mac エージェント](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)

Android プロジェクトを実行する場合は、[Visual Studio Emulator for Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) を使用できます。

<a name="register"></a>
##<a name="register-and-configure-the-app"></a>アプリを登録して構成する

1. 個人用アカウント、あるいは職場または学校アカウントのいずれかを使用して、[アプリ登録ポータル](https://apps.dev.microsoft.com/)にサインインします。
2. **[アプリの追加]** を選択します。
3. アプリの名前を入力して、**[アプリケーションの作成]** を選択します。
    
    登録ページが表示され、アプリのプロパティが一覧表示されます。
 
4. **[プラットフォーム]** で、**[プラットフォームの追加]** を選択します。
5. **[モバイル アプリケーション]** を選択します。
6. クライアント ID (アプリ ID) の値をクリップボードにコピーします。サンプル アプリにこれらの値を入力する必要があります。

    アプリ ID は、アプリの一意識別子です。

7. **[保存]** を選択します。

<a name="build"></a>
## <a name="build-and-debug"></a>ビルドとデバッグ ##

**注:**手順 2 でパッケージのインストール中にエラーが発生した場合は、ソリューションを保存したローカル パスが長すぎたり深すぎたりしていないかご確認ください。ドライブのルート近くにソリューションを移動すると問題が解決します。

1. ソリューションの **XamarinConnect (ポータブル)** プロジェクト内にある App.cs ファイルを開きます。

    ![](/readme-images/Appdotcs.png "Open App.cs file in XamarinConnect project")

2. Visual Studio にソリューションを読み込んだ後、登録したクライアント ID を App.cs ファイルの **ClientId** 変数の値にして、この値を使用するようにサンプルを構成します。


    ![](/readme-images/appId.png "Client ID value in App.cs file")

3. 実行するプロジェクトを選択します。ユニバーサル Windows プラットフォームのオプションを選択すると、ローカル コンピューターでサンプルを実行できます。iOS プロジェクトを実行する場合は、[Xamarin ツールがインストールされた Mac](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/) に接続する必要があります。(また、このソリューションを Mac 上の Xamarin Studio で開いて、そこからサンプルを直接実行することもできます。)Android プロジェクトを実行する場合は、[Visual Studio Emulator for Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) を使用できます。 

    ![](/readme-images/SelectProject.png "Select project in Visual Studio")

4. F5 キーを押して、ビルドとデバッグを実行します。　ソリューションを実行し、個人用アカウント、あるいは職場または学校のアカウントのいずれかでサインインします。
    > **注** ビルド構成マネージャーを開いて、ビルドと展開の手順が UWP プロジェクトに対して選択されていることを確認することが必要な場合があります。

| UWP | Android | iOS |
| --- | ------- | ----|
| <img src="/readme-images/UWP.png" alt="Connect sample on UWP" width="100%" /> | <img src="/readme-images/Droid.png" alt="Connect sample on Android" width="100%" /> | <img src="/readme-images/iOS.png" alt="Connect sample on iOS" width="100%" /> |

###<a name="summary-of-key-methods"></a>主なメソッドの概要

アプリのメイン ページのコードは、比較的単純なため説明が必要ありません。これは認証とメール サービスの呼び出しが実際にはヘルパー クラスで発生するためです。メイン ページのコードは、主に 2 つのボタン用のイベント ハンドラーで構成されています:

- **OnSignInSignOut**
    
    このボタンのテキスト値が "connect" の場合、このメソッドは **GetAuthenticatedClient** メソッドを呼び出して、現在のユーザーを表す **GraphServicesClient** オブジェクトを取得します。これはユーザーのメール アドレスと表示名を設定するために使用されます。これが成功すると、**[メールの送信]** ボタンとユーザーがメール アドレスを入力できるテキスト ボックスも有効になり、ユーザー独自のメール アドレスがそのテキスト ボックスに設定されます。

- **MailButton_Click**
    
    このメソッドは、**ConnectButton_Click** 中に設定されたメール アドレスと表示名の各変数を使用して、**ComposeAndSendMailAsync** メソッドを呼び出します。このメソッドの呼び出しが成功した場合、これに応じて、UI テキストも更新されます。

この点を考慮して、ヘルパー クラスの 2 つのメソッドをもう少し詳しく調べてみる必要があります:

- **GetAuthenticatedClient**
    
    **AuthenticationHelper** クラスのこのメソッドは、Microsoft 認証ライブラリ (MSAL) を使用してユーザーを認証します。

    これは、MSAL の **PublicClientApplication** オブジェクトから認証トークンを取得して、そのトークンを Microsoft Graph の **DelegateAuthenticationProvider** オブジェクトに渡すことで行われます。

    メイン ページの **SignInCurrentUserAsync** メソッドは、この **GraphServicesClient** オブジェクトからユーザーを読み取って、ユーザーのメール アドレスと表示名を設定することができるようになります。

- **ComposeAndSendMailAsync**

    **MailHelper** クラスのこのメソッドは、サンプルのメールを作成して送信します。

<a name="contributing"></a>
## <a name="contributing"></a>投稿 ##

このサンプルに投稿する場合は、[CONTRIBUTING.MD](/CONTRIBUTING.md) を参照してください。

このプロジェクトでは、[Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) が採用されています。詳細については、「[規範に関する FAQ](https://opensource.microsoft.com/codeofconduct/faq/)」を参照してください。または、その他の質問やコメントがあれば、[opencode@microsoft.com](mailto:opencode@microsoft.com) までにお問い合わせください。

<a name="questions"></a>
## <a name="questions-and-comments"></a>質問とコメント

Xamarin.Forms プロジェクト用 Microsoft Graph Connect のサンプルに関するフィードバックをお寄せください。質問や提案につきましては、このリポジトリの「[問題](https://github.com/MicrosoftGraph/xamarin-csharp-connect-sample/issues)」セクションで送信できます。

お客様からのフィードバックを重視しています。[Stack Overflow](http://stackoverflow.com/questions/tagged/office365+or+microsoftgraph)でご連絡いただけます。ご質問には [MicrosoftGraph] のタグを付けてください。

<a name="additional-resources"></a>
## <a name="additional-resources"></a>追加リソース ##

- [その他の Microsoft Graph Connect サンプル](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Microsoft Graph の概要](http://graph.microsoft.io)
- [Office 開発者向けコード サンプル](http://dev.office.com/code-samples)
- [Office デベロッパー センター](http://dev.office.com/)


## <a name="copyright"></a>著作権
Copyright (c) 2016 Microsoft.All rights reserved.


