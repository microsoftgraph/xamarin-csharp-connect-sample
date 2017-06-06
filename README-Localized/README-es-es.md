# <a name="microsoft-graph-connect-sample-for-xamarin-forms"></a>Ejemplo de conexión de Microsoft Graph para Xamarin Forms

## <a name="table-of-contents"></a>Tabla de contenido

* [Introducción](#introduction)
* [Requisitos previos](#prerequisites)
* [Registrar y configurar la aplicación](#register)
* [Compilar y depurar](#build)
* [Preguntas y comentarios](#questions)
* [Recursos adicionales](#additional-resources)

<a name="introduction"></a>
## <a name="introduction"></a>Introducción

Este ejemplo muestra cómo conectar una aplicación Xamarin Forms a una cuenta profesional o educativa de Microsoft (Azure Active Directory) o a una cuenta personal (Microsoft) usando la API de Microsoft Graph para recuperar la imagen del perfil de un usuario, cargar la imagen en OneDrive y enviar un correo electrónico que contiene la foto como un archivo adjunto y el vínculo para compartir en su texto. Usa el [SDK del cliente de Microsoft Graph .NET](https://github.com/microsoftgraph/msgraph-sdk-dotnet) para trabajar con los datos devueltos por Microsoft Graph.

Además, el ejemplo usa la [biblioteca de autenticación de Microsoft (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client/) para la autenticación. El SDK de MSAL ofrece características para trabajar con el [punto de conexión v2.0 de Azure AD](https://msdn.microsoft.com/office/office365/howto/authenticate-Office-365-APIs-using-v2), lo que permite a los desarrolladores escribir un flujo de código único que controla la autenticación para las cuentas profesionales, educativas y personales.

Si desea trabajar con MSAL en una aplicación de Xamarin Forms de su elección, siga [estas instrucciones para configurar un proyecto de Xamarin Forms con MSAL](https://github.com/microsoftgraph/xamarin-csharp-connect-sample/wiki/Set-up-a-Xamarin-Forms-project-to-use-the-MSAL-.NET-SDK).

## <a name="important-note-about-the-msal-preview"></a>Nota importante acerca de la vista previa MSAL

Esta biblioteca es apta para utilizarla en un entorno de producción. Ofrecemos la misma compatibilidad de nivel de producción de esta biblioteca que la de las bibliotecas de producción actual. Durante la vista previa podemos realizar cambios en la API, el formato de caché interna y otros mecanismos de esta biblioteca, que deberá tomar junto con correcciones o mejoras. Esto puede afectar a la aplicación. Por ejemplo, un cambio en el formato de caché puede afectar a los usuarios, como que se les pida que vuelvan a iniciar sesión. Un cambio de API puede requerir que actualice su código. Cuando ofrecemos la versión de disponibilidad General, deberá actualizar a la versión de disponibilidad General dentro de seis meses, ya que las aplicaciones escritas mediante una versión de vista previa de biblioteca puede que ya no funcionen.

<a name="prerequisites"></a>
## <a name="prerequisites"></a>Requisitos previos ##

Este ejemplo necesita lo siguiente:  

  * [Visual Studio 2015](https://www.visualstudio.com/downloads) 
  * [Xamarin para Visual Studio](https://www.xamarin.com/visual-studio)
  * Windows 10 ([modo de desarrollo habilitado](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
  * Una [cuenta de Microsoft](https://www.outlook.com) o bien de [Office 365 para empresas](https://msdn.microsoft.com/office/office365/howto/setup-development-environment#bk_Office365Account)

Si desea ejecutar el proyecto de iOS en este ejemplo, necesita lo siguiente:

  * El SDK de iOS más reciente
  * La versión de Xcode más reciente
  * Mac OS X Yosemite (10.10) o superior 
  * [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/)
  * Un [agente Xamarin Mac conectado a Visual Studio](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)

Puede usar el [emulador de Visual Studio para Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) si desea ejecutar el proyecto Android.

<a name="register"></a>
## <a name="register-and-configure-the-app"></a>Registrar y configurar la aplicación

1. Inicie sesión en el [Portal de registro de la aplicación](https://apps.dev.microsoft.com/) mediante su cuenta personal, profesional o educativa.
2. Seleccione **Agregar una aplicación**.
3. Escriba un nombre para la aplicación y seleccione **Crear**.
    
    Se muestra la página de registro, indicando las propiedades de la aplicación.
 
4. En **Plataformas**, seleccione **Agregar plataforma**.
5. Seleccione **Aplicación nativa**.
6. Copie el valor del identificador de la aplicación y el valor personalizado redirección URI (en el encabezado **Aplicación nativa** encabezado) que se crea automáticamente cuando agrega la plataforma de **Aplicación nativa**. Este identificador URI debe contener el valor de identificador de la aplicación y estar en este formulario: `msal<Application Id>://auth` Deberá escribir estos valores en la aplicación de ejemplo.

    El id. de la aplicación es un identificador único para su aplicación.

7. Seleccione **Guardar**.

<a name="build"></a>
## <a name="build-and-debug"></a>Compilar y depurar ##

**Nota:** Si observa algún error durante la instalación de los paquetes en el paso 12, asegúrese de que la ruta de acceso local donde colocó la solución no es demasiado larga o profunda. Para resolver este problema, mueva la solución más cerca de la raíz de la unidad.

1. Abra el archivo App.cs dentro del proyecto **XamarinConnect (portátil)** de la solución.

    ![](/readme-images/Appdotcs.png "Open App.cs file in XamarinConnect project")

2. Después de cargar la solución en Visual Studio, configure la muestra para usar el Id. de cliente que registró convirtiendo este valor en el de la variable **ClientId** en el archivo App.cs.


    ![](/readme-images/appId.png "Client ID value in App.cs file")

3. Abra el archivo UserDetailsClient.iOS\info.plist en un editor de texto. Lamentablemente no puede editar este archivo en Visual Studio. Busque el elemento `<string>msalENTER_YOUR_CLIENT_ID</string>` en `CFBundleURLSchemes` clave.

4. Reemplace `ENTER_YOUR_CLIENT_ID` con el valor de id de aplicación que obtuvo al registrar la aplicación. Asegúrese de conservar `msal` antes del identificador de aplicación. El valor de cadena resultante debe parecerse al siguiente: `<string>msal<application id></string>`.

5. Abra el archivo UserDetailsClient.Droid\Properties\AndroidManifest.xml. Busque este elemento: `<data android:scheme="msalENTER_YOUR_CLIENT_ID" android:host="auth" />`.

6. Reemplace `ENTER_YOUR_CLIENT_ID` con el valor de id de aplicación que obtuvo al registrar la aplicación. Asegúrese de conservar `msal` antes del identificador de aplicación. El valor de cadena resultante debe parecerse al siguiente: `<data android:scheme="msal<application id>" android:host="auth" />`.

7. Seleccione el proyecto que desee ejecutar. Si selecciona la opción de plataforma universal de Windows, puede ejecutar el ejemplo en el equipo local. Si desea ejecutar el proyecto iOS, necesitará conectarse a un [Mac que tenga las herramientas Xamarin](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/) instaladas. (También puede abrir esta solución en Xamarin Studio en un Mac y ejecutar el ejemplo directamente desde allí). Puede usar el [Emulador de Visual Studio para Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) si desea ejecutar el proyecto de Android. 

    ![](/readme-images/SelectProject.png "Select project in Visual Studio")

8. Pulse F5 para compilar y depurar. Ejecute la solución e inicie sesión con su cuenta personal, profesional o educativa.
    > **Nota** Es posible que tenga que abrir el administrador de configuración de compilación para asegurarse de que los pasos de compilación e implementación están seleccionados para el proyecto UWP.

| UWP | Android | iOS |
| --- | ------- | ----|
| <img src="/readme-images/UWP.png" alt="Connect sample on UWP" width="100%" /> | <img src="/readme-images/Droid.png" alt="Connect sample on Android" width="100%" /> | <img src="/readme-images/iOS.png" alt="Connect sample on iOS" width="100%" /> |

### <a name="summary-of-key-methods"></a>Resumen de métodos clave

El código en la página principal de la aplicación es relativamente sencillo y fácil de entender, ya que las llamadas de servicio de autenticación y el correo electrónico realmente se producen en las clases auxiliares. El código de la página principal se compone principalmente de controladores de eventos para los dos botones:

- **OnSignInSignOut**
    
    Cuando el valor de texto de este botón es "connect", este método llama al método **GetAuthenticatedClient** para adquirir un objeto **GraphServicesClient** que representa al usuario actual y que se usa para definir la dirección de correo electrónico del usuario y el nombre para mostrar. Si la operación se realiza correctamente, también habilita el botón **Enviar correo** y el cuadro de texto donde el usuario puede escribir una dirección de correo electrónico, y rellena el cuadro de texto con su propia dirección de correo electrónico.

- **MailButton_Click**
    
    Este método llama al método **ComposeAndSendMailAsync**, usando el conjunto de variables de dirección de correo electrónico y del nombre para mostrar durante **ConnectButton_Click**. Si esta llamada al método se realiza correctamente, también actualiza el texto de la interfaz de usuario en consecuencia.

Teniendo esto en cuenta, es importante examinar dos métodos de las clases auxiliares con mayor detalle:

- **GetAuthenticatedClient**
    
    Este método de la clase **AuthenticationHelper** autentica al usuario con la biblioteca de autenticación de Microsoft (MSAL).

    Para ello es necesario recuperar un token de autenticación de un objeto **PublicClientApplication** de MSAL y, después, pasar ese token a un objeto **DelegateAuthenticationProvider** de Microsoft Graph.

    El método **SignInCurrentUserAsync** de la página principal puede leer después al usuario de este objeto **GraphServicesClient** y establecer la dirección de correo electrónico del usuario y el nombre para mostrar.

- **ComposeAndSendMailAsync**

    Este método de la clase **MailHelper** redacta y envía el correo electrónico de ejemplo.

<a name="contributing"></a>
## <a name="contributing"></a>Colaboradores ##

Si le gustaría contribuir a este ejemplo, consulte [CONTRIBUTING.MD](/CONTRIBUTING.md).

Este proyecto ha adoptado el [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) (Código de conducta de código abierto de Microsoft). Para obtener más información, consulte las [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) (Preguntas más frecuentes del código de conducta) o póngase en contacto con [opencode@microsoft.com](mailto:opencode@microsoft.com) con otras preguntas o comentarios.

<a name="questions"></a>
## <a name="questions-and-comments"></a>Preguntas y comentarios

Nos encantaría recibir sus comentarios acerca del ejemplo de Connect de Microsoft Graph para el proyecto Xamarin Forms. Puede enviarnos sus preguntas y sugerencias a través de la sección [Problemas](https://github.com/MicrosoftGraph/xamarin-csharp-connect-sample/issues) de este repositorio.

Su opinión es importante para nosotros. Conecte con nosotros en [Desbordamiento de pila](http://stackoverflow.com/questions/tagged/office365+or+microsoftgraph). Etiquete sus preguntas con [MicrosoftGraph].

<a name="additional-resources"></a>
## <a name="additional-resources"></a>Recursos adicionales ##

- [Otros ejemplos de Connect de Microsoft Graph](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Información general de Microsoft Graph](http://graph.microsoft.io)
- [Ejemplos de código de Office Developer](http://dev.office.com/code-samples)
- [Centro de desarrollo de Office](http://dev.office.com/)


## <a name="copyright"></a>Copyright
Copyright (c) 2016 Microsoft. Todos los derechos reservados.


