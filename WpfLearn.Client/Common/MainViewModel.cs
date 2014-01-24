using System;
using System.Collections.Generic;
using System.Linq;

using WpfLearn.Client.NetworkNodes;
using WpfLearn.Client.WcfService;
using WpfLearn.Server.NetworkNodes;


namespace WpfLearn.Client
{
    public class MainViewModel
    {
        public List<ViewModel> Items { get; private set; }


        public MainViewModel()
        {
            Items = new List<ViewModel>
            {
                new WorkstationListViewModel()
            };
        }
    }
}
