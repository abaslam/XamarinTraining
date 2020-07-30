namespace XamarinExplorer.Models
{
    using System.Collections.Generic;

    public class EmployeeListModel : ListModelBase<EmployeeModel>
    {
        public EmployeeListModel(IEnumerable<EmployeeModel> list) : base(list)
        {
        }

        public string DepamentName { get; set; }
    }
}
