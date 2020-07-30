using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinExplorer.Models
{
    public class ToggleableListModelBase<T> : ListModelBase<T>
    {
        private readonly IEnumerable<T> list;
        private bool isExpanded;

        public ToggleableListModelBase(IEnumerable<T> list, bool isExpanded) : base(new List<T>())
        {
            this.list = list;
            this.IsExpanded = isExpanded;
        }

        public bool IsExpanded
        {
            get => isExpanded;
            set
            {
                this.isExpanded = value;
                if (this.isExpanded)
                {
                    foreach (var item in this.list)
                    {
                        this.Add(item);
                    }
                }
                else
                {
                    this.Clear();
                }
            }
        }
    }
}
