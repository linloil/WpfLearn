using System;
using System.Collections.Generic;
using System.Windows.Input;

using WpfLearn.Server.NetworkNodes;


namespace WpfLearn.Client.NetworkNodes
{
    public class WorkstationListViewModel : ViewModel
    {
        public ICommand AddWorstationCommand { get; private set; }
        public ICommand EditWorstationCommand { get; private set; }
        public ICommand DeleteWorstationCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public IEnumerable<WorkstationDto> Workstations { get; private set; }
        

        public override string Caption
        {
            get { return "Клиенты"; }
        }


        public WorkstationListViewModel()
        {
            Refresh();

            AddWorstationCommand = new Command(AddWorstation);
            EditWorstationCommand = new Command<WorkstationDto>(dto => dto != null, EditWorkstation);
            DeleteWorstationCommand = new Command<WorkstationDto>(dto => dto != null, DeleteWorkstation);
            RefreshCommand = new Command(_ => Refresh());
        }


        private void Refresh()
        {
            Workstations = _service.GetWorkstationDtoList(0, 50);
            Notify(() => Workstations);
        }


        private void DeleteWorkstation(WorkstationDto workstationDto)
        {
            _service.DeleteWorkstation(workstationDto.Id);
            Refresh();
        }


        private void EditWorkstation(WorkstationDto workstationDto)
        {
            Workstation workstation = _service.GetWorkstation(workstationDto.Id);
            _dialogService.ShowDialog(new WorkstationViewModel(workstation));
            Refresh();
        }


        private void AddWorstation(object parameter)
        {
            _dialogService.ShowDialog(new WorkstationViewModel(new Workstation()));
            Refresh();
        }
    }
}
