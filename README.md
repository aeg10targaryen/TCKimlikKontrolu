TCKimlikKontrolu
================

www.nvi.gov.tr üyeliğinizle kolay bir şekilde T.C. Kimlik konrolü ve T.C. kimlik bilgilerini size dönen bir bileşendir.


Aşağıdaki Namespace leri projenize ekleyiniz

System.IdentityModel<br>
System.Runtime.Serialization<br>
System.ServiceModel<br>
Microsoft.IdentityModel<br>

Daha sonra Web.config dosyanıza aşağıdaki bilgileri ekleyiniz.

```xml
<system.serviceModel>
    <bindings>
      <customBinding>
        <binding name="default" sendTimeout="00:05:00">
          <textMessageEncoding>
            <readerQuotas maxDepth="2147483647" maxStringContentLength="2147483647"
              maxArrayLength="2147483647" maxBytesPerRead="2147483647" maxNameTableCharCount="2147483647" />
          </textMessageEncoding>
          <httpTransport maxReceivedMessageSize="2147483647" />
        </binding>
        <binding name="kpsBinding">
          <security authenticationMode="IssuedTokenOverTransport">
            <secureConversationBootstrap />
          </security>
          <textMessageEncoding />
          <httpsTransport maxReceivedMessageSize="2147483647" />
        </binding>
        <binding name="CustomBinding_KisiSorgulaTCKimlikNoServis">
          <security defaultAlgorithmSuite="Default" authenticationMode="IssuedTokenOverTransport"
            requireDerivedKeys="false" securityHeaderLayout="Strict" includeTimestamp="true"
            keyEntropyMode="CombinedEntropy" messageSecurityVersion="WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10">
            <issuedTokenParameters keyType="SymmetricKey" tokenType="">
              <issuer address="https://kimlikdogrulama.nvi.gov.tr/Services/Issuer.svc/IWSTrust13" />
              <issuerMetadata address="https://kimlikdogrulama.nvi.gov.tr/Services/Issuer.svc/mex" />
            </issuedTokenParameters>
            <localClientSettings cacheCookies="true" detectReplays="false"
              replayCacheSize="900000" maxClockSkew="00:05:00" maxCookieCachingTime="Infinite"
              replayWindow="00:05:00" sessionKeyRenewalInterval="10:00:00"
              sessionKeyRolloverInterval="00:05:00" reconnectTransportOnFailure="true"
              timestampValidityDuration="00:05:00" cookieRenewalThresholdPercentage="60" />
            <localServiceSettings detectReplays="false" issuedCookieLifetime="10:00:00"
              maxStatefulNegotiations="128" replayCacheSize="900000" maxClockSkew="00:05:00"
              negotiationTimeout="00:01:00" replayWindow="00:05:00" inactivityTimeout="00:02:00"
              sessionKeyRenewalInterval="15:00:00" sessionKeyRolloverInterval="00:05:00"
              reconnectTransportOnFailure="true" maxPendingSessions="128"
              maxCachedCookies="1000" timestampValidityDuration="00:05:00" />
            <secureConversationBootstrap />
          </security>
          <textMessageEncoding maxReadPoolSize="64" maxWritePoolSize="16"
            messageVersion="Default" writeEncoding="utf-8">
            <readerQuotas maxDepth="32" maxStringContentLength="8192" maxArrayLength="16384"
              maxBytesPerRead="4096" maxNameTableCharCount="16384" />
          </textMessageEncoding>
          <httpsTransport manualAddressing="false" maxBufferPoolSize="524288"
            maxReceivedMessageSize="65536" allowCookies="false" authenticationScheme="Anonymous"
            bypassProxyOnLocal="false" decompressionEnabled="true" hostNameComparisonMode="StrongWildcard"
            keepAliveEnabled="true" maxBufferSize="65536" proxyAuthenticationScheme="Anonymous"
            realm="" transferMode="Buffered" unsafeConnectionNtlmAuthentication="false"
            useDefaultWebProxy="true" requireClientCertificate="false" />
        </binding>
        <binding name="CustomBinding_KisiListeleServis" />
        <binding name="CustomBinding_TcKimlikNoSorgulaAdresServis" />
        <binding name="CustomBinding_KisiSorgulaTCKimlikNoServis1">
          <security defaultAlgorithmSuite="Default" authenticationMode="IssuedTokenOverTransport"
            requireDerivedKeys="false" securityHeaderLayout="Strict" includeTimestamp="true"
            keyEntropyMode="CombinedEntropy" messageSecurityVersion="WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10">
            <issuedTokenParameters keyType="SymmetricKey" tokenType="">
              <issuer address="https://kimlikdogrulama.nvi.gov.tr/Services/Issuer.svc/IWSTrust13"
                binding="ws2007HttpBinding" bindingConfiguration="https://kimlikdogrulama.nvi.gov.tr/Services/Issuer.svc/IWSTrust13" />
              <issuerMetadata address="https://kimlikdogrulama.nvi.gov.tr/Services/Issuer.svc/mex" />
            </issuedTokenParameters>
            <localClientSettings cacheCookies="true" detectReplays="false"
              replayCacheSize="900000" maxClockSkew="00:05:00" maxCookieCachingTime="Infinite"
              replayWindow="00:05:00" sessionKeyRenewalInterval="10:00:00"
              sessionKeyRolloverInterval="00:05:00" reconnectTransportOnFailure="true"
              timestampValidityDuration="00:05:00" cookieRenewalThresholdPercentage="60" />
            <localServiceSettings detectReplays="false" issuedCookieLifetime="10:00:00"
              maxStatefulNegotiations="128" replayCacheSize="900000" maxClockSkew="00:05:00"
              negotiationTimeout="00:01:00" replayWindow="00:05:00" inactivityTimeout="00:02:00"
              sessionKeyRenewalInterval="15:00:00" sessionKeyRolloverInterval="00:05:00"
              reconnectTransportOnFailure="true" maxPendingSessions="128"
              maxCachedCookies="1000" timestampValidityDuration="00:05:00" />
            <secureConversationBootstrap />
          </security>
          <textMessageEncoding maxReadPoolSize="64" maxWritePoolSize="16"
            messageVersion="Default" writeEncoding="utf-8">
            <readerQuotas maxDepth="32" maxStringContentLength="8192" maxArrayLength="16384"
              maxBytesPerRead="4096" maxNameTableCharCount="16384" />
          </textMessageEncoding>
          <httpsTransport manualAddressing="false" maxBufferPoolSize="524288"
            maxReceivedMessageSize="65536" allowCookies="false" authenticationScheme="Anonymous"
            bypassProxyOnLocal="false" decompressionEnabled="true" hostNameComparisonMode="StrongWildcard"
            keepAliveEnabled="true" maxBufferSize="65536" proxyAuthenticationScheme="Anonymous"
            realm="" transferMode="Buffered" unsafeConnectionNtlmAuthentication="false"
            useDefaultWebProxy="true" requireClientCertificate="false" />
        </binding>
        <binding name="CustomBinding_KisiSorgulaTCKimlikNoServis2" />
      </customBinding>
      <ws2007HttpBinding>
        <binding name="IssuedTokenBinding">
          <readerQuotas maxArrayLength="2147483647" />
          <security mode="TransportWithMessageCredential">
            <message clientCredentialType="Windows" establishSecurityContext="false" />
          </security>
        </binding>
        <binding name="WS2007HttpBinding_IWSTrust13Sync" closeTimeout="00:01:00"
          openTimeout="00:01:00" receiveTimeout="00:10:00" sendTimeout="00:01:00"
          bypassProxyOnLocal="false" transactionFlow="false" hostNameComparisonMode="StrongWildcard"
          maxBufferPoolSize="524288" maxReceivedMessageSize="65536" messageEncoding="Text"
          textEncoding="utf-8" useDefaultWebProxy="true" allowCookies="false">
          <readerQuotas maxDepth="32" maxStringContentLength="8192" maxArrayLength="2147483647"
            maxBytesPerRead="4096" maxNameTableCharCount="16384" />
          <reliableSession ordered="true" inactivityTimeout="00:10:00"
            enabled="false" />
          <security mode="TransportWithMessageCredential">
            <transport clientCredentialType="None" proxyCredentialType="None"
              realm="" />
            <message clientCredentialType="None" negotiateServiceCredential="true"
              algorithmSuite="Default" establishSecurityContext="false" />
          </security>
        </binding>
        <binding name="stsIssuerServiceBinding">
          <security mode="TransportWithMessageCredential">
            <transport clientCredentialType="None" />
            <message clientCredentialType="UserName" establishSecurityContext="false" />
          </security>
        </binding>
        <binding name="https://kimlikdogrulama.nvi.gov.tr/Services/Issuer.svc/IWSTrust13"
          closeTimeout="00:01:00" openTimeout="00:01:00" receiveTimeout="00:10:00"
          sendTimeout="00:01:00" bypassProxyOnLocal="false" transactionFlow="false"
          hostNameComparisonMode="StrongWildcard" maxBufferPoolSize="524288"
          maxReceivedMessageSize="65536" messageEncoding="Text" textEncoding="utf-8"
          useDefaultWebProxy="true" allowCookies="false">
          <readerQuotas maxDepth="32" maxStringContentLength="8192" maxArrayLength="16384"
            maxBytesPerRead="4096" maxNameTableCharCount="16384" />
          <reliableSession ordered="true" inactivityTimeout="00:10:00"
            enabled="false" />
          <security mode="TransportWithMessageCredential">
            <transport clientCredentialType="None" proxyCredentialType="None"
              realm="" />
            <message clientCredentialType="UserName" negotiateServiceCredential="true"
              algorithmSuite="Default" establishSecurityContext="false" />
          </security>
        </binding>
      </ws2007HttpBinding>
    </bindings>
    <client>
      <endpoint address="https://kimlikdogrulama.nvi.gov.tr/Services/Issuer.svc/IWSTrust13" binding="ws2007HttpBinding" bindingConfiguration="stsIssuerServiceBinding" contract="Microsoft.IdentityModel.Protocols.WSTrust.IWSTrustChannelContract" name="STSIssuerService"/>
      <endpoint address="https://kpsv2.nvi.gov.tr/Services/RoutingService.svc" binding="customBinding" bindingConfiguration="kpsBinding" contract="KPSKimlik.KisiSorgulaTCKimlikNoServis" name="BindingKisiSorgulaTCKimlikNoServis"/>
      <endpoint address="https://kpsv2.nvi.gov.tr/Services/RoutingService.svc" binding="customBinding" bindingConfiguration="kpsBinding" contract="KisiListele.KisiListeleServis" name="BindingKisiListeleServis"/>
      <endpoint address="https://kpsv2.nvi.gov.tr/Services/RoutingService.svc" binding="customBinding" bindingConfiguration="kpsBinding" contract="TCKimlikAdresSorgula.TcKimlikNoSorgulaAdresServis" name="BindingTcKimlikNoSorgulaAdresServis"/>
      <endpoint address="https://kpsv2.nvi.gov.tr/Services/RoutingService.svc" binding="customBinding" bindingConfiguration="CustomBinding_KisiSorgulaTCKimlikNoServis1" contract="KPSKimlik.KisiSorgulaTCKimlikNoServis" name="CustomBinding_KisiSorgulaTCKimlikNoServis"/>
    </client>
</system.serviceModel>
```
Son olarak Web.config dosyanızadaki AppSettings alanında bulunan KpsUserName ve KpsPassword alanını kendi 
kullanıcı bilgilerinizi yazarak eklentiyi kolayca kullanabilirsiniz.


T.C. Kimlik numarasını belirttiğiniz kişinin bilgileri aşağıdaki gibi gelecektir.

Ad<br>
Soyad<br>
Cinsiyet<br>
DogumYeri<br>
DogumTarihi<br>
OlumTarihi<br>
MedeniDurumu<br>
NufusIl<br>
NufusIlce<br>
MahalleKoy<br>
AileSiraNo<br>
BireySiraNo<br>
Cilt<br>
AnneAdi<br>
BabaAdi
