using System;

using FluentNHibernate.Mapping;


namespace WpfLearn.Server.Roles
{
    public class RoleMap : DomainObjectMap<Role>
    {
        public RoleMap()
        {
            Map(x => x.Name);
        }
    }
}
