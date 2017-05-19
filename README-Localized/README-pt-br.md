# <a name="microsoft-graph-connect-sample-for-xamarin-forms"></a>Exemplo de Conexão do Microsoft Graph para Xamarin Forms

##<a name="table-of-contents"></a>Sumário

* [Introdução](#introduction)
* [Pré-requisitos](#prerequisites)
* [Registrar e configurar o aplicativo](#register)
* [Compilar e depurar](#build)
* [Perguntas e comentários](#questions)
* [Recursos adicionais](#additional-resources)

<a name="introduction"></a>
##<a name="introduction"></a>Introdução

Este exemplo mostra como conectar um aplicativo do Xamarin Forms a uma conta comercial ou escolar (Azure Active Directory) da Microsoft ou uma conta pessoal (Microsoft) usando a API do Microsoft Graph API para enviar emails. O exemplo usa o [SDK de Cliente do Microsoft Graph .NET](https://github.com/microsoftgraph/msgraph-sdk-dotnet) para trabalhar com dados retornados pelo Microsoft Graph.

Além disso, o exemplo usa a [Biblioteca de Autenticação da Microsoft (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client/) para autenticação. O SDK da MSAL fornece recursos para trabalhar com o [ponto de extremidade do Microsoft Azure AD versão 2.0](https://msdn.microsoft.com/office/office365/howto/authenticate-Office-365-APIs-using-v2), que permite aos desenvolvedores gravar um único fluxo de código para tratar da autenticação de contas pessoais, corporativas ou de estudantes.

Se deseja trabalhar com a MSAL em seu próprio aplicativo do Xamarin Forms, siga [estas instruções para configurar um projeto do Xamarin Forms com a MSAL](https://github.com/microsoftgraph/xamarin-csharp-connect-sample/wiki/Set-up-a-Xamarin-Forms-project-to-use-the-MSAL-.NET-SDK).

 > **Observação** No momento, o SDK da MSAL encontra-se em pré-lançamento e como tal não deve ser usado no código de produção. Isso é usado apenas para fins ilustrativos


<a name="prerequisites"></a>
## <a name="prerequisites"></a>Pré-requisitos ##

Este exemplo requer o seguinte:  

  * [Visual Studio 2015](https://www.visualstudio.com/downloads) 
  * [Xamarin para Visual Studio](https://www.xamarin.com/visual-studio)
  * Windows 10 ([modo de desenvolvedor habilitado](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
  * Uma [conta da Microsoft](https://www.outlook.com) ou a [conta do Office 365 para empresas](https://msdn.microsoft.com/office/office365/howto/setup-development-environment#bk_Office365Account)

Se quiser executar o projeto do iOS neste exemplo, você precisará do seguinte:

  * O SDK mais recente do iOS
  * A versão mais recente do Xcode
  * Mac OS X Yosemite (10.10) e versões superiores 
  * [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/)
  * Um [agente do Xamarin Mac conectado ao Visual Studio](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)

Você pode usar o [Emulador do Visual Studio para Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) se quiser executar o projeto do Android.

<a name="register"></a>
##<a name="register-and-configure-the-app"></a>Registrar e configurar o aplicativo

1. Entre no [Portal de Registro do Aplicativo](https://apps.dev.microsoft.com/) usando sua conta pessoal ou sua conta comercial ou escolar.
2. Selecione **Adicionar um aplicativo**.
3. Insira um nome para o aplicativo e selecione **Criar aplicativo**.
    
    A página de registro é exibida, listando as propriedades do seu aplicativo.
 
4. Em **Plataformas**, selecione **Adicionar plataforma**.
5. Escolha **Aplicativo móvel**.
6. Copie o valor da ID de Cliente (ID de Aplicativo) para a área de transferência. Você precisará inserir esses valores no exemplo de aplicativo.

    Essa ID de aplicativo é o identificador exclusivo do aplicativo.

7. Selecione **Salvar**.

<a name="build"></a>
## <a name="build-and-debug"></a>Compilar e depurar ##

**Observação:** Caso receba mensagens de erro durante a instalação de pacotes na etapa 2, verifique se o caminho para o local onde você colocou a solução não é muito longo ou extenso. Para resolver esse problema, coloque a solução junto à raiz da unidade.

1. Abra o arquivo App.cs no projeto **XamarinConnect (Portátil)** da solução.

    ![](/readme-images/Appdotcs.png "Open App.cs file in XamarinConnect project")

2. Após carregar a solução no Visual Studio, configure o exemplo para usar a ID do cliente registrada transformando-a no valor da variável **ClientId** variável no arquivo App.cs.


    ![](/readme-images/appId.png "Client ID value in App.cs file")

3. Escolha o projeto que você deseja excluir. Se escolher a opção Plataforma Universal do Windows, você poderá executar o exemplo no computador local. Se quiser executar o projeto do iOS, você precisará se conectar a um [Mac que tenha as ferramentas Xamarin](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/) instaladas nele. (Você também pode abrir esta solução no Xamarin Studio em um Mac e executar o exemplo diretamente de lá). Você pode usar o [Emulador do Microsoft Visual Studio para Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx), caso pretenda executar o projeto do Android. 

    ![](/readme-images/SelectProject.png "Select project in Visual Studio")

4. Pressione F5 para criar e depurar. Execute a solução e entre com sua conta pessoal ou sua conta comercial ou escolar.
    > **Observação** Talvez seja necessário abrir o Gerenciador de Configuração de Compilação para certificar-se de que as etapas de Compilar e Implantar estejam selecionadas para o projeto do UWP.

| UWP | Android | iOS |
| --- | ------- | ----|
| <img src="/readme-images/UWP.png" alt="Connect sample on UWP" width="100%" /> | <img src="/readme-images/Droid.png" alt="Connect sample on Android" width="100%" /> | <img src="/readme-images/iOS.png" alt="Connect sample on iOS" width="100%" /> |

###<a name="summary-of-key-methods"></a>Resumo dos principais métodos

O código na página principal do aplicativo é relativamente simples e autoexplicativo já que as chamadas para o serviço de email e a autenticação realmente ocorrem nas classes auxiliares. O código da página principal consiste principalmente de manipuladores de eventos para os dois botões:

- **OnSignInSignOut**
    
    Quando o valor de texto desse botão é "conexão", este método chama o método **GetAuthenticatedClient** para adquirir um objeto **GraphServicesClient** que representa o usuário atual usado para definir o endereço de email do usuário e o nome de exibição. Se for bem-sucedida, a operação também habilitará o botão **enviar email** e a caixa de texto na qual o usuário poderá inserir um endereço de email, além de preenchê-la com o endereço de email do próprio usuário.

- **MailButton_Click**
    
    Este método chama o método **ComposeAndSendMailAsync** usando o endereço de email e as variáveis de nome de exibição definidas durante **ConnectButton_Click**. Se essa chamada de método for bem-sucedida, ela também atualizará adequadamente o texto da interface do usuário.

Com isso em mente, vale a pena consultar mais detalhadamente os dois métodos nas classes auxiliares:

- **GetAuthenticatedClient**
    
    Esse método da classe **AuthenticationHelper** autentica o usuário com a Biblioteca de Autenticação da Microsoft (MSAL).

    O método faz isso recuperando um token de autenticação de um objeto **PublicClientApplication** da MSAL e, em seguida, passando esse token para um objeto **DelegateAuthenticationProvider** do Microsoft Graph.

    Em seguida, o método **SignInCurrentUserAsync** na página principal pode ler o usuário deste objeto **GraphServicesClient** e definir o endereço de email do usuário e o nome de exibição.

- **ComposeAndSendMailAsync**

    Esse método da classe **MailHelper** redige e envia o exemplo de email.

<a name="contributing"></a>
## <a name="contributing"></a>Colaboração ##

Se quiser contribuir para esse exemplo, confira [CONTRIBUTING.MD](/CONTRIBUTING.md).

Este projeto adotou o [Código de Conduta do Código Aberto da Microsoft](https://opensource.microsoft.com/codeofconduct/). Para saber mais, confira as [Perguntas frequentes do Código de Conduta](https://opensource.microsoft.com/codeofconduct/faq/) ou contate [opencode@microsoft.com](mailto:opencode@microsoft.com) se tiver outras dúvidas ou comentários.

<a name="questions"></a>
## <a name="questions-and-comments"></a>Perguntas e comentários

Adoraríamos receber seus comentários sobre o projeto Exemplo de Conexão do Microsoft Graph para Xamarin Forms. Você pode nos enviar suas perguntas e sugestões por meio da seção [Issues](https://github.com/MicrosoftGraph/xamarin-csharp-connect-sample/issues) deste repositório.

Seus comentários são importantes para nós. Junte-se a nós na página [Stack Overflow](http://stackoverflow.com/questions/tagged/office365+or+microsoftgraph). Marque suas perguntas com [MicrosoftGraph].

<a name="additional-resources"></a>
## <a name="additional-resources"></a>Recursos adicionais ##

- [Outros exemplos de conexão usando o Microsoft Graph](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Visão geral do Microsoft Graph](http://graph.microsoft.io)
- [Exemplos de código para desenvolvedores do Office](http://dev.office.com/code-samples)
- [Centro de Desenvolvimento do Office](http://dev.office.com/)


## <a name="copyright"></a>Direitos autorais
Copyright © 2016 Microsoft. Todos os direitos reservados.


