using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Practices.Unity;

using WpfLearn.Client.WcfService;


namespace WpfLearn.Client
{
    public class ServiceLocator
    {
        private static readonly IUnityContainer _container;

        static ServiceLocator()
        {
            _container = new UnityContainer();

            _container.RegisterInstance(typeof(IService), new ServiceClient());
            _container.RegisterInstance(typeof(IDialogService), new DialogService());
        }


        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
