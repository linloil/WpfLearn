using System.Linq;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

using WpfLearn.Server.Roles;


namespace WpfLearn.Server.NetworkNodes
{
    [DataContract]
    public class RoleRegistration : DomainObject
    {
        [DataMember]
        public virtual char PermissionLevel { get; set; }

        public virtual NetworkNode NetworkNode { get; set; }
        [DataMember]
        public virtual Role Role { get; set; }
    }
}
