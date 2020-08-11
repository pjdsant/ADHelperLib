using System.Configuration;

namespace ConsoleTest
{
    class AppSettings
    {
        public static string Domain { get { return ConfigurationManager.AppSettings["Domain"]; } }
        public static string Container { get { return ConfigurationManager.AppSettings["Container"]; } }
        public static string Admin { get { return ConfigurationManager.AppSettings["Admin"]; } }
        public static string AdminPassword { get { return ConfigurationManager.AppSettings["AdminPassword"]; } }
    }
}
