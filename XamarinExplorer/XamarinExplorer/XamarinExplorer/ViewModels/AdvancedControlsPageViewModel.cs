using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using XamarinExplorer.Models;

namespace XamarinExplorer.ViewModels
{
    public class AdvancedControlsPageViewModel : ViewModelBase
    {
        private ObservableCollection<EmployeeModel> employees;
        private readonly IPageDialogService pageDialogService;

        public AdvancedControlsPageViewModel(IPageDialogService pageDialogService,INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Advanced Controls";

            this.EditEmployeeCommand = new DelegateCommand<EmployeeModel>(this.EditEmployee);
            this.DeleteEmployeeCommand = new DelegateCommand<EmployeeModel>(this.DeleteEmployee);
            this.pageDialogService = pageDialogService;
        }

        private void DeleteEmployee(EmployeeModel obj)
        {
            this.pageDialogService.DisplayAlertAsync("Delete", $"Are you sure want to delete {obj.Name}?", "Yes", "No");
        }

        private void EditEmployee(EmployeeModel obj)
        {
            this.pageDialogService.DisplayAlertAsync("Edit", $"Are you sure want to Edit {obj.Name}?", "Yes", "No");
        }

        public DelegateCommand<EmployeeModel> EditEmployeeCommand { get; set; }
        public DelegateCommand<EmployeeModel> DeleteEmployeeCommand { get; set; }

        public ObservableCollection<EmployeeModel> Employees
        {
            get => employees;
            set => this.SetProperty(ref this.employees, value);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            this.Employees = new ObservableCollection<EmployeeModel>
           {
               new EmployeeModel { Name="Ahamed Aslam", Email = "ahamedaslam.ab@gmail.com", PhoneNumber="9944425071"},
               new EmployeeModel { Name="Employee 1", Email = "emp1@gmail.com", PhoneNumber="9944425072"},
               new EmployeeModel { Name="Employee 2", Email = "emp2@gmail.com", PhoneNumber="9944425073"},
               new EmployeeModel { Name="Employee 3", Email = "emp3@gmail.com", PhoneNumber="9944425074"},
           };
        }
    }
}
