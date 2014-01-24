using System;
using System.Collections.Generic;
using System.Linq;

using FluentNHibernate.Mapping;


namespace WpfLearn.Server.NetworkNodes
{
    public class WorkstationMap : SubclassMap<Workstation>
    {
        public WorkstationMap()
        {
            Table("[dbo].[Workstation]");
            KeyColumn("ID");

            References(x => x.Coordinator);
        }
    }
}
