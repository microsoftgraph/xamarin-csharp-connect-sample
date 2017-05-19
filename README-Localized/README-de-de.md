# <a name="microsoft-graph-connect-sample-for-xamarin-forms"></a>Microsoft Graph Connect-Beispiel für Xamarin Forms

##<a name="table-of-contents"></a>Inhalt

* [Einführung](#introduction)
* [Voraussetzungen](#prerequisites)
* [Registrieren und Konfigurieren der App](#register)
* [Erstellen und Debuggen](#build)
* [Fragen und Kommentare](#questions)
* [Weitere Ressourcen](#additional-resources)

<a name="introduction"></a>
##<a name="introduction"></a>Einführung

In diesem Beispiel wird gezeigt, wie eine Xamarin Forms-App mit einem Microsoft-Geschäfts- oder Schulkonto (Azure Active Directory) oder mit einem persönlichen Konto (Microsoft) mithilfe der Microsoft Graph-API zum Senden einer E-Mail verbunden wird. Es verwendet das [Microsoft Graph .NET-Client-SDK](https://github.com/microsoftgraph/msgraph-sdk-dotnet), um mit Daten zu arbeiten, die von Microsoft Graph zurückgegeben werden.

Das Beispiel verwendet außerdem die [Microsoft-Authentifizierungsbibliothek (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client/) für die Authentifizierung. Das MSAL-SDK bietet Features für die Arbeit mit dem [Azure AD v2.0-Authentifizierungsendpunkt](https://msdn.microsoft.com/office/office365/howto/authenticate-Office-365-APIs-using-v2), der es Entwicklern ermöglicht, einen einzelnen Codefluss zu schreiben, der die Authentifizierung sowohl für Geschäfts- oder Schulkonten von Benutzern als auch für persönliche Konten verarbeitet.

Wenn Sie in einer eigenen Xamarin Forms-App mit MSAL arbeiten möchten, befolgen Sie die folgenden [Anweisungen zum Einrichten eines Xamarin Forms-Projekts mit MSAL](https://github.com/microsoftgraph/xamarin-csharp-connect-sample/wiki/Set-up-a-Xamarin-Forms-project-to-use-the-MSAL-.NET-SDK).

 > **Hinweis** Das MSAL-SDK befindet sich derzeit in der Vorabversion und sollte daher nicht in Produktionscode verwendet werden. Es dient hier nur zur Veranschaulichung


<a name="prerequisites"></a>
## <a name="prerequisites"></a>Anforderungen ##

Für dieses Beispiel ist Folgendes erforderlich:  

  * [Visual Studio 2015](https://www.visualstudio.com/downloads) 
  * [Xamarin für Visual Studio](https://www.xamarin.com/visual-studio)
  * Windows 10 (mit [aktiviertem Entwicklungsmodus](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
  * Entweder ein [Microsoft-Konto](https://www.outlook.com) oder ein [Office 365 for Business-Konto](https://msdn.microsoft.com/office/office365/howto/setup-development-environment#bk_Office365Account).

Wenn Sie das iOS-Projekt in diesem Beispiel ausführen möchten, benötigen Sie Folgendes:

  * Das neueste iOS-SDK
  * Die neueste Version von Xcode
  * Mac OS X Yosemite (10.10) und höher 
  * [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/)
  * Einen mit [Visual Studio verbundenen Xamarin Mac-Agent](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)

Sie können den [Visual Studio-Emulator für Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) verwenden, wenn Sie das Android-Projekt ausführen möchten.

<a name="register"></a>
##<a name="register-and-configure-the-app"></a>Registrieren und Konfigurieren der App

1. Melden Sie sich beim [App-Registrierungsportal](https://apps.dev.microsoft.com/) entweder mit Ihrem persönlichen oder geschäftlichen Konto oder mit Ihrem Schulkonto an.
2. Klicken Sie auf **App hinzufügen**.
3. Geben Sie einen Namen für die App ein, und wählen Sie **Anwendung erstellen** aus.
    
    Die Registrierungsseite wird angezeigt, und die Eigenschaften der App werden aufgeführt.
 
4. Wählen Sie unter **Plattformen** die Option **Plattform hinzufügen** aus.
5. Wählen Sie **Mobile Anwendung** aus.
6. Kopieren Sie den Wert für die Client-ID (App-ID) in die Zwischenablage. Sie müssen diese Werte in die Beispiel-App eingeben.

    Die App-ID ist ein eindeutiger Bezeichner für Ihre App.

7. Klicken Sie auf **Speichern**.

<a name="build"></a>
## <a name="build-and-debug"></a>Erstellen und Debuggen ##

**Hinweis:** Wenn beim Installieren der Pakete während des Schritts 2 Fehler angezeigt werden, müssen Sie sicherstellen, dass der lokale Pfad, unter dem Sie die Projektmappe abgelegt haben, weder zu lang noch zu tief ist. Dieses Problem lässt sich beheben, indem Sie den Pfad auf Ihrem Laufwerk verkürzen.

1. Öffnen Sie die Datei „App.cs“ innerhalb des **XamarinConnect (Portable)**-Projekts der Lösung.

    ![](/readme-images/Appdotcs.png "Open App.cs file in XamarinConnect project")

2. Nachdem Sie die Lösung in Visual Studio geladen haben, konfigurieren Sie das Beispiel so, dass die registrierte Client-ID verwendet wird, indem Sie diese als Wert der **ClientId**-Variablen in der Datei „App.cs“ zuweisen.


    ![](/readme-images/appId.png "Client ID value in App.cs file")

3. Wählen Sie das auszuführende Projekt aus. Wenn Sie die Option für die universelle Windows-Plattform auswählen, können Sie das Beispiel auf dem lokalen Computer ausführen. Wenn Sie das iOS-Projekt ausführen möchten, müssen Sie eine Verbindung zu einem [Mac herstellen, auf dem die Xamarin-Tools installiert](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/) sind. (Sie können diese Lösung auch in Xamarin Studio auf einem Mac öffnen und das Beispiel direkt dort ausführen.) Sie können den [Visual Studio-Emulator für Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) verwenden, wenn Sie das Android-Projekt ausführen möchten. 

    ![](/readme-images/SelectProject.png "Select project in Visual Studio")

4. Drücken Sie zum Erstellen und Debuggen F5. Führen Sie die Lösung aus, und melden Sie sich entweder mit Ihrem persönlichen Konto oder mit Ihrem Geschäfts- oder Schulkonto an.
    > **Hinweis** Möglicherweise müssen Sie den Buildkonfigurations-Manager öffnen, um sicherzustellen, dass die Build- und Bereitstellungsschritte für das UWP-Projekt ausgewählt sind.

| UWP | Android | iOS |
| --- | ------- | ----|
| <img src="/readme-images/UWP.png" alt="Connect sample on UWP" width="100%" /> | <img src="/readme-images/Droid.png" alt="Connect sample on Android" width="100%" /> | <img src="/readme-images/iOS.png" alt="Connect sample on iOS" width="100%" /> |

###<a name="summary-of-key-methods"></a>Zusammenfassung der wichtigsten Methoden

Der Code auf der Hauptseite der App ist relativ einfach und selbsterklärend, da die Aufrufe für den Authentifizierungs- und E-Mail-Dienst tatsächlich in den Helferklassen stattfinden. Der Code auf der Hauptseite besteht in erster Linie aus Ereignishandlern für die beiden Schaltflächen:

- **OnSignInSignOut**
    
    Wenn der Textwert dieser Schaltfläche "Verbinden" lautet, ruft diese Methode die **GetAuthenticatedClient**-Methode auf, um ein **GraphServicesClient**-Objekt zu erhalten, das den aktuellen Benutzer darstellt, den es zum Festlegen der Benutzer-E-Mail-Adresse und des Anzeigenamens verwendet. Wenn dies erfolgreich ist, werden auch die Schaltfläche **E-Mail senden** und das Textfeld aktiviert, in das der Benutzer eine E-Mail-Adresse eingeben kann, und das Textfeld wird mit der eigenen E-Mail-Adresse des Benutzers aufgefüllt.

- **MailButton_Click**
    
    Diese Methode ruft die **ComposeAndSendMailAsync**-Methode unter Verwendung der Variablen für die E-Mail-Adresse und den Anzeigenamen auf, die während **ConnectButton_Click** festgelegt wurden. Wenn dieser Methodenaufruf erfolgreich ist, wird auch der Benutzeroberflächentext entsprechend aktualisiert.

In diesem Sinne sollten Sie sich zwei Methoden in den Helferklassen etwas genauer ansehen:

- **GetAuthenticatedClient**
    
    Diese Methode der **AuthenticationHelper**-Klasse authentifiziert den Benutzer mit der Microsoft-Authentifizierungsbibliothek (MSAL).

    Dies geschieht durch Abrufen eines Authentifizierungstokens aus dem **PublicClientApplication**-Objekt von MSAL und anschließendes Übergeben dieses Tokens an ein **DelegateAuthenticationProvider**-Objekt von Microsoft Graph.

    Die **SignInCurrentUserAsync**-Methode auf der Hauptseite kann dann den Benutzer aus diesem **GraphServicesClient**-Objekt lesen und Benutzer-E-Mail-Adresse und den Anzeigenamen festlegen.

- **ComposeAndSendMailAsync**

    Diese Methode der **MailHelper**-Klasse verfasst und sendet die Beispiel-E-Mail.

<a name="contributing"></a>
## <a name="contributing"></a>Mitwirkung ##

Wenn Sie einen Beitrag zu diesem Beispiel leisten möchten, finden Sie unter [CONTRIBUTING.MD](/CONTRIBUTING.md) weitere Informationen.

In diesem Projekt wurden die [Microsoft Open Source-Verhaltensregeln](https://opensource.microsoft.com/codeofconduct/) übernommen. Weitere Informationen finden Sie unter [Häufig gestellte Fragen zu Verhaltensregeln](https://opensource.microsoft.com/codeofconduct/faq/), oder richten Sie Ihre Fragen oder Kommentare an [opencode@microsoft.com](mailto:opencode@microsoft.com).

<a name="questions"></a>
## <a name="questions-and-comments"></a>Fragen und Kommentare

Wir schätzen Ihr Feedback hinsichtlich des Microsoft Graph Connect-Beispiels für das Xamarin Forms-Projekt. Sie können uns Ihre Fragen und Vorschläge über den Abschnitt [Probleme](https://github.com/MicrosoftGraph/xamarin-csharp-connect-sample/issues) dieses Repositorys senden.

Ihr Feedback ist uns wichtig. Nehmen Sie unter [Stack Overflow](http://stackoverflow.com/questions/tagged/office365+or+microsoftgraph) Kontakt mit uns auf. Taggen Sie Ihre Fragen mit [MicrosoftGraph].

<a name="additional-resources"></a>
## <a name="additional-resources"></a>Zusätzliche Ressourcen ##

- [Weitere Microsoft Graph Connect-Beispiele](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Microsoft Graph-Übersicht](http://graph.microsoft.io)
- [Office-Entwicklercodebeispiele](http://dev.office.com/code-samples)
- [Office Dev Center](http://dev.office.com/)


## <a name="copyright"></a>Copyright
Copyright (c) 2016 Microsoft. Alle Rechte vorbehalten.


