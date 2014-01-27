using System;

using WpfLearn.Client.WcfService;


namespace WpfLearn.Client
{
    public class ServiceLocator
    {
        private static readonly DialogService _dialogService;
        private static readonly IService _service;


        static ServiceLocator()
        {
            _service = new ServiceClient();
            _dialogService = new DialogService();
        }


        public static IDialogService ResolveDialogService()
        {
            return _dialogService;
        }


        public static IService ResolveService()
        {
            return _service;
        }
    }
}
