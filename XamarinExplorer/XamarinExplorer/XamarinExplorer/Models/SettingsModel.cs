using Xamarin.Forms;

namespace XamarinExplorer.Models
{
    public class SettingsModel : ModelBase
    {
        private bool showWelcomeScreen;
        private bool sendWeeklyEmail;

        public bool ShowWelcomeScreen
        {
            get => showWelcomeScreen;
            set => this.SetProperty(ref this.showWelcomeScreen, value, () => this.RaisePropertyChanged(nameof(LabelColor)));
        }

        public bool SendWeeklyEmail
        {
            get => sendWeeklyEmail;
            set => this.SetProperty(ref this.sendWeeklyEmail, value);
        }

        public Color LabelColor
        {
            get
            {
                return this.ShowWelcomeScreen ? Color.Red : Color.Green;
            }
        }
    }
}
