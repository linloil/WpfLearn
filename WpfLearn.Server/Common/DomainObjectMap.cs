using System;
using System.Collections.Generic;
using System.Linq;

using FluentNHibernate.Mapping;


namespace WpfLearn.Server
{
    public class DomainObjectMap<T> : ClassMap<T>
        where T : DomainObject
    {
        public DomainObjectMap()
        {
            Id(x => x.Id);
        }
    }
}
