using Prism.Mvvm;
using BC = BCrypt.Net.BCrypt;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TimeKeeper.DataContext;
using TimeKeeper.Models;
using TimeKeeper.Views;
using TimeKeeper.Command;
using TimeKeeper.Services;

namespace TimeKeeper.ViewModels
{
    public class LoginViewModel : BindableBase, INotifyPropertyChanged
    {
        private readonly AppDbContext dbContext;

        private UserModel user;
        public UserModel User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        private DataServices _services;
        public ICommand LoginCommand { get; set; }
        public ICommand SignupCommand { get; set; }

        public ObservableCollection<UserModel> UserList { get; set; }
        public LoginViewModel(DataServices services)
        {
            dbContext = new AppDbContext();
            User = new UserModel();
            LoginCommand = new RelayCommand(Login, CanLogin);
            SignupCommand = new RelayCommand(Signup, CanSignup);
            UserList = new ObservableCollection<UserModel>(dbContext.UserTable);
            _services = services;
        }

        // For Login
        public UserModel FindUserByUsername(string Username)
        {
            return UserList.FirstOrDefault(user => user.Username.Equals(Username));
        }

        public bool CanLogin(object parameter)
        {
            return true;
        }
        private object currentPage;
        public object CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public void Login(object parameter)
        {
            var existingUser = FindUserByUsername(User.Username);
            if (existingUser != null && BC.EnhancedVerify(User.Password, existingUser.Password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.MainWindow.Close();
                _services.SetSharedData(existingUser);
            }
            else
            {
                MessageBox.Show("Username or Password did not match");
            }
        }

        // For Signup
        public bool CanSignup(object parameter)
        {
            return true;
        }

        public void Signup(object parameter)
        {
            Register signupView = new Register();
            signupView.Show();
            Application.Current.Windows.OfType<Login>().FirstOrDefault()?.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
