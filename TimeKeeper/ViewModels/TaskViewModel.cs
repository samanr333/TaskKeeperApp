using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TimeKeeper.Models;
using TimeKeeper.DataContext;
using TimeKeeper.Services;
using Prism.Events;
using TimeKeeper.Command;
using TimeKeeper.Views;

namespace TimeKeeper.ViewModels
{
    public class TaskViewModel : BindableBase, INotifyPropertyChanged
    {
        private DataServices _services;
        private AppDbContext dbContext;
        private TaskModel _task;
        private UserModel _user;
        private ObservableCollection<TaskModel> _filteredTask;

        public TaskModel Task
        {
            get { return _task; }
            set
            {
                _task = value;
                OnPropertyChanged(nameof(Task));
            }
        }

        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public DelegateCommand RemoveCommand { get; set; }
        public ICommand ViewAddTaskModalCommand { get; set; }
        public ICommand ViewUpdateTaskModalCommand { get; set; }

        private string _searchKeyword;
        public string SearchKeyword
        {
            get { return _searchKeyword; }
            set
            {
                if (_searchKeyword != value)
                {
                    _searchKeyword = value;
                    OnPropertyChanged(nameof(SearchKeyword));
                    UpdateFilteredTasks();
                }
            }
        }

        public ObservableCollection<TaskModel> FilteredTask
        {
            get
            {
                return _filteredTask;
            }
            set
            {
                if (_filteredTask != value)
                {
                    _filteredTask = value;
                    OnPropertyChanged(nameof(FilteredTask));
                }
            }
        }

        private IEventAggregator _aggregator;

        public TaskViewModel(DataServices services, IEventAggregator eventAggregator)
        {
            _aggregator = eventAggregator;
            _services = services;
            User = new UserModel();
            User = _services.GetSharedData();
            Task = new TaskModel();
            RemoveCommand = new DelegateCommand(Remove);
            dbContext = new AppDbContext();
            FilteredTask = new ObservableCollection<TaskModel>(dbContext.TaskTable.Where(t => t.UserId == User.UserId));
            ViewAddTaskModalCommand = new RelayCommand(ViewAddTaskModal, Can);
            ViewUpdateTaskModalCommand = new RelayCommand(ViewUpdateTaskkModal, Can);

            // Subscribe to the event for adding/updating tasks
            _aggregator.GetEvent<PubSubEvent<TaskModel>>().Subscribe(AddUpdateTable);
        }

        private void AddUpdateTable(TaskModel model)
        {
            FilteredTask.Add(model);
        }

        public void ViewAddTaskModal(object parameter)
        {
            AddTaskModal addTaskModal = new AddTaskModal();
            addTaskModal.Show();
        }

        public void ViewUpdateTaskkModal(object parameter)
        {
            if (SelectedTask != null)
            {
                _services.SetSharedTaskData(SelectedTask);
                UpdateTaskModal updateTaskModal = new UpdateTaskModal();
                updateTaskModal.Show();
            }
            else
            {
                MessageBox.Show("Please select a task");
            }
        }

        public bool Can(object parameter)
        {
            return true;
        }

        // Delete task
        public void Remove()
        {
            if (SelectedTask != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to remove the task?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    dbContext.TaskTable.Remove(SelectedTask);
                    dbContext.SaveChanges();
                    // Remove the task from the FilteredTask collection
                    FilteredTask.Remove(SelectedTask);
                    SelectedTask = null;
                    _aggregator.GetEvent<PubSubEvent<TaskModel>>().Publish(new TaskModel());
                }
            }
            else
            {
                MessageBox.Show("Please select a Task to remove");
            }
        }

        // SelectedTask property
        private TaskModel _selectedTask;
        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                SetProperty(ref _selectedTask, value);
            }
        }

        // UpdateFilteredTasks method
        private void UpdateFilteredTasks()
        {
            if (string.IsNullOrWhiteSpace(SearchKeyword))
            {
                FilteredTask = new ObservableCollection<TaskModel>(dbContext.TaskTable.Where(t => t.UserId == User.UserId));
            }
            else
            {
                string text = SearchKeyword.Trim().ToLower();
                FilteredTask = new ObservableCollection<TaskModel>(FilteredTask
                    .Where(t => t.UserId == User.UserId && t.TaskName.ToLower().Contains(text)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
