using System.Configuration;

namespace OnSolve.EP.Resources
{
    /// <summary>
    /// Class Configuration
    /// </summary>
    public static class Configuration
    {

        /// <summary>
        /// Gets the name of the EndPoint.
        /// </summary>
        /// <value>The name of the EndPoint.</value>
        public static string EndPoint
        {
            get { return ConfigurationManager.AppSettings["EndPoint"]; }
        }

        /// <summary>
        /// Gets the name of the AppId.
        /// </summary>
        /// <value>The name of the AppId.</value>
        public static string AppId
        {
            get { return ConfigurationManager.AppSettings["AppId"]; }
        }

    }
}