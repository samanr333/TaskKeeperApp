using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using TimeKeeper.Models;
using TimeKeeper.DataContext;
using TimeKeeper.Command;
using TimeKeeper.Views;
using System;
using TimeKeeper.Services;
using Prism.Events;
using Prism.Commands;

namespace TimeKeeper.ViewModels
{
    public class TaskViewModel : BindableBase, INotifyPropertyChanged
    {
        private DataServices _services;
        public AppDbContext dbContext;
        private TaskModel _task;
        public TaskModel Task
        {
            get { return _task; }
            set
            {
                _task = value;
                OnPropertyChanged(nameof(Task));
            }
        }
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

        public DelegateCommand RemoveCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand ViewTaskModalCommand { get; set; }
        private string _searchTask;
        public string SearchTask
        {
            get { return _searchTask; }
            set
            {
                _searchTask = value;
                OnPropertyChanged(nameof(SearchTask));
                GetTask();
            }
        }

        private TaskModel _selectedTask;
        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                SetProperty(ref _selectedTask, value);
            }
        }
        private ObservableCollection<TaskModel> _taskList;
        public ObservableCollection<TaskModel> TaskList {
            get
            {
                return _taskList;
            }
            set
            {
                if (_taskList != value)
                {
                    _taskList = value;
                    RaisePropertyChanged(nameof(TaskList));
                }
                
                //SetProperty(ref _taskList, value);
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
            dbContext = new AppDbContext();
            RemoveCommand = new DelegateCommand(Remove);
            UpdateCommand = new RelayCommand(Update, Can);
            ViewTaskModalCommand = new RelayCommand(ViewTaskModal, Can);
            UpdateTaskList();
            _aggregator.GetEvent<PubSubEvent<TaskModel>>().Subscribe(UpdateTable);
         
        }

        private void UpdateTable(TaskModel model)
        {
            TaskList.Add(model);
        }
        public void UpdateTaskList()
        {
            GetTask();
        }
        private void GetTask()
        {
            if (String.IsNullOrWhiteSpace(SearchTask))
            {
                TaskList = new ObservableCollection<TaskModel>(dbContext.TaskTable.Where(t => t.UserId == User.UserId));
            }
            else
            {
                string text = SearchTask.Trim().ToLower();
                TaskList = new ObservableCollection<TaskModel>(dbContext.TaskTable.
                                 Where(t => t.UserId == User.UserId && t.TaskName.ToLower().Contains(text)));
            }
        }
        
        public void ViewTaskModal(object parameter)
        {
            AddTaskModal addTaskModal = new AddTaskModal();
            addTaskModal.Show();
        }
            public bool Can(object parameter)
            {
                return true;
            }

            // Delete task
            public void Remove()
            {
            MessageBox.Show("sdjskd");
                if (SelectedTask != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to remove the task?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        dbContext.TaskTable.Remove(SelectedTask);
                        dbContext.SaveChanges(true);
                        UpdateTaskList();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Task to remove");
                }
            }
            public void Reset()
            {

            }
            private TaskModel FindTaskByID(int TaskId)
            {
                return TaskList.FirstOrDefault(task => task.TaskId == TaskId);
            }
            public void Update(object parameter)
            {
                if (SelectedTask != null)
                {
                    TaskModel task = FindTaskByID(SelectedTask.TaskId);
                    task.TaskName = Task.TaskName;
                    task.Description = Task.Description;
                    task.Status = Task.Status;
                    dbContext.TaskTable.Update(task);
                    dbContext.SaveChanges();
                    dbContext.Entry(task).Reload();
                    Reset();
                    MessageBox.Show("Task Updated Successfully");
                    //LoadTask();
                }
                else
                {
                    MessageBox.Show("Fuck you");
                }
            }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
