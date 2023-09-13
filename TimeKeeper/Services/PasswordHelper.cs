using System.Windows.Controls;
using System.Windows;

namespace TimeKeeper.Services
{
    public static class PasswordBoxAssistant
    {
        public static readonly DependencyProperty BoundPassword =
             DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxAssistant), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));
        private static bool _IsUpdating;
        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (_IsUpdating) return;
            if (!(d is PasswordBox passwordBox))
                return;
            passwordBox.PasswordChanged -= HandlePasswordChanged;
            passwordBox.Password = (string)e.NewValue;
            passwordBox.PasswordChanged += HandlePasswordChanged;
        }

        private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!(sender is PasswordBox passwordBox)) return;
            _IsUpdating = true;
            SetBoundPassword(passwordBox, passwordBox.Password);
            _IsUpdating = false;
        }


        public static string GetBoundPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(BoundPassword);
        }

        public static void SetBoundPassword(DependencyObject dp, string value)
        {
            dp.SetValue(BoundPassword, value);
        }
    }
}

