using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IgoFirst.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected virtual void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            var h = PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
