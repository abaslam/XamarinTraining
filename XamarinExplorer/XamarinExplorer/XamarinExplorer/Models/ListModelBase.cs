using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XamarinExplorer.Models
{
    public class ListModelBase<T> : ObservableCollection<T>
    {
        public ListModelBase(IEnumerable<T> list) : base(list)
        {
        }

        public ObservableCollection<T> List => this;
    }
}
