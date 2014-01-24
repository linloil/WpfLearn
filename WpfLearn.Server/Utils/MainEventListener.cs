using System;
using System.Collections.Generic;
using System.Linq;

using NHibernate;
using NHibernate.Event;


namespace WpfLearn.Server
{
    public class MainEventListener : EmptyInterceptor, ISaveOrUpdateEventListener, IPreUpdateEventListener, IPreInsertEventListener
    {
        public void OnSaveOrUpdate(SaveOrUpdateEvent ev)
        {
            //DomainObject domainObject = ev.Entity as DomainObject;

            //if (domainObject == null || !domainObject.ReindexRequired)
            //    return;

            //IocContainer.Current.TasksBatch.AddReindexTask(domainObject);
        }


        public bool OnPreUpdate(PreUpdateEvent ev)
        {
            //AuditableObject auditableObject = ev.Entity as AuditableObject;

            //if (auditableObject == null)
            //    return false;

            //DateTime now = DateTime.Now;

            //auditableObject.SetDateUpdated(now);
            //SetField(ev.Persister, ev.State, "DateUpdated", now);

            return false;
        }


        public bool OnPreInsert(PreInsertEvent ev)
        {
            //AuditableObject auditableObject = ev.Entity as AuditableObject;

            //if (auditableObject == null)
            //    return false;

            //DateTime now = DateTime.Now;

            //auditableObject.SetDateCreated(now);
            //auditableObject.SetDateUpdated(now);
            //SetField(ev.Persister, ev.State, "DateCreated", now);
            //SetField(ev.Persister, ev.State, "DateUpdated", now);

            return false;
        }


        //private void SetField(IEntityPersister persister, object[] state, string propertyName, DateTime value)
        //{
        //    int index = Array.IndexOf(persister.PropertyNames, propertyName);

        //    if (index == -1)
        //        return;

        //    state[index] = value;
        //}
    }
}
