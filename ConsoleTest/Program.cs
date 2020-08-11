using ADHelperLib;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ADHelper adhelper = new ADHelper();

            string domain = "domain.com";
            string container = "DC=domain,DC=com";
            string admin = "admin";
            string adminPassword = "adminPassword";
            string userMain = "usermain";
            string attributeOne = "extensionAttribute1";
            string attributeTwo = "extensionAttribute2";
            string respAttributeOne = "resp1";
            string respAttributeTwo = "resp2";



            var res = "";

            var valid = adhelper.ValidateExAttributes(domain, container, admin, adminPassword, userMain, attributeOne, attributeTwo, respAttributeOne, respAttributeTwo);

            if (valid == "IsValid")
            {
                res = adhelper.ChangePassword(domain, container, admin, adminPassword, userMain, "newPassword");
            }
            else
            {
                Console.WriteLine("No match");
            }
                        

            Console.WriteLine(res);

            Console.ReadKey();

        }
    }
}
