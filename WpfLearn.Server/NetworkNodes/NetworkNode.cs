using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using WpfLearn.Server.Roles;


namespace WpfLearn.Server.NetworkNodes
{
    [DataContract]
    public class NetworkNode : DomainObject
    {
        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        private IList<RoleRegistration> _roleRegistrations;
        public virtual IList<RoleRegistration> RoleRegistrations
        {
            get { return _roleRegistrations; }
        }


        public NetworkNode()
        {
            _roleRegistrations = new List<RoleRegistration>();
        }


        public virtual void AddRoleRegistration(Role role, char permissionLevel)
        {
            RoleRegistration registration = new RoleRegistration
            {
                NetworkNode = this,
                PermissionLevel = permissionLevel,
                Role = role
            };

            _roleRegistrations.Add(registration);
        }
    }
}
