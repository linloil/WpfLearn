using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using NHibernate;


namespace WpfLearn.Server
{
    [DataContract]
    public class DomainObject
    {
        [DataMember]
        public virtual int Id { get; protected internal set; }

        [DataMember]
        public virtual byte[] ChangeStamp { get; set; }


        public override bool Equals(object obj)
        {
            var compareTo = obj as DomainObject;

            if (((object)compareTo) == null)
                return false;

            if (GetRealType() != compareTo.GetRealType())
                return false;

            if (!IsTransient() && !compareTo.IsTransient() && Id == compareTo.Id)
                return true;

            return ReferenceEquals(this, compareTo);
        }


        public static bool operator ==(DomainObject a, DomainObject b)
        {
            if (((object)a) == null && ((object)b) == null)
                return true;

            if (((object)a) == null || ((object)b) == null)
                return false;

            if (ReferenceEquals(a, b))
                return true;

            return a.Equals(b);
        }


        public static bool operator !=(DomainObject a, DomainObject b)
        {
            return !(a == b);
        }


        public override int GetHashCode()
        {
            return (GetRealType().ToString() + Id).GetHashCode();
        }


        public virtual bool IsTransient()
        {
            return Id == 0;
        }


        public virtual Type GetRealType()
        {
            return NHibernateUtil.GetClass(this);
        }
    }
}
