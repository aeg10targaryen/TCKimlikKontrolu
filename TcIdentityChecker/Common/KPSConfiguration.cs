using System.Configuration;

namespace TcIdentityChecker.Common
{
    public class KpsConfiguration
    {
        #region Fields

        public static KpsConfiguration Instance = new KpsConfiguration();

        private string _endPoint;
        private string _username;
        private string _password;

        #endregion

        #region Constructors

        private KpsConfiguration()
        {
            _endPoint = "https://kpsv2.nvi.gov.tr/Services/RoutingService.svc";
            _username = ConfigurationManager.AppSettings["KpsUserName"];
            _password = ConfigurationManager.AppSettings["KpsPassword"];
        }

        #endregion

        #region Properties

        public string EndPoint
        {
            get { return _endPoint; }
            set { _endPoint = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        #endregion

    }
}
