# <a name="microsoft-graph-connect-sample-for-xamarin-forms"></a>Exemple de connexion de Microsoft Graph pour Xamarin Forms

##<a name="table-of-contents"></a>Sommaire

* [Introduction](#introduction)
* [Conditions préalables](#prerequisites)
* [Enregistrement et configuration de l’application](#register)
* [Création et débogage](#build)
* [Questions et commentaires](#questions)
* [Ressources supplémentaires](#additional-resources)

<a name="introduction"></a>
##<a name="introduction"></a>Introduction

Cet exemple montre comment connecter une application Xamarin Forms à un compte professionnel ou scolaire (Azure Active Directory) ou personnel (Microsoft) à l’aide de l’API Microsoft Graph pour envoyer un e-mail. Il utilise le [kit de développement logiciel Microsoft Graph .NET Client](https://github.com/microsoftgraph/msgraph-sdk-dotnet) pour fonctionner avec les données renvoyées par Microsoft Graph.

En outre, l’exemple utilise la [bibliothèque d’authentification Microsoft (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client/) pour l’authentification. Le kit de développement logiciel (SDK) MSAL offre des fonctionnalités permettant d’utiliser le [point de terminaison Azure AD v2.0](https://msdn.microsoft.com/office/office365/howto/authenticate-Office-365-APIs-using-v2), qui permet aux développeurs d’écrire un flux de code unique qui gère l’authentification des comptes professionnels, scolaires ou personnels.

Si vous souhaitez utiliser MSAL dans une application Xamarin Forms, suivez [les instructions relatives à la configuration d’un projet Xamarin Forms avec MSAL](https://github.com/microsoftgraph/xamarin-csharp-connect-sample/wiki/Set-up-a-Xamarin-Forms-project-to-use-the-MSAL-.NET-SDK).

 > **Remarque** Le kit de développement logiciel MSAL se trouve actuellement dans la version préliminaire et en tant que tel il ne doit pas être utilisé dans le code de production. Il est utilisé ici à titre indicatif uniquement.


<a name="prerequisites"></a>
## <a name="prerequisites"></a>Conditions préalables ##

Cet exemple nécessite les éléments suivants :  

  * [Visual Studio 2015](https://www.visualstudio.com/downloads) 
  * [Xamarin pour Visual Studio](https://www.xamarin.com/visual-studio)
  * Windows 10 (avec [mode de développement](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
  * Soit un [compte Microsoft](https://www.outlook.com), soit un [compte Office 365 pour entreprise](https://msdn.microsoft.com/office/office365/howto/setup-development-environment#bk_Office365Account)

Si vous souhaitez exécuter le projet iOS dans cet exemple, vous avez besoin des éléments suivants :

  * Le dernier kit de développement logiciel iOS
  * La dernière version de Xcode
  * Mac OS X Yosemite (10.10) et versions supérieures 
  * [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/)
  * Un [agent Xamarin Mac connecté à Visual Studio](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)

Vous pouvez utiliser l’[émulateur Visual Studio pour Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) si vous souhaitez exécuter le projet Android.

<a name="register"></a>
##<a name="register-and-configure-the-app"></a>Enregistrement et configuration de l’application

1. Connectez-vous au [portail d’inscription des applications](https://apps.dev.microsoft.com/) en utilisant votre compte personnel, professionnel ou scolaire.
2. Sélectionnez **Ajouter une application**.
3. Entrez un nom pour l’application, puis sélectionnez **Créer une application**.
    
    La page d’inscription s’affiche, répertoriant les propriétés de votre application.
 
4. Sous **Plateformes**, sélectionnez **Ajouter une plateforme**.
5. Sélectionnez **Application mobile**.
6. Copiez la valeur d’ID client (Id d’application) dans le Presse-papiers. Vous devrez saisir ces valeurs dans l’exemple d’application.

    L’ID d’application est un identificateur unique pour votre application.

7. Cliquez sur **Enregistrer**.

<a name="build"></a>
## <a name="build-and-debug"></a>Création et débogage ##

**Remarque :** si vous constatez des erreurs pendant l’installation des packages à l’étape 2, vérifiez que le chemin d’accès local où vous avez sauvegardé la solution n’est pas trop long/profond. Pour résoudre ce problème, il vous suffit de déplacer la solution dans un dossier plus près du répertoire racine de votre lecteur.

1. Ouvrez le fichier App.cs à l’intérieur du projet **XamarinConnect (Portable)** de la solution.

    ![](/readme-images/Appdotcs.png "Open App.cs file in XamarinConnect project")

2. Une fois que vous avez chargé la solution dans Visual Studio, configurez l’exemple pour utiliser l’ID client que vous avez enregistré en l’indiquant comme valeur de la variable **ClientId** dans le fichier App.cs.


    ![](/readme-images/appId.png "Client ID value in App.cs file")

3. Sélectionnez le projet à exécuter. Si vous sélectionnez l’option Plateforme Windows universelle, vous pouvez exécuter l’exemple sur l’ordinateur local. Si vous souhaitez exécuter le projet iOS, vous devez vous connecter à un [Mac sur lequel les outils de Xamarin](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/) ont été installés. (Vous pouvez également ouvrir cette solution dans Xamarin Studio sur un Mac et exécuter l’exemple directement à partir de là.) Vous pouvez utiliser l’[émulateur Visual Studio pour Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) si vous souhaitez exécuter le projet Android. 

    ![](/readme-images/SelectProject.png "Select project in Visual Studio")

4. Appuyez sur F5 pour créer et déboguer l’application. Exécutez la solution et connectez-vous avec votre compte personnel, professionnel ou scolaire.
    > **Remarque** Vous devrez ouvrir le gestionnaire de configurations de build pour vous assurer que les étapes de création et de déploiement sont sélectionnées pour le projet UWP.

| UWP | Android | iOS |
| --- | ------- | ----|
| <img src="/readme-images/UWP.png" alt="Connect sample on UWP" width="100%" /> | <img src="/readme-images/Droid.png" alt="Connect sample on Android" width="100%" /> | <img src="/readme-images/iOS.png" alt="Connect sample on iOS" width="100%" /> |

###<a name="summary-of-key-methods"></a>Résumé des méthodes clés

Le code dans la page principale de l’application est relativement direct et explicatif, puisque les appels de service de messagerie et d’authentification se produisent dans les classes d’assistance. Le code de la page principale se compose essentiellement des gestionnaires d’événements pour les deux boutons :

- **OnSignInSignOut**
    
    Lorsque la valeur de texte de ce bouton est « connexion », cette méthode appelle la méthode **GetAuthenticatedClient** pour acquérir un objet **GraphServicesClient** représentant l’utilisateur actuel, qu’elle utilise pour définir l’adresse e-mail et le nom d’affichage de l’utilisateur. Si la méthode réussit, elle active également le bouton d’**envoi du courrier** et la zone de texte dans laquelle l’utilisateur peut saisir une adresse e-mail et remplit cette zone de texte avec la propre adresse e-mail de l’utilisateur.

- **MailButton_Click**
    
    Cette méthode appelle la méthode **ComposeAndSendMailAsync**, à l’aide des variables d’adresse e-mail et de nom d’affichage définies pendant l’opération **ConnectButton_Click**. Si l’appel de cette méthode réussit, il met également à jour le texte de l’interface utilisateur en conséquence.

Dans cette optique, il est intéressant d’examiner un peu plus en détail les deux méthodes dans les classes d’assistance :

- **GetAuthenticatedClient**
    
    Cette méthode de la classe **AuthenticationHelper** authentifie l’utilisateur avec la bibliothèque d’authentification Microsoft (MSAL).

    Pour ce faire, elle récupère un jeton d’authentification à partir d’un objet MSAL **PublicClientApplication**, puis transmet ce jeton à un objet Microsoft Graph **DelegateAuthenticationProvider**.

    La méthode **SignInCurrentUserAsync** sur la page principale peut ensuite lire l’utilisateur à partir de cet objet **GraphServicesClient** et définir l’adresse e-mail et le nom d’affichage de l’utilisateur.

- **ComposeAndSendMailAsync**

    Cette méthode de la classe **MailHelper** compose et envoie l’exemple d’e-mail.

<a name="contributing"></a>
## <a name="contributing"></a>Contribution ##

Si vous souhaitez contribuer à cet exemple, voir [CONTRIBUTING.MD](/CONTRIBUTING.md).

Ce projet a adopté le [code de conduite Microsoft Open Source](https://opensource.microsoft.com/codeofconduct/). Pour plus d’informations, reportez-vous à la [FAQ relative au code de conduite](https://opensource.microsoft.com/codeofconduct/faq/) ou contactez [opencode@microsoft.com](mailto:opencode@microsoft.com) pour toute question ou tout commentaire.

<a name="questions"></a>
## <a name="questions-and-comments"></a>Questions et commentaires

Nous serions ravis de connaître votre opinion sur l’exemple de connexion Microsoft Graph pour Xamarin Forms. Vous pouvez nous faire part de vos questions et suggestions dans la rubrique [Problèmes](https://github.com/MicrosoftGraph/xamarin-csharp-connect-sample/issues) de ce référentiel.

Votre avis compte beaucoup pour nous. Communiquez avec nous sur [Stack Overflow](http://stackoverflow.com/questions/tagged/office365+or+microsoftgraph). Posez vos questions avec la balise [MicrosoftGraph].

<a name="additional-resources"></a>
## <a name="additional-resources"></a>Ressources supplémentaires ##

- [Autres exemples de connexion avec Microsoft Graph](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Présentation de Microsoft Graph](http://graph.microsoft.io)
- [Exemples de code du développeur Office](http://dev.office.com/code-samples)
- [Centre de développement Office](http://dev.office.com/)


## <a name="copyright"></a>Copyright
Copyright (c) 2016 Microsoft. Tous droits réservés.


