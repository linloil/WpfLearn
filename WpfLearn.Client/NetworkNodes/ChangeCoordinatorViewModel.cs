using System;
using System.Collections.Generic;
using System.Windows.Input;

using WpfLearn.Server.NetworkNodes;


namespace WpfLearn.Client.NetworkNodes
{
    public class ChangeCoordinatorViewModel : ViewModel
    {
        public IList<Coordinator> Coordinators { get; private set; }
        public Coordinator SelectedCoordinator { get; set; }
        public ICommand SelectCoordinatorCommand { get; private set; }


        public ChangeCoordinatorViewModel()
        {
            Coordinators = _service.GetCoordinatorList(0, 50);
            SelectCoordinatorCommand = new Command<Coordinator>(c => c != null, _ => DialogResult = true);
        }
    }
}
