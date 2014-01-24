using System;
using System.Collections.Generic;
using System.Linq;

using FluentNHibernate.Mapping;


namespace WpfLearn.Server.NetworkNodes
{
    public class CoordinatorMap : SubclassMap<Coordinator>
    {
        public CoordinatorMap()
        {
            Table("[dbo].[Coordinator]");
            KeyColumn("ID");
        }
    }
}
