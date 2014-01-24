using System;
using System.Runtime.Serialization;


namespace WpfLearn.Server.NetworkNodes
{
    [DataContract]
    public class Workstation : NetworkNode
    {
        [DataMember]
        public virtual Coordinator Coordinator { get; set; }
    }
}
