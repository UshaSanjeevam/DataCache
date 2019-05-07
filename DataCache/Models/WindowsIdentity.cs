using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataCache.Models
{
    public class WindowsIdentity
    {
        public string DomainName { get; set; }
        public string Authenticated { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
