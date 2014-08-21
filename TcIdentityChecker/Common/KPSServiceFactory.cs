using System;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Security;
using RequestSecurityToken = Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken;
using RequestSecurityTokenResponse = Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityTokenResponse;
using RequestTypes = Microsoft.IdentityModel.SecurityTokenService.RequestTypes;
using WSTrustChannel = Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel;
using WSTrustChannelFactory = Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannelFactory;

namespace TcIdentityChecker.Common
{
    public class KpsServiceFactory
    {
        #region Constructors

        private KpsServiceFactory() { }

        #endregion

        #region Fields

        private static KpsServiceFactory _instance;
        private SecurityToken _token;

        #endregion

        #region Properties

        public static KpsServiceFactory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KpsServiceFactory();

                return _instance;
            }
        }

        #endregion

        #region Methods

        public SecurityToken CreateToken()
        {
            if (_token == null || _token.ValidTo <= DateTime.Now.ToUniversalTime())
            {
                var trustChannelFactory = new WSTrustChannelFactory("STSIssuerService")
                {
                    TrustVersion = TrustVersion.WSTrust13
                };
                if (trustChannelFactory.Credentials != null)
                {
                    trustChannelFactory.Credentials.UserName.UserName = KpsConfiguration.Instance.Username;
                    trustChannelFactory.Credentials.UserName.Password = KpsConfiguration.Instance.Password;
                }

                var channel = (WSTrustChannel)trustChannelFactory.CreateChannel();
                var rst = new RequestSecurityToken(RequestTypes.Issue)
                {
                    AppliesTo = new EndpointAddress(KpsConfiguration.Instance.EndPoint)
                };
                RequestSecurityTokenResponse rstr;

                _token = channel.Issue(rst, out rstr);
            }

            return _token;
        }

        #endregion
    }
}
