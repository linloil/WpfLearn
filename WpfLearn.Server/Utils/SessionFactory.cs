using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;

using NHibernate;
using NHibernate.Event;
using NHibernate.Event.Default;


namespace WpfLearn.Server
{
    internal static class SessionFactory
    {
        private const string ConnectionStringKey = "Main";
        private static readonly ISessionFactory _factory;


        static SessionFactory()
        {
            _factory = BuildSessionFactory();
        }


        public static ISession OpenSession()
        {
            return _factory.OpenSession();
        }


        private static ISessionFactory BuildSessionFactory()
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(x => x.FromConnectionStringWithKey(ConnectionStringKey)))
                .Mappings(m => m.FluentMappings
                    .AddFromAssembly(Assembly.GetExecutingAssembly())
                    .Conventions.Add(
                        Table.Is(x => "[dbo].[" + x.EntityType.Name + "]"),
                        PrimaryKey.Name.Is(_ => "ID"),
                        ForeignKey.EndsWith("ID"),
                        ConventionBuilder.Property.When(criteria => criteria.Expect(x => x.Nullable, Is.Not.Set), x => x.Not.Nullable()))
                    .Conventions.Add<OtherConversions>()
                .ExportTo(@"C:\Temp\")
                );

            configuration = configuration.ExposeConfiguration(x =>
            {
                x.EventListeners.PreUpdateEventListeners = new IPreUpdateEventListener[] { new MainEventListener() };
                x.EventListeners.PreInsertEventListeners = new IPreInsertEventListener[] { new MainEventListener() };
                x.EventListeners.SaveOrUpdateEventListeners = new ISaveOrUpdateEventListener[] { new DefaultSaveOrUpdateEventListener(), new MainEventListener() };
            });

            return configuration.BuildSessionFactory();
        }


        public static void Close()
        {
            if (_factory != null)
            {
                _factory.Close();
                _factory.Dispose();
            }
        }
    }



    public class OtherConversions : IHasManyConvention, IReferenceConvention, IIdConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.LazyLoad();
            instance.AsBag();
            instance.Cascade.SaveUpdate();
            instance.Inverse();
        }


        public void Apply(IManyToOneInstance instance)
        {
            instance.LazyLoad(Laziness.Proxy);
            instance.Cascade.None();
            instance.Not.Nullable();
        }


        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.Native();
        }
    }
}
