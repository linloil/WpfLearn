using System;


namespace WpfLearn.Client
{
    public class DialogService : IDialogService
    {
        public bool? ShowDialog(ViewModel viewModel)
        {
            CustomWindow window = new CustomWindow(viewModel);
            return window.ShowDialog();
        }
    }



    public interface IDialogService
    {
        bool? ShowDialog(ViewModel viewModel);
    }
}
