using System;
using System.Collections.Generic;
using System.Linq;

using FluentNHibernate.Mapping;


namespace WpfLearn.Server.NetworkNodes
{
    public class RoleRegistrationMap : DomainObjectMap<RoleRegistration>
    {
        public RoleRegistrationMap()
        {
            Map(x => x.PermissionLevel);

            References(x => x.NetworkNode);
            References(x => x.Role);
        }
    }
}
