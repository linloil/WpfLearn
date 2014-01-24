using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace WpfLearn.Server.NetworkNodes
{
    [DataContract]
    public class WorkstationDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string CoordinatorName { get; set; }

        [DataMember]
        public int RoleCount { get; set; }
    }
}
