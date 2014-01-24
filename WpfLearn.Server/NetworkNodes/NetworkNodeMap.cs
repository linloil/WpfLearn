using System;
using System.Collections.Generic;
using System.Linq;

using FluentNHibernate;
using FluentNHibernate.Mapping;


namespace WpfLearn.Server.NetworkNodes
{
    public class NetworkNodeMap : DomainObjectMap<NetworkNode>
    {
        public NetworkNodeMap()
        {
            Map(x => x.Name);

            Version(x => x.ChangeStamp).CustomType<byte[]>().Generated.Always();

            HasMany<RoleRegistration>(Reveal.Member<NetworkNode>("RoleRegistrations"))
                .Access.CamelCaseField(Prefix.Underscore)
                .Cascade.AllDeleteOrphan();
        }
    }
}
