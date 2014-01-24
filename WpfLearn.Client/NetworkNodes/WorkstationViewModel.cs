using System;
using System.Linq.Expressions;
using System.Windows.Input;

using WpfLearn.Server.NetworkNodes;


namespace WpfLearn.Client.NetworkNodes
{
    public class WorkstationViewModel : ViewModel
    {
        private readonly Workstation workstation;

        public ICommand ChangeCoordinatorCommand { get; private set; }
        public ICommand OkCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public string Name
        {
            get { return workstation.Name; }
            set { workstation.Name = value; }
        }

        public string CoordinatorName
        {
            get
            {
                if (workstation.Coordinator == null)
                    return string.Empty;

                return workstation.Coordinator.Name;
            }
        }


        public WorkstationViewModel(Workstation workstation)
        {
            this.workstation = workstation;

            ChangeCoordinatorCommand = new Command(ChangeCoordinator);
            OkCommand = new Command(IsValid, SaveWorkstation);
            CancelCommand = new Command(_ => DialogResult = false);
        }


        private void SaveWorkstation(object o)
        {
            _service.SaveWorkstation(workstation);
            DialogResult = true;
        }


        private bool IsValid(object o)
        {
            return !string.IsNullOrWhiteSpace(workstation.Name) && workstation.Coordinator != null;
        }


        private void ChangeCoordinator(object parameter)
        {
            ChangeCoordinatorViewModel viewModel = new ChangeCoordinatorViewModel();

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                workstation.Coordinator = viewModel.SelectedCoordinator;
                Notify(() => CoordinatorName);
            }
        }
    }
}
