using Prism.Mvvm;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TimeKeeper.Command;
using TimeKeeper.DataContext;
using TimeKeeper.Models;
using TimeKeeper.Views;

namespace TimeKeeper.ViewModels
{
    public class MainWindowViewModel : BindableBase, INotifyPropertyChanged
    {
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
        public MainWindowViewModel()
        {
            dbContext = new AppDbContext();
            User = new UserModel();
            LogoutCommand = new RelayCommand(Logout, CanLogout);
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
