# Android SSL Reproduction

[![Maui Issue Status](https://img.shields.io/github/issues/detail/state/dotnet/maui/33454)](https://github.com/dotnet/maui/issues/33454)

This is a strange one where we've noticed our maui android applications refuse to connect to urls behind the `opralog.com` domain.

The phones themselves are able to connect to these urls using a browser, but cannot connect when the request is made by the maui app.

## Reproduction Steps

- Build this project
- Deploy to an iOS device
- Enter the following url: `https://certtest.opralog.com:8443/`
- Verify the url
- The url verifies successfully
- Change to an android device (physical preffered)
- Enter the same url: `https://certtest.opralog.com:8443/`
- Verify the url

At this point we get the following exception:
```
System.Net.Http.HttpClient.UrlVerifierClient.LogicalHandler: Information: Start processing HTTP request GET https://certtest.opralog.com:8443/
System.Net.Http.HttpClient.UrlVerifierClient.ClientHandler: Information: Sending HTTP request GET https://certtest.opralog.com:8443/
System.Net.Http.HttpClient.UrlVerifierClient.ClientHandler: Information: HTTP request failed after 162.2865ms

System.Net.Http.HttpRequestException: Connection failure
 ---> Javax.Net.Ssl.SSLHandshakeException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
 ---> Java.Security.Cert.CertificateException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
 ---> Java.Security.Cert.CertPathValidatorException: Trust anchor for certification path not found.

  --- End of managed Java.Security.Cert.CertPathValidatorException stack trace ---
java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:658)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:617)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:507)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:426)
	at com.android.org.conscrypt.TrustManagerImpl.getTrustedChainForServer(TrustManagerImpl.java:354)
	at android.security.net.config.NetworkSecurityTrustManager.checkServerTrusted(NetworkSecurityTrustManager.java:94)
	at android.security.net.config.RootTrustManager.checkServerTrusted(RootTrustManager.java:89)
	at com.android.org.conscrypt.Platform.checkServerTrusted(Platform.java:224)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.verifyCertificateChain(ConscryptFileDescriptorSocket.java:407)
	at com.android.org.conscrypt.NativeCrypto.SSL_do_handshake(Native Method)
	at com.android.org.conscrypt.NativeSsl.doHandshake(NativeSsl.java:387)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.startHandshake(ConscryptFileDescriptorSocket.java:226)
	at com.android.okhttp.internal.io.RealConnection.connectTls(RealConnection.java:196)
	at com.android.okhttp.internal.io.RealConnection.connectSocket(RealConnection.java:153)
	at com.android.okhttp.internal.io.RealConnection.connect(RealConnection.java:116)
	at com.android.okhttp.internal.http.StreamAllocation.findConnection(StreamAllocation.java:186)
	at com.android.okhttp.internal.http.StreamAllocation.findHealthyConnection(StreamAllocation.java:128)
	at com.android.okhttp.internal.http.StreamAllocation.newStream(StreamAllocation.java:97)
	at com.android.okhttp.internal.http.HttpEngine.connect(HttpEngine.java:289)
	at com.android.okhttp.internal.http.HttpEngine.sendRequest(HttpEngine.java:232)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.execute(HttpURLConnectionImpl.java:465)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.connect(HttpURLConnectionImpl.java:131)
	at com.android.okhttp.internal.huc.DelegatingHttpsURLConnection.connect(DelegatingHttpsURLConnection.java:90)
	at com.android.okhttp.internal.huc.HttpsURLConnectionImpl.connect(HttpsURLConnectionImpl.java:30)

   --- End of inner exception stack trace ---

  --- End of managed Java.Security.Cert.CertificateException stack trace ---
java.security.cert.CertificateException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:658)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:617)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:507)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:426)
	at com.android.org.conscrypt.TrustManagerImpl.getTrustedChainForServer(TrustManagerImpl.java:354)
	at android.security.net.config.NetworkSecurityTrustManager.checkServerTrusted(NetworkSecurityTrustManager.java:94)
	at android.security.net.config.RootTrustManager.checkServerTrusted(RootTrustManager.java:89)
	at com.android.org.conscrypt.Platform.checkServerTrusted(Platform.java:224)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.verifyCertificateChain(ConscryptFileDescriptorSocket.java:407)
	at com.android.org.conscrypt.NativeCrypto.SSL_do_handshake(Native Method)
	at com.android.org.conscrypt.NativeSsl.doHandshake(NativeSsl.java:387)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.startHandshake(ConscryptFileDescriptorSocket.java:226)
	at com.android.okhttp.internal.io.RealConnection.connectTls(RealConnection.java:196)
	at com.android.okhttp.internal.io.RealConnection.connectSocket(RealConnection.java:153)
	at com.android.okhttp.internal.io.RealConnection.connect(RealConnection.java:116)
	at com.android.okhttp.internal.http.StreamAllocation.findConnection(StreamAllocation.java:186)
	at com.android.okhttp.internal.http.StreamAllocation.findHealthyConnection(StreamAllocation.java:128)
	at com.android.okhttp.internal.http.StreamAllocation.newStream(StreamAllocation.java:97)
	at com.android.okhttp.internal.http.HttpEngine.connect(HttpEngine.java:289)
	at com.android.okhttp.internal.http.HttpEngine.sendRequest(HttpEngine.java:232)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.execute(HttpURLConnectionImpl.java:465)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.connect(HttpURLConnectionImpl.java:131)
	at com.android.okhttp.internal.huc.DelegatingHttpsURLConnection.connect(DelegatingHttpsURLConnection.java:90)
	at com.android.okhttp.internal.huc.HttpsURLConnectionImpl.connect(HttpsURLConnectionImpl.java:30)
Caused by: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	... 24 more

   --- End of inner exception stack trace ---
   at Java.Interop.JniEnvironment.InstanceMethods.CallVoidMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
   at Java.Interop.JniPeerMembers.JniInstanceMethods.InvokeAbstractVoidMethod(String encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
   at Javax.Net.Ssl.HttpsURLConnectionInvoker.Connect()
   at Xamarin.Android.Net.AndroidMessageHandler.<>c__DisplayClass137_0.<ConnectAsync>b__0()
  --- End of managed Javax.Net.Ssl.SSLHandshakeException stack trace ---
javax.net.ssl.SSLHandshakeException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.startHandshake(ConscryptFileDescriptorSocket.java:231)
	at com.android.okhttp.internal.io.RealConnection.connectTls(RealConnection.java:196)
	at com.android.okhttp.internal.io.RealConnection.connectSocket(RealConnection.java:153)
	at com.android.okhttp.internal.io.RealConnection.connect(RealConnection.java:116)
	at com.android.okhttp.internal.http.StreamAllocation.findConnection(StreamAllocation.java:186)
	at com.android.okhttp.internal.http.StreamAllocation.findHealthyConnection(StreamAllocation.java:128)
	at com.android.okhttp.internal.http.StreamAllocation.newStream(StreamAllocation.java:97)
	at com.android.okhttp.internal.http.HttpEngine.connect(HttpEngine.java:289)
	at com.android.okhttp.internal.http.HttpEngine.sendRequest(HttpEngine.java:232)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.execute(HttpURLConnectionImpl.java:465)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.connect(HttpURLConnectionImpl.java:131)
	at com.android.okhttp.internal.huc.DelegatingHttpsURLConnection.connect(DelegatingHttpsURLConnection.java:90)
	at com.android.okhttp.internal.huc.HttpsURLConnectionImpl.connect(HttpsURLConnectionImpl.java:30)
Caused by: java.security.cert.CertificateException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:658)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:617)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:507)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:426)
	at com.android.org.conscrypt.TrustManagerImpl.getTrustedChainForServer(TrustManagerImpl.java:354)
	at android.security.net.config.NetworkSecurityTrustManager.checkServerTrusted(NetworkSecurityTrustManager.java:94)
	at android.security.net.config.RootTrustManager.checkServerTrusted(RootTrustManager.java:89)
	at com.android.org.conscrypt.Platform.checkServerTrusted(Platform.java:224)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.verifyCertificateChain(ConscryptFileDescriptorSocket.java:407)
	at com.android.org.conscrypt.NativeCrypto.SSL_do_handshake(Native Method)
	at com.android.org.conscrypt.NativeSsl.doHandshake(NativeSsl.java:387)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.startHandshake(ConscryptFileDescriptorSocket.java:226)
	... 12 more
Caused by: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	... 24 more

   --- End of inner exception stack trace ---
   at Xamarin.Android.Net.AndroidMessageHandler.<>c__DisplayClass137_0.<ConnectAsync>b__0()
   at System.Threading.Tasks.Task.InnerInvoke()
   at System.Threading.Tasks.Task.<>c.<.cctor>b__288_0(Object obj)
   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
--- End of stack trace from previous location ---
   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot, Thread threadPoolThread)
--- End of stack trace from previous location ---
   at Xamarin.Android.Net.AndroidMessageHandler.DoProcessRequest(HttpRequestMessage request, URL javaUrl, HttpURLConnection httpConnection, CancellationToken cancellationToken, RequestRedirectionState redirectState)
   at Xamarin.Android.Net.AndroidMessageHandler.DoSendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at Microsoft.Extensions.Http.Logging.LoggingHttpMessageHandler.<SendCoreAsync>g__Core|4_0(HttpRequestMessage request, Boolean useAsync, CancellationToken cancellationToken)
System.Net.Http.HttpClient.UrlVerifierClient.LogicalHandler: Information: HTTP request failed after 180.966ms

System.Net.Http.HttpRequestException: Connection failure
 ---> Javax.Net.Ssl.SSLHandshakeException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
 ---> Java.Security.Cert.CertificateException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
 ---> Java.Security.Cert.CertPathValidatorException: Trust anchor for certification path not found.

  --- End of managed Java.Security.Cert.CertPathValidatorException stack trace ---
java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:658)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:617)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:507)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:426)
	at com.android.org.conscrypt.TrustManagerImpl.getTrustedChainForServer(TrustManagerImpl.java:354)
	at android.security.net.config.NetworkSecurityTrustManager.checkServerTrusted(NetworkSecurityTrustManager.java:94)
	at android.security.net.config.RootTrustManager.checkServerTrusted(RootTrustManager.java:89)
	at com.android.org.conscrypt.Platform.checkServerTrusted(Platform.java:224)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.verifyCertificateChain(ConscryptFileDescriptorSocket.java:407)
	at com.android.org.conscrypt.NativeCrypto.SSL_do_handshake(Native Method)
	at com.android.org.conscrypt.NativeSsl.doHandshake(NativeSsl.java:387)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.startHandshake(ConscryptFileDescriptorSocket.java:226)
	at com.android.okhttp.internal.io.RealConnection.connectTls(RealConnection.java:196)
	at com.android.okhttp.internal.io.RealConnection.connectSocket(RealConnection.java:153)
	at com.android.okhttp.internal.io.RealConnection.connect(RealConnection.java:116)
	at com.android.okhttp.internal.http.StreamAllocation.findConnection(StreamAllocation.java:186)
	at com.android.okhttp.internal.http.StreamAllocation.findHealthyConnection(StreamAllocation.java:128)
	at com.android.okhttp.internal.http.StreamAllocation.newStream(StreamAllocation.java:97)
	at com.android.okhttp.internal.http.HttpEngine.connect(HttpEngine.java:289)
	at com.android.okhttp.internal.http.HttpEngine.sendRequest(HttpEngine.java:232)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.execute(HttpURLConnectionImpl.java:465)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.connect(HttpURLConnectionImpl.java:131)
	at com.android.okhttp.internal.huc.DelegatingHttpsURLConnection.connect(DelegatingHttpsURLConnection.java:90)
	at com.android.okhttp.internal.huc.HttpsURLConnectionImpl.connect(HttpsURLConnectionImpl.java:30)

   --- End of inner exception stack trace ---

  --- End of managed Java.Security.Cert.CertificateException stack trace ---
java.security.cert.CertificateException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:658)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:617)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:507)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:426)
	at com.android.org.conscrypt.TrustManagerImpl.getTrustedChainForServer(TrustManagerImpl.java:354)
	at android.security.net.config.NetworkSecurityTrustManager.checkServerTrusted(NetworkSecurityTrustManager.java:94)
	at android.security.net.config.RootTrustManager.checkServerTrusted(RootTrustManager.java:89)
	at com.android.org.conscrypt.Platform.checkServerTrusted(Platform.java:224)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.verifyCertificateChain(ConscryptFileDescriptorSocket.java:407)
	at com.android.org.conscrypt.NativeCrypto.SSL_do_handshake(Native Method)
	at com.android.org.conscrypt.NativeSsl.doHandshake(NativeSsl.java:387)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.startHandshake(ConscryptFileDescriptorSocket.java:226)
	at com.android.okhttp.internal.io.RealConnection.connectTls(RealConnection.java:196)
	at com.android.okhttp.internal.io.RealConnection.connectSocket(RealConnection.java:153)
	at com.android.okhttp.internal.io.RealConnection.connect(RealConnection.java:116)
	at com.android.okhttp.internal.http.StreamAllocation.findConnection(StreamAllocation.java:186)
	at com.android.okhttp.internal.http.StreamAllocation.findHealthyConnection(StreamAllocation.java:128)
	at com.android.okhttp.internal.http.StreamAllocation.newStream(StreamAllocation.java:97)
	at com.android.okhttp.internal.http.HttpEngine.connect(HttpEngine.java:289)
	at com.android.okhttp.internal.http.HttpEngine.sendRequest(HttpEngine.java:232)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.execute(HttpURLConnectionImpl.java:465)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.connect(HttpURLConnectionImpl.java:131)
	at com.android.okhttp.internal.huc.DelegatingHttpsURLConnection.connect(DelegatingHttpsURLConnection.java:90)
	at com.android.okhttp.internal.huc.HttpsURLConnectionImpl.connect(HttpsURLConnectionImpl.java:30)
Caused by: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	... 24 more

   --- End of inner exception stack trace ---
   at Java.Interop.JniEnvironment.InstanceMethods.CallVoidMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
   at Java.Interop.JniPeerMembers.JniInstanceMethods.InvokeAbstractVoidMethod(String encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
   at Javax.Net.Ssl.HttpsURLConnectionInvoker.Connect()
   at Xamarin.Android.Net.AndroidMessageHandler.<>c__DisplayClass137_0.<ConnectAsync>b__0()
  --- End of managed Javax.Net.Ssl.SSLHandshakeException stack trace ---
javax.net.ssl.SSLHandshakeException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.startHandshake(ConscryptFileDescriptorSocket.java:231)
	at com.android.okhttp.internal.io.RealConnection.connectTls(RealConnection.java:196)
	at com.android.okhttp.internal.io.RealConnection.connectSocket(RealConnection.java:153)
	at com.android.okhttp.internal.io.RealConnection.connect(RealConnection.java:116)
	at com.android.okhttp.internal.http.StreamAllocation.findConnection(StreamAllocation.java:186)
	at com.android.okhttp.internal.http.StreamAllocation.findHealthyConnection(StreamAllocation.java:128)
	at com.android.okhttp.internal.http.StreamAllocation.newStream(StreamAllocation.java:97)
	at com.android.okhttp.internal.http.HttpEngine.connect(HttpEngine.java:289)
	at com.android.okhttp.internal.http.HttpEngine.sendRequest(HttpEngine.java:232)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.execute(HttpURLConnectionImpl.java:465)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.connect(HttpURLConnectionImpl.java:131)
	at com.android.okhttp.internal.huc.DelegatingHttpsURLConnection.connect(DelegatingHttpsURLConnection.java:90)
	at com.android.okhttp.internal.huc.HttpsURLConnectionImpl.connect(HttpsURLConnectionImpl.java:30)
Caused by: java.security.cert.CertificateException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:658)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:617)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:507)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:426)
	at com.android.org.conscrypt.TrustManagerImpl.getTrustedChainForServer(TrustManagerImpl.java:354)
	at android.security.net.config.NetworkSecurityTrustManager.checkServerTrusted(NetworkSecurityTrustManager.java:94)
	at android.security.net.config.RootTrustManager.checkServerTrusted(RootTrustManager.java:89)
	at com.android.org.conscrypt.Platform.checkServerTrusted(Platform.java:224)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.verifyCertificateChain(ConscryptFileDescriptorSocket.java:407)
	at com.android.org.conscrypt.NativeCrypto.SSL_do_handshake(Native Method)
	at com.android.org.conscrypt.NativeSsl.doHandshake(NativeSsl.java:387)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.startHandshake(ConscryptFileDescriptorSocket.java:226)
	... 12 more
Caused by: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	... 24 more

   --- End of inner exception stack trace ---
   at Xamarin.Android.Net.AndroidMessageHandler.<>c__DisplayClass137_0.<ConnectAsync>b__0()
   at System.Threading.Tasks.Task.InnerInvoke()
   at System.Threading.Tasks.Task.<>c.<.cctor>b__288_0(Object obj)
   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
--- End of stack trace from previous location ---
   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot, Thread threadPoolThread)
--- End of stack trace from previous location ---
   at Xamarin.Android.Net.AndroidMessageHandler.DoProcessRequest(HttpRequestMessage request, URL javaUrl, HttpURLConnection httpConnection, CancellationToken cancellationToken, RequestRedirectionState redirectState)
   at Xamarin.Android.Net.AndroidMessageHandler.DoSendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at Microsoft.Extensions.Http.Logging.LoggingHttpMessageHandler.<SendCoreAsync>g__Core|4_0(HttpRequestMessage request, Boolean useAsync, CancellationToken cancellationToken)
   at Microsoft.Extensions.Http.Logging.LoggingScopeHttpMessageHandler.<SendCoreAsync>g__Core|4_0(HttpRequestMessage request, Boolean useAsync, CancellationToken cancellationToken)
AndroidSSLRepro.ViewModels.TestUrlViewModel: Error: An exception occurred while verifying URL: https://certtest.opralog.com:8443/

System.Net.Http.HttpRequestException: Connection failure
 ---> Javax.Net.Ssl.SSLHandshakeException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
 ---> Java.Security.Cert.CertificateException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
 ---> Java.Security.Cert.CertPathValidatorException: Trust anchor for certification path not found.

  --- End of managed Java.Security.Cert.CertPathValidatorException stack trace ---
java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:658)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:617)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:507)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:426)
	at com.android.org.conscrypt.TrustManagerImpl.getTrustedChainForServer(TrustManagerImpl.java:354)
	at android.security.net.config.NetworkSecurityTrustManager.checkServerTrusted(NetworkSecurityTrustManager.java:94)
	at android.security.net.config.RootTrustManager.checkServerTrusted(RootTrustManager.java:89)
	at com.android.org.conscrypt.Platform.checkServerTrusted(Platform.java:224)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.verifyCertificateChain(ConscryptFileDescriptorSocket.java:407)
	at com.android.org.conscrypt.NativeCrypto.SSL_do_handshake(Native Method)
	at com.android.org.conscrypt.NativeSsl.doHandshake(NativeSsl.java:387)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.startHandshake(ConscryptFileDescriptorSocket.java:226)
	at com.android.okhttp.internal.io.RealConnection.connectTls(RealConnection.java:196)
	at com.android.okhttp.internal.io.RealConnection.connectSocket(RealConnection.java:153)
	at com.android.okhttp.internal.io.RealConnection.connect(RealConnection.java:116)
	at com.android.okhttp.internal.http.StreamAllocation.findConnection(StreamAllocation.java:186)
	at com.android.okhttp.internal.http.StreamAllocation.findHealthyConnection(StreamAllocation.java:128)
	at com.android.okhttp.internal.http.StreamAllocation.newStream(StreamAllocation.java:97)
	at com.android.okhttp.internal.http.HttpEngine.connect(HttpEngine.java:289)
	at com.android.okhttp.internal.http.HttpEngine.sendRequest(HttpEngine.java:232)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.execute(HttpURLConnectionImpl.java:465)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.connect(HttpURLConnectionImpl.java:131)
	at com.android.okhttp.internal.huc.DelegatingHttpsURLConnection.connect(DelegatingHttpsURLConnection.java:90)
	at com.android.okhttp.internal.huc.HttpsURLConnectionImpl.connect(HttpsURLConnectionImpl.java:30)

   --- End of inner exception stack trace ---

  --- End of managed Java.Security.Cert.CertificateException stack trace ---
java.security.cert.CertificateException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:658)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:617)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:507)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:426)
	at com.android.org.conscrypt.TrustManagerImpl.getTrustedChainForServer(TrustManagerImpl.java:354)
	at android.security.net.config.NetworkSecurityTrustManager.checkServerTrusted(NetworkSecurityTrustManager.java:94)
	at android.security.net.config.RootTrustManager.checkServerTrusted(RootTrustManager.java:89)
	at com.android.org.conscrypt.Platform.checkServerTrusted(Platform.java:224)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.verifyCertificateChain(ConscryptFileDescriptorSocket.java:407)
	at com.android.org.conscrypt.NativeCrypto.SSL_do_handshake(Native Method)
	at com.android.org.conscrypt.NativeSsl.doHandshake(NativeSsl.java:387)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.startHandshake(ConscryptFileDescriptorSocket.java:226)
	at com.android.okhttp.internal.io.RealConnection.connectTls(RealConnection.java:196)
	at com.android.okhttp.internal.io.RealConnection.connectSocket(RealConnection.java:153)
	at com.android.okhttp.internal.io.RealConnection.connect(RealConnection.java:116)
	at com.android.okhttp.internal.http.StreamAllocation.findConnection(StreamAllocation.java:186)
	at com.android.okhttp.internal.http.StreamAllocation.findHealthyConnection(StreamAllocation.java:128)
	at com.android.okhttp.internal.http.StreamAllocation.newStream(StreamAllocation.java:97)
	at com.android.okhttp.internal.http.HttpEngine.connect(HttpEngine.java:289)
	at com.android.okhttp.internal.http.HttpEngine.sendRequest(HttpEngine.java:232)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.execute(HttpURLConnectionImpl.java:465)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.connect(HttpURLConnectionImpl.java:131)
	at com.android.okhttp.internal.huc.DelegatingHttpsURLConnection.connect(DelegatingHttpsURLConnection.java:90)
	at com.android.okhttp.internal.huc.HttpsURLConnectionImpl.connect(HttpsURLConnectionImpl.java:30)
Caused by: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	... 24 more

   --- End of inner exception stack trace ---
   at Java.Interop.JniEnvironment.InstanceMethods.CallVoidMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
   at Java.Interop.JniPeerMembers.JniInstanceMethods.InvokeAbstractVoidMethod(String encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
   at Javax.Net.Ssl.HttpsURLConnectionInvoker.Connect()
   at Xamarin.Android.Net.AndroidMessageHandler.<>c__DisplayClass137_0.<ConnectAsync>b__0()
  --- End of managed Javax.Net.Ssl.SSLHandshakeException stack trace ---
javax.net.ssl.SSLHandshakeException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.startHandshake(ConscryptFileDescriptorSocket.java:231)
	at com.android.okhttp.internal.io.RealConnection.connectTls(RealConnection.java:196)
	at com.android.okhttp.internal.io.RealConnection.connectSocket(RealConnection.java:153)
	at com.android.okhttp.internal.io.RealConnection.connect(RealConnection.java:116)
	at com.android.okhttp.internal.http.StreamAllocation.findConnection(StreamAllocation.java:186)
	at com.android.okhttp.internal.http.StreamAllocation.findHealthyConnection(StreamAllocation.java:128)
	at com.android.okhttp.internal.http.StreamAllocation.newStream(StreamAllocation.java:97)
	at com.android.okhttp.internal.http.HttpEngine.connect(HttpEngine.java:289)
	at com.android.okhttp.internal.http.HttpEngine.sendRequest(HttpEngine.java:232)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.execute(HttpURLConnectionImpl.java:465)
	at com.android.okhttp.internal.huc.HttpURLConnectionImpl.connect(HttpURLConnectionImpl.java:131)
	at com.android.okhttp.internal.huc.DelegatingHttpsURLConnection.connect(DelegatingHttpsURLConnection.java:90)
	at com.android.okhttp.internal.huc.HttpsURLConnectionImpl.connect(HttpsURLConnectionImpl.java:30)
Caused by: java.security.cert.CertificateException: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:658)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrustedRecursive(TrustManagerImpl.java:617)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:507)
	at com.android.org.conscrypt.TrustManagerImpl.checkTrusted(TrustManagerImpl.java:426)
	at com.android.org.conscrypt.TrustManagerImpl.getTrustedChainForServer(TrustManagerImpl.java:354)
	at android.security.net.config.NetworkSecurityTrustManager.checkServerTrusted(NetworkSecurityTrustManager.java:94)
	at android.security.net.config.RootTrustManager.checkServerTrusted(RootTrustManager.java:89)
	at com.android.org.conscrypt.Platform.checkServerTrusted(Platform.java:224)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.verifyCertificateChain(ConscryptFileDescriptorSocket.java:407)
	at com.android.org.conscrypt.NativeCrypto.SSL_do_handshake(Native Method)
	at com.android.org.conscrypt.NativeSsl.doHandshake(NativeSsl.java:387)
	at com.android.org.conscrypt.ConscryptFileDescriptorSocket.startHandshake(ConscryptFileDescriptorSocket.java:226)
	... 12 more
Caused by: java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.
	... 24 more

   --- End of inner exception stack trace ---
   at Xamarin.Android.Net.AndroidMessageHandler.<>c__DisplayClass137_0.<ConnectAsync>b__0()
   at System.Threading.Tasks.Task.InnerInvoke()
   at System.Threading.Tasks.Task.<>c.<.cctor>b__288_0(Object obj)
   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
--- End of stack trace from previous location ---
   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot, Thread threadPoolThread)
--- End of stack trace from previous location ---
   at Xamarin.Android.Net.AndroidMessageHandler.DoProcessRequest(HttpRequestMessage request, URL javaUrl, HttpURLConnection httpConnection, CancellationToken cancellationToken, RequestRedirectionState redirectState)
   at Xamarin.Android.Net.AndroidMessageHandler.DoSendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at Microsoft.Extensions.Http.Logging.LoggingHttpMessageHandler.<SendCoreAsync>g__Core|4_0(HttpRequestMessage request, Boolean useAsync, CancellationToken cancellationToken)
   at Microsoft.Extensions.Http.Logging.LoggingScopeHttpMessageHandler.<SendCoreAsync>g__Core|4_0(HttpRequestMessage request, Boolean useAsync, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.<SendAsync>g__Core|83_0(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationTokenSource cts, Boolean disposeCts, CancellationTokenSource pendingRequestsCts, CancellationToken originalCancellationToken)
   at AndroidSSLRepro.ViewModels.TestUrlViewModel.VerifyUrl(String url) in /Users/alex.duffell/Documents/Dev/Github/Axemasta/MauiRepros/src/AndroidSSLRepro/AndroidSSLRepro/ViewModels/TestUrlViewModel.cs:line 52

```

The SSL certificate is actually validated by the device when the url is accessed via a browser. To me this indicates an issue in the dotnet android code.