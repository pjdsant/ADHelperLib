# Product Documentation

# ADHelperLib - Library with methods to perform actions integrated with AD.

# ADHelper methods available:

# 1 - ValidateExAttributes(string domain, string container, string admin, string adminPassword, string userMain, string attributeOne, string attributeTwo, string respAttributeOne, string respAttributeTwo)

This method valide if two Acivite Directory attrubutes are valid.
You can use this to check if the secret anwsers are valid.

Parameters:

domain - The name of the domain or server for Domain context types, the machine name for Machine context types, or the name of the server and port hosting the ApplicationDirectory instance.

container - The container on the store to use as the root of the context. All queries are performed under this root, and all inserts are performed into this container.

admin - The username used to connect to the store. If the userName and password parameters are both null, the credentials of the current process are used. Otherwise, both userName and password must be non-null, and the credentials they specify are used to connect to the store.

adminPassword - The password used to connect to the store. If the userName and password parameters are both null, the credentials of the current process are used. Otherwise, both userName and password must be non-null, and the credentials they specify are used to connect to the store.

Return:

String IsValid/NotValid + (Exception message)


# 2 - UnlockUser(string domain, string container, string admin, string adminPassword, string userMain)

This method allow you to unlock a user password using a domain user admin.

Parameters:

domain - The name of the domain or server for Domain context types, the machine name for Machine context types, or the name of the server and port hosting the ApplicationDirectory instance.

container - The container on the store to use as the root of the context. All queries are performed under this root, and all inserts are performed into this container.

admin - The username used to connect to the store. If the userName and password parameters are both null, the credentials of the current process are used. Otherwise, both userName and password must be non-null, and the credentials they specify are used to connect to the store.

adminPassword - The password used to connect to the store. If the userName and password parameters are both null, the credentials of the current process are used. Otherwise, both userName and password must be non-null, and the credentials they specify are used to connect to the store.

userMain - The user to unlock password.


Return:

String UserUnlocked/UserNotUnlocked + (Exception message)


# 3 -  ChangePassword(string domain, string container, string admin, string adminPassword, string userMain, string oldPassword, string newPassword)

This method allows you to change a user's password using the current password.

Parameters:

domain - The name of the domain or server for Domain context types, the machine name for Machine context types, or the name of the server and port hosting the ApplicationDirectory instance.

container - The container on the store to use as the root of the context. All queries are performed under this root, and all inserts are performed into this container.

admin - The username used to connect to the store. If the userName and password parameters are both null, the credentials of the current process are used. Otherwise, both userName and password must be non-null, and the credentials they specify are used to connect to the store.

adminPassword - The password used to connect to the store. If the userName and password parameters are both null, the credentials of the current process are used. Otherwise, both userName and password must be non-null, and the credentials they specify are used to connect to the store.

userMain - The user to unlock password.

oldPassword - Current Password.

newPassword - New password according to Active Directory policies. 


Return:

String PasswordChanged/PasswordNotChanged + (Exception message)


# 4 - ChangePassword(string domain, string container, string admin, string adminPassword, string userMain, string newPassword)

This method allows you to change a user's password using a new password without current password.

Parameters:

domain - The name of the domain or server for Domain context types, the machine name for Machine context types, or the name of the server and port hosting the ApplicationDirectory instance.

container - The container on the store to use as the root of the context. All queries are performed under this root, and all inserts are performed into this container.

admin - The username used to connect to the store. If the userName and password parameters are both null, the credentials of the current process are used. Otherwise, both userName and password must be non-null, and the credentials they specify are used to connect to the store.

adminPassword - The password used to connect to the store. If the userName and password parameters are both null, the credentials of the current process are used. Otherwise, both userName and password must be non-null, and the credentials they specify are used to connect to the store.

userMain - The user to unlock password.

newPassword - New password according to Active Directory policies. 


Return:

String PasswordChanged/PasswordNotChanged + (Exception message)



# Sample Code

```
ADHelper adhelper = new ADHelper();

string domain = AppSettings.Domain;
string container = AppSettings.Container;
string admin = AppSettings.Admin;
string adminPassword = AppSettings.AdminPassword;
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
```

[Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.directoryservices.accountmanagement.principalcontext.-ctor?view=dotnet-plat-ext-3.1#System_DirectoryServices_AccountManagement_PrincipalContext__ctor_System_DirectoryServices_AccountManagement_ContextType_)



