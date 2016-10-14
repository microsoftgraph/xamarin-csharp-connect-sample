# <a name="microsoft-graph-connect-sample-for-xamarin-forms"></a>Пример приложения, подключающегося с использованием Microsoft Graph, для Xamarin Forms

##<a name="table-of-contents"></a>Содержание

* [Введение](#introduction)
* [Необходимые компоненты](#prerequisites)
* [Регистрация и настройка приложения](#register)
* [Сборка и отладка](#build)
* [Вопросы и комментарии](#questions)
* [Дополнительные ресурсы](#additional-resources)

<a name="introduction"></a>
##<a name="introduction"></a>Введение

В этом примере показано, как подключить приложение Xamarin Forms к рабочей или учебной (Azure Active Directory) либо личной учетной записи Майкрософт с помощью API Microsoft Graph для отправки электронной почты. Для работы с данными, возвращаемыми Microsoft Graph, используется [клиентский пакет SDK .NET Microsoft Graph](https://github.com/microsoftgraph/msgraph-sdk-dotnet).

Кроме того, для проверки подлинности в этом примере используется [Microsoft Authentication Library (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client/). Пакет SDK MSAL предоставляет функции для работы с [конечной точкой Azure AD версии 2.0](https://msdn.microsoft.com/office/office365/howto/authenticate-Office-365-APIs-using-v2), которая позволяет разработчикам создать один поток кода для проверки подлинности как рабочих или учебных, так и личных учетных записей.

Если вы хотите работать с MSAL в собственном приложении Xamarin Forms, следуйте [этим инструкциям по настройке проекта Xamarin Forms с MSAL](https://github.com/microsoftgraph/xamarin-csharp-connect-sample/wiki/Set-up-a-Xamarin-Forms-project-to-use-the-MSAL-.NET-SDK).

 > **Примечание**. Сейчас доступна предварительная версия пакета SDK MSAL, поэтому его не следует использовать в рабочем коде. Он используется здесь только в демонстрационных целях.


<a name="prerequisites"></a>
## <a name="prerequisites"></a>Необходимые компоненты ##

Для этого примера требуются следующие компоненты:  

  * [Visual Studio 2015](https://www.visualstudio.com/downloads) 
  * [Xamarin для Visual Studio](https://www.xamarin.com/visual-studio)
  * Windows 10 ([с включенным режимом разработки](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
  * учетная запись [Майкрософт](https://www.outlook.com) или [учетная запись Office 365 для бизнеса](https://msdn.microsoft.com/office/office365/howto/setup-development-environment#bk_Office365Account).

Чтобы выполнить проект iOS в этом примере, потребуются перечисленные ниже компоненты.

  * Последний пакет SDK для iOS
  * Последняя версия Xcode
  * Mac OS X Yosemite (10.10) и более поздних версий 
  * [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/)
  * [Агент Xamarin Mac, подключенный к Visual Studio](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)

Вы можете использовать [эмулятор Visual Studio для Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx), чтобы запустить проект Android.

<a name="register"></a>
##<a name="register-and-configure-the-app"></a>Регистрация и настройка приложения

1. Войдите на [портал регистрации приложений](https://apps.dev.microsoft.com/) с помощью личной, рабочей или учебной учетной записи.
2. Выберите пункт **Добавить приложение**.
3. Введите имя приложения и выберите пункт **Создать приложение**.
    
    Откроется страница регистрации со свойствами приложения.
 
4. В разделе **Платформы** выберите пункт **Добавление платформы**.
5. Выберите пункт **Мобильное приложение**.
6. Скопируйте значение идентификатора клиента (App Id) в буфер обмена. Эти значения потребуется ввести в примере приложения.

    Идентификатор приложения является уникальным.

7. Нажмите кнопку **Сохранить**.

<a name="build"></a>
## <a name="build-and-debug"></a>Сборка и отладка ##

**Примечание.** Если во время установки пакетов при выполнении шага 2 возникают ошибки, убедитесь, что локальный путь к решению не слишком длинный. Чтобы устранить эту проблему, переместите решение ближе к корню диска.

1. Откройте файл App.cs в проекте решения **XamarinConnect (Portable)**.

    ![](/readme-images/Appdotcs.png "Open App.cs file in XamarinConnect project")

2. После загрузки решения в Visual Studio, настройте пример на использование зарегистрированного идентификатора клиента, сделав его значением переменной **ClientId** в файле App.cs.


    ![](/readme-images/appId.png "Client ID value in App.cs file")

3. Выберите проект, который следует выполнить. Если выбрать универсальную платформу Windows, пример можно запустить на локальном компьютере. Чтобы запустить проект iOS, вам потребуется подключиться к [компьютеру Mac, на котором установлены средства Xamarin](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/). (Вы также можете открыть это решение в Xamarin Studio на компьютере Mac и запустить пример прямо оттуда.) Вы можете использовать [эмулятор Visual Studio для Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx), чтобы запустить проект Android. 

    ![](/readme-images/SelectProject.png "Select project in Visual Studio")

4. Нажмите клавишу F5 для сборки и отладки. Запустите решение и войдите в систему с помощью личной, рабочей или учебной учетной записи.
    > **Примечание.** Возможно, потребуется открыть диспетчер конфигурации сборки и убедиться, что для проекта UWP выбраны этапы сборки и развертывания.

| UWP | Android | iOS, |
| --- | ------- | ----|
| <img src="/readme-images/UWP.png" alt="Connect sample on UWP" width="100%" /> | <img src="/readme-images/Droid.png" alt="Connect sample on Android" width="100%" /> | <img src="/readme-images/iOS.png" alt="Connect sample on iOS" width="100%" /> |

###<a name="summary-of-key-methods"></a>Обзор ключевых методов

Код на главной странице приложения относительно прост и понятен, так как вызовы службы проверки подлинности и электронной почты по факту выполняются во вспомогательных классах. Код главной страницы главным образом состоит из обработчиков событий для двух кнопок.

- **OnSignInSignOut**
    
    Если для этой кнопки задано текстовое значение "Подключить", этот метод вызывает метод **GetAuthenticatedClient**, чтобы получить объект **GraphServicesClient**, представляющий текущего пользователя, который используется для установки адреса электронной почты и отображаемого имени пользователя. Если код выполняется успешно, он также активирует кнопку **Отправить сообщение** и текстовое поле, в котором пользователь может ввести адрес электронной почты, а затем заполняет это текстовое поле собственным адресом электронной почты пользователя.

- **MailButton_Click**
    
    Этот метод вызывает метод **ComposeAndSendMailAsync**, используя переменные адреса электронной почты и отображаемого имени, заданные с помощью метода **ConnectButton_Click**. При успешном вызове этого метода он также соответствующим образом обновляет текст пользовательского интерфейса.

Помня об этом, давайте более подробно рассмотрим два приведенных ниже метода во вспомогательных классах.

- **GetAuthenticatedClient**
    
    Этот метод класса **AuthenticationHelper** выполняет проверку подлинности пользователя с помощью библиотеки Microsoft Authentication Library (MSAL).

    Для этого из объекта MSAL **PublicClientApplication** извлекается маркер проверки подлинности, который затем передается в объект Microsoft Graph **DelegateAuthenticationProvider**.

    Затем с помощью метода **SignInCurrentUserAsync** на главной странице можно считать пользователя из этого объекта **GraphServicesClient**, а также задать адрес электронной почты и отображаемое имя пользователя.

- **ComposeAndSendMailAsync**

    Этот метод класса **MailHelper** создает и отправляет пример сообщения электронной почты.

<a name="contributing"></a>
## <a name="contributing"></a>Участие ##

Если вы хотите добавить код в этот пример, просмотрите статью [CONTRIBUTING.MD](/CONTRIBUTING.md).

Этот проект соответствует [правилам поведения Майкрософт, касающимся обращения с открытым кодом](https://opensource.microsoft.com/codeofconduct/). Читайте дополнительные сведения в [разделе вопросов и ответов по правилам поведения](https://opensource.microsoft.com/codeofconduct/faq/) или отправляйте новые вопросы и замечания по адресу [opencode@microsoft.com](mailto:opencode@microsoft.com).

<a name="questions"></a>
## <a name="questions-and-comments"></a>Вопросы и комментарии

Мы будем рады получить от вас отзывы о проекте примера приложения для Xamarin Forms, подключающегося с использованием Microsoft Graph. Вы можете отправлять нам вопросы и предложения на вкладке [Issues](https://github.com/MicrosoftGraph/xamarin-csharp-connect-sample/issues) (Проблемы) этого репозитория.

Ваше мнение важно для нас. Для связи с нами используйте сайт [Stack Overflow](http://stackoverflow.com/questions/tagged/office365+or+microsoftgraph). Помечайте свои вопросы тегом [MicrosoftGraph].

<a name="additional-resources"></a>
## <a name="additional-resources"></a>Дополнительные ресурсы ##

- [Другие примеры Microsoft Graph Connect](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Общие сведения о Microsoft Graph](http://graph.microsoft.io)
- [Примеры кода приложений для Office](http://dev.office.com/code-samples)
- [Центр разработки для Office](http://dev.office.com/)


## <a name="copyright"></a>Авторское право
(c) Корпорация Майкрософт (Microsoft Corporation), 2016. Все права защищены.


