using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using TimeKeeper.DataContext;
using TimeKeeper.Models;
using TimeKeeper.Services;
using TimeKeeper.Views;

namespace TimeKeeper.ViewModels
{
    public class AddTaskModalViewModel : BindableBase, INotifyPropertyChanged
	{
        private DataServices _services;
        private UserModel _user;
        public AppDbContext dbContext;
        private TaskModel _task;
        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public TaskModel Task
        {
            get { return _task; }
            set
            {
                _task = value;
                OnPropertyChanged(nameof(Task));
            }
        }
        public ObservableCollection<TaskModel> TaskList
        {
            get; set;
        }
        private IEventAggregator _eventAggregator;
        public DelegateCommand AddCommand { get; set; }
        public AddTaskModalViewModel(DataServices services, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Task = new TaskModel();
            _services = services;
            User = new UserModel();
            User = _services.GetSharedData();
            dbContext = new AppDbContext();
            TaskList = new ObservableCollection<TaskModel>(dbContext.TaskTable);
            AddCommand = new DelegateCommand(Add);
        }
        public void Add()
        {
            if (!string.IsNullOrWhiteSpace(Task.TaskName) && !string.IsNullOrWhiteSpace(Task.Description))
            {
                TaskModel tasks = new TaskModel { UserId = User.UserId, TaskName = Task.TaskName, Description = Task.Description, Status = "Pending", TaskCreateDate = DateTime.Now, TaskUpdatedDate = DateTime.Now };
                dbContext.TaskTable.Add(tasks);
                dbContext.SaveChanges();
                _eventAggregator.GetEvent<PubSubEvent<TaskModel>>().Publish(tasks);
                MessageBox.Show("Task added successfully");
                Application.Current.Windows.OfType<AddTaskModal>().FirstOrDefault()?.Close();
            }
            else
            {
                MessageBox.Show("Please enter all fields");
            }
        }
        public bool CanAdd(object parameter)
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
