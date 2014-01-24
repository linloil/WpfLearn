using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

using WpfLearn.Client.NetworkNodes;
using WpfLearn.Client.WcfService;


namespace WpfLearn.Client
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected static readonly IService _service = ServiceLocator.Resolve<IService>();
        protected static readonly IDialogService _dialogService = ServiceLocator.Resolve<IDialogService>();
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual string Caption
        {
            get { return string.Empty; }
        }

        private bool? _dialogResult;
        public bool? DialogResult
        {
            get
            {
                return _dialogResult;
            }
            protected set
            {
                _dialogResult = value;
                Notify();
            }
        }


        protected void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        protected void Notify<T>(Expression<Func<T>> propertyExpression)
        {
            MemberExpression expression = propertyExpression.Body as MemberExpression;

            if (expression == null)
                throw new ArgumentException(propertyExpression.Body.ToString());

            Notify(expression.Member.Name);
        }
    }
}
