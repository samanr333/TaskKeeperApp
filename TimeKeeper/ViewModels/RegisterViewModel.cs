using Prism.Mvvm;
using BC = BCrypt.Net.BCrypt;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using TimeKeeper.Command;
using TimeKeeper.DataContext;
using TimeKeeper.Models;
using TimeKeeper.Views;

namespace TimeKeeper.ViewModels
{
    public class RegisterViewModel : BindableBase, INotifyPropertyChanged
    {
        public string? Error => null;
        public AppDbContext dbContext;
        public UserModel User { get; set; }
        public ObservableCollection<UserModel> UserList { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand SignupCommand { get; set; }
        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }
        public RegisterViewModel()
        {
            User = new UserModel();
            dbContext = new AppDbContext();
            LoginCommand = new RelayCommand(Login, CanLogin);
            SignupCommand = new RelayCommand(Signup, CanSignup);
            UserList = new ObservableCollection<UserModel>(dbContext.UserTable);
        }
        // For Login
        public bool CanLogin(object parameter)
        {
            return true;
        }
        public void Login(object parameter)
        {
            Login login = new Login();
            Application.Current.Windows.OfType<Register>().FirstOrDefault()?.Close();
            login.Show();
        }
        // For Signup
        // Find Username
        public UserModel FindUserByUsername(string Username)
        {
            return UserList.FirstOrDefault<UserModel>(user => user.Username.Equals(Username));
        }
        public UserModel FindUserByEmail(string Email)
        {
            return UserList.FirstOrDefault<UserModel>(user => user.Email.Equals(Email));
        }
        public bool CanSignup(object parameter)
        {
            return true;
        }
        public void Signup(object parameter)
        {
            if (this["Name"] != null || this["Username"] != null || this["Email"] != null || this["Password"] != null)
            {
                MessageBox.Show("Please enter all fields correctly");
            }

            else if (Error == null)
            {
                UserModel users = new UserModel { Name = User.Name, Username = User.Username.ToLower(), Email = User.Email, Password = User.Password };
                users.Password = BC.EnhancedHashPassword(User.Password);
                var existingUsername = FindUserByUsername(User.Username);
                var existingEmail = FindUserByEmail(User.Email);
                
                if (existingUsername != null && existingUsername.Username.Equals(User.Username))
                {
                    MessageBox.Show("Username already exists");
                }
                else if (existingEmail != null && existingEmail.Email.Equals(User.Email))
                {
                    MessageBox.Show("Email already exists");
                }
                else if (User.Password != ConfirmPassword)
                {
                    MessageBox.Show("Password did not match");
                }
                else
                {
                    dbContext.UserTable.Add(users);
                    dbContext.SaveChanges();
                    MessageBox.Show("Registration Successful");
                    Login login = new Login();
                    login.Show();
                    Application.Current.Windows.OfType<Register>().FirstOrDefault()?.Close();
                    UserList.Clear();
                }
            }
        }

        // Validation
        public string this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }
        private string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Name":
                    error = ValidateName();
                    break;
                case "Email":
                    error = ValidateEmail();
                    break;

                case "Password":
                    error = ValidatePassword();
                    break;
                case "Username":
                    error = ValidateUsername();
                    break;
            }
            return error;
        }
        private string? ValidatePassword()
        {
            // Regex Password Validation
            Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,16}$");
            if (string.IsNullOrWhiteSpace(User.Password))
            {
                return "Password cannot be empty";
            }
            else if (!string.IsNullOrWhiteSpace(User.Password))
            {
                bool isPassMatch = Regex.IsMatch(User.Password, $"{passwordRegex}");
                if (!isPassMatch)
                {
                    return "Invalid Password";
                }
            }
            return null;
        }

        private string? ValidateEmail()
        {
            // Regex Email Validation
            Regex emailRegex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
                                        RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if (string.IsNullOrWhiteSpace(User.Email))
            {
                return "Student email cannot be empty";
            }
            else if (!string.IsNullOrWhiteSpace(User.Email))
            {
                bool isEmailMatch = Regex.IsMatch(User.Email, $"{emailRegex}");
                if (!isEmailMatch)
                {
                    return "Invalid Email";
                }
            }
            return null;
        }


        private string? ValidateName()
        {
            if (string.IsNullOrWhiteSpace(User.Name))
            {
                return "Student name cannot be empty";
            }
            return null;
        }

        private string? ValidateUsername()
        {
            if (string.IsNullOrWhiteSpace(User.Username))
            {
                return "Student name cannot be empty";
            }
            return null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
