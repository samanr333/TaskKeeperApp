using Prism.Mvvm;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using TimeKeeper.Command;
using TimeKeeper.DataContext;
using TimeKeeper.Models;
using TimeKeeper.Services;
using TimeKeeper.Views;

namespace TimeKeeper.ViewModels
{
    public class MainWindowViewModel : BindableBase, INotifyPropertyChanged
    {
        private DataServices _services;
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public AppDbContext dbContext;
        public TaskViewModel TaskViewModel { get; set; }

        private UserModel _user;
        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public ICommand LogoutCommand { get; set; }


        private DateTime loginTime;
        private double loggedInHours;
        private DispatcherTimer timer;
        public DateTime LoginTime
        {
            get { return loginTime; }
            set
            {
                loginTime = value;
                OnPropertyChanged("LoginTime");
            }
        }

        public double LoggedInHours
        {
            get { return loggedInHours; }
            set
            {
                loggedInHours = value;
                OnPropertyChanged("LoggedInHours");
            }
        }
        public MainWindowViewModel(DataServices services)
        {
            _services = services;
            dbContext = new AppDbContext();
            User = new UserModel();
            User = _services.GetSharedData();
            LogoutCommand = new RelayCommand(Logout, CanLogout);

            loginTime = DateTime.Now;
            loggedInHours = 0;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Update every second
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            CalculateLoggedInHours();
        }

        private void CalculateLoggedInHours()
        {
            // Calculate the elapsed time since login
            var elapsedTime = DateTime.Now - LoginTime;

            // Update the LoggedInHours property with the calculated hours
            LoggedInHours = elapsedTime.TotalHours;
        }
        public void Logout(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Login login = new Login();
                login.Show();
                Application.Current.Windows.OfType<MainWindow>().FirstOrDefault()?.Close();
            }
        }
        public bool CanLogout(object parameter)
        {
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
