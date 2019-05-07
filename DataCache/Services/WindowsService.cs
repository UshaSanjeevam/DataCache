using DataCache.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;

namespace DataCache.Services
{
    public class WindowsService:IWindows
    {
    
        public bool GetWindowsData(string username, string password)
        {
            Domain_Authentication windowsValidate = new Domain_Authentication(username, password, "logistics");
            bool check = windowsValidate.IsValid();
            return check;
        }
        public class Domain_Authentication
        {
            public credentails Credentials;
            public string Domain;

            public Domain_Authentication(string Username, string Password, string SDomain)
            {
                Credentials.UserName = Username;
                Credentials.Password = Password;
                Domain = SDomain;
            }

            public bool IsValid()
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, Domain))
                {
                    return pc.ValidateCredentials(Credentials.UserName, Credentials.Password);
                }
            }
        }
    }
}
