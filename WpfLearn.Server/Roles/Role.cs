using System;
using System.Runtime.Serialization;


namespace WpfLearn.Server.Roles
{
    [DataContract]
    public class Role : DomainObject
    {
        [DataMember]
        public virtual string Name { get; set; }
    }
}
