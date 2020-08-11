using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace ADHelperLib
{
    public class ADHelper
    {
        public string ValidateExAttributes(string domain, string container, string admin, string adminPassword, 
                string userMain, string attributeOne, string attributeTwo, string respAttributeOne, string respAttributeTwo)
        {
            string result = "";

            if (string.IsNullOrWhiteSpace(domain))
                result = "Invalid Domain";
            if (string.IsNullOrWhiteSpace(container))
                result = "Invalid Container";
            if (string.IsNullOrWhiteSpace(admin))
                result = "Invalid Admin User";
            if (string.IsNullOrWhiteSpace(adminPassword))
                result = "Invalid Admin Password";
            if (string.IsNullOrWhiteSpace(userMain))
                result = "Invalid User";
            if (string.IsNullOrWhiteSpace(attributeOne))
                result = "Invalid AttributeOne";
            if (string.IsNullOrWhiteSpace(attributeTwo))
                result = "Invalid AttributeTwo";
            if (string.IsNullOrWhiteSpace(respAttributeOne))
                result = "Invalid RespAttributeOne";
            if (string.IsNullOrWhiteSpace(respAttributeTwo))
                result = "Invalid RespAttributeTwo";
            
            if (string.IsNullOrWhiteSpace(result)) {
                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain, container, admin, adminPassword);
                    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userMain);
                    var de = (DirectoryEntry)user.GetUnderlyingObject();

                    if (de.Properties.Contains(attributeOne) && de.Properties.Contains(attributeTwo))
                    {
                        if (respAttributeOne == (string)de.Properties[attributeOne].Value && respAttributeTwo == (string)de.Properties[attributeTwo].Value)
                        {
                            result = "IsValid";
                        }
                        else
                        {
                            result = "NotIsValid";
                        }
                    }
                    else
                    {
                        result = "NotIsValid";
                    }

                }
                catch (Exception ex)
                {
                    result = "NotIsValid" + " - " + ex.Message.ToString();
                }
            }
            
            return result;


        }


        public string UnlockUser(string domain, string container, string admin, string adminPassword,
                string userMain)
        {
            string result = "";

            if (string.IsNullOrWhiteSpace(domain))
                result = "Invalid Domain";
            if (string.IsNullOrWhiteSpace(container))
                result = "Invalid Container";
            if (string.IsNullOrWhiteSpace(admin))
                result = "Invalid Admin User";
            if (string.IsNullOrWhiteSpace(adminPassword))
                result = "Invalid Admin Password";
            if (string.IsNullOrWhiteSpace(userMain))
                result = "Invalid User";

            if (string.IsNullOrWhiteSpace(result))
            {
                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain, container, admin, adminPassword);
                    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userMain);

                    if (user != null && user.IsAccountLockedOut())
                    {
                        user.UnlockAccount();
                        result = "UserUnlocked";
                    }
                    else
                    {
                        result = "UserNotUnlocked";
                    }

                }
                catch (Exception ex)
                {
                    result = "UserNotUnlocked" + " - " + ex.Message.ToString();
                }
            }

            return result;
        }

        public string ChangePassword(string domain, string container, string admin, string adminPassword,
                string userMain, string oldPassword, string newPassword)
        {
            string result = "";

            if (string.IsNullOrWhiteSpace(domain))
                result = "Invalid Domain";
            if (string.IsNullOrWhiteSpace(container))
                result = "Invalid Container";
            if (string.IsNullOrWhiteSpace(admin))
                result = "Invalid Admin User";
            if (string.IsNullOrWhiteSpace(adminPassword))
                result = "Invalid Admin Password";
            if (string.IsNullOrWhiteSpace(userMain))
                result = "Invalid User";
            if (string.IsNullOrWhiteSpace(oldPassword))
                result = "Invalid OldPassword";
            if (string.IsNullOrWhiteSpace(newPassword))
                result = "Invalid NewPassword";

            if (string.IsNullOrWhiteSpace(result))
            {
                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain, container, admin, adminPassword);
                    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userMain);

                    if (user != null)
                    {
                        user.UnlockAccount();
                        user.ChangePassword(oldPassword, newPassword);

                        result = "PasswordChanged";
                    }
                    else
                    {
                        result = "PasswordNotChanged";
                    }

                }
                catch (Exception ex)
                {
                    result = "PasswordNotChanged" + " - " + ex.Message.ToString();
                }
            }

            return result;
        }

        public string ChangePassword(string domain, string container, string admin, string adminPassword,
              string userMain, string newPassword)
        {
            string result = "";

            if (string.IsNullOrWhiteSpace(domain))
                result = "Invalid Domain";
            if (string.IsNullOrWhiteSpace(container))
                result = "Invalid Container";
            if (string.IsNullOrWhiteSpace(admin))
                result = "Invalid Admin User";
            if (string.IsNullOrWhiteSpace(adminPassword))
                result = "Invalid Admin Password";
            if (string.IsNullOrWhiteSpace(userMain))
                result = "Invalid User";
            if (string.IsNullOrWhiteSpace(newPassword))
                result = "Invalid NewPassword";

            if (string.IsNullOrWhiteSpace(result))
            {
                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain, container, admin, adminPassword);
                    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userMain);

                    if (user != null)
                    {
                        user.UnlockAccount();
                        user.SetPassword(newPassword);
                       
                        result = "PasswordChanged";
                    }
                    else
                    {
                        result = "PasswordNotChanged";
                    }

                }
                catch (Exception ex)
                {
                    result = "PasswordNotChanged" + " - " + ex.Message.ToString();
                }
            }

            return result;
        }
    }
}
