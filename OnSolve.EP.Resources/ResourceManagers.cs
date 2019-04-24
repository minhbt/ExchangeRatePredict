using System.Reflection;
using System.Resources;
using System.Globalization;
namespace OnSolve.EP.Resources
{
    public static class ResourceManagers
    {
       static ResourceManager rm = new ResourceManager("UsingRESX.Resource1", Assembly.GetExecutingAssembly());
        /// <summary>
        /// Gets the name of the FromAgr.
        /// </summary>
        /// <value>The name of the FromAgr.</value>
        public static string FromAgr
        {
            get {

                return rm.GetString("FromAgr");
             }
        }

        /// <summary>
        /// Gets the name of the ToAgr.
        /// </summary>
        /// <value>The name of the ToAgr.</value>
        public static string ToAgr
        {
            get {

                return rm.GetString("ToAgr"); 
            
            }
        }

        /// <summary>
        /// Gets the name of the ToAgr.
        /// </summary>
        /// <value>The name of the ToAgr.</value>
        public static string mgs_exchange_rate_result
        {
            get
            {

                return rm.GetString("mgs_exchange_rate_result");

            }
        }


        /// <summary>
        /// Gets the name of the ToAgr.
        /// </summary>
        /// <value>The name of the ToAgr.</value>
        public static string mgs_from_to_arg_missing
        {
            get
            {

                return rm.GetString("mgs_from_to_arg_missing");

            }
        }



    }
}
