using System;
using System.Collections.ObjectModel;
using System.Threading;
using Prism.Commands;
using Prism.Navigation;
using XamarinExplorer.CommandParameter;
using XamarinExplorer.Models;

namespace XamarinExplorer.ViewModels
{
    public class BasicControlsPageViewModel : ViewModelBase
    {
        private RegisterModel register;
        //private ObservableCollection<string> states;

        private ObservableCollection<SelectListItemModel> states;

        public BasicControlsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Basic Controls";
            this.PerformRegisterCommand = new DelegateCommand(this.PerformRegister, () => this.Register.AcceptToTerm);
            this.AccepToTermCommand = new DelegateCommand(() => this.PerformRegisterCommand.RaiseCanExecuteChanged());
            this.GenderChangedCommand = new DelegateCommand<GenderCommandParameter>(this.GenderChanged);
            this.Register = new RegisterModel();
            //this.States = new ObservableCollection<string>
            //{
            //    "Tamil Nadu",
            //    "Andhra",
            //    "Kerala"
            //};

            this.States = new ObservableCollection<SelectListItemModel>
            {
                new SelectListItemModel{ Id = 1001, Text ="Tamil Nadu"},
                new SelectListItemModel{Id= 1002, Text="Keral"}
            };
        }

        private void GenderChanged(GenderCommandParameter obj)
        {
            this.Register.Gender = obj.Gender;
        }

        public DelegateCommand PerformRegisterCommand { get; set; }
        public DelegateCommand AccepToTermCommand { get; set; }
        public DelegateCommand<GenderCommandParameter> GenderChangedCommand { get; set; }

        public GenderCommandParameter Male { get; set; } = new GenderCommandParameter { Gender = GenderType.Male };
        public GenderCommandParameter Female { get; set; } = new GenderCommandParameter { Gender = GenderType.Female };

        public RegisterModel Register
        {
            get => register;
            set => this.SetProperty(ref this.register, value);
        }


        //public ObservableCollection<string> States
        //{
        //    get => states;
        //    set => this.SetProperty(ref this.states, value);
        //}

        public ObservableCollection<SelectListItemModel> States
        {
            get => states;
            set => this.SetProperty(ref this.states, value);
        }

        private void PerformRegister()
        {
            var obj = this.Register;
        }
    }
}
