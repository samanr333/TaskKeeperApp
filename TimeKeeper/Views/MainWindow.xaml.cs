using System;
using System.Windows;
using System.Windows.Threading;

namespace TimeKeeper.Views
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private DateTime startTime;
        public MainWindow()
        {
            InitializeComponent();
            // Create a DispatcherTimer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Update every second
            timer.Tick += Timer_Tick;

            // Capture the start time when the window is loaded
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Capture the start time when the window is loaded
            startTime = DateTime.Now;

            // Start the timer
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Calculate the elapsed time
            TimeSpan elapsedTime = DateTime.Now - startTime;

            // Update the TextBlock with the elapsed time
            ElapsedTimeText.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }
    }
}
