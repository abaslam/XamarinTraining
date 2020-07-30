using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinExplorer.Models
{
    public class EmployeeTogleableListModel : ToggleableListModelBase<EmployeeModel>
    {
        public EmployeeTogleableListModel(IEnumerable<EmployeeModel> list, bool isExpanded) : base(list, isExpanded)
        {
        }

        public string DepartmentName { get; set; }
    }
}
