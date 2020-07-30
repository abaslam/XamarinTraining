namespace XamarinExplorer.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;
    using ImTools;
    using Prism.Commands;
    using Prism.Navigation;
    using XamarinExplorer.Models;

    public class GroupViewPageViewModel : ViewModelBase
    {
        private ObservableCollection<EmployeeListModel> employeeList;
        private ObservableCollection<EmployeeTogleableListModel> employeeToggleList;

        public GroupViewPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Group View";
            this.ToggleEmployeesCommand = new DelegateCommand<EmployeeTogleableListModel>(this.ToggleEmployees);
        }

        private void ToggleEmployees(EmployeeTogleableListModel obj)
        {
            obj.IsExpanded = !obj.IsExpanded;
        }

        public ObservableCollection<EmployeeListModel> EmployeeList
        {
            get => employeeList;
            set => this.SetProperty(ref this.employeeList, value);
        }

        public ObservableCollection<EmployeeTogleableListModel> EmployeeToggleList
        {
            get => employeeToggleList;
            set => this.SetProperty(ref employeeToggleList, value);
        }

        public DelegateCommand<EmployeeTogleableListModel> ToggleEmployeesCommand { get; set; }

        public override void Initialize(INavigationParameters parameters)
        {
            var finaceEmployees = new List<EmployeeModel>
            {
                new EmployeeModel{Name ="Finanace -1", Email="test1@test.com"},
                new EmployeeModel{Name ="Finanace -2", Email="test2@test.com"},
                new EmployeeModel{Name ="Finanace -3", Email="test3@test.com"},
            };

            var itEmployees = new List<EmployeeModel>
            {
                new EmployeeModel{Name ="IT -1", Email="test1@test.com"},
                new EmployeeModel{Name ="IT -2", Email="test2@test.com"},
                new EmployeeModel{Name ="IT -3", Email="test3@test.com"},
            };

            this.EmployeeList = new ObservableCollection<EmployeeListModel>
            {
                new EmployeeListModel(finaceEmployees){DepamentName = "Finance"},
                new EmployeeListModel(itEmployees){DepamentName="IT"}
            };

            this.EmployeeToggleList = new ObservableCollection<EmployeeTogleableListModel>
            {
                new EmployeeTogleableListModel(finaceEmployees, true){DepartmentName="Finance"},
                new EmployeeTogleableListModel(itEmployees, false){DepartmentName="IT"}
            };
        }
    }
}
