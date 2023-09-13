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

namespace TimeKeeper.ViewModels
{
    public class TaskViewModel : BindableBase, INotifyPropertyChanged
    {
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
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand ViewTaskModalCommand { get; set; }
        private TaskModel _selectedTask;
        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                if (_selectedTask != value)
                {
                    _selectedTask = value;
                    OnPropertyChanged(nameof(SelectedTask));
                }
            }
        }
        public ObservableCollection<TaskModel> TaskList { get; set; }

        public TaskViewModel()
        {
            User = new UserModel();
            Task = new TaskModel();
            dbContext = new AppDbContext();
            AddCommand = new RelayCommand(Add, Can);
            RemoveCommand = new RelayCommand(Remove, Can);
            UpdateCommand = new RelayCommand(Update, Can);
            ViewTaskModalCommand = new RelayCommand(ViewTaskModal, Can);
            TaskList = new ObservableCollection<TaskModel>(dbContext.TaskTable);
        }
        private void LoadTask()
        {
            TaskList = new ObservableCollection<TaskModel>(dbContext.TaskTable);
        }
        public void ViewTaskModal(object parameter)
        {
            TaskModal taskModal = new TaskModal();
            taskModal.Show();
        }
        // Add Task
        public void Add(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(Task.TaskName) && !string.IsNullOrWhiteSpace(Task.Description) && !string.IsNullOrEmpty(Task.Status))
            {
                TaskModel tasks = new TaskModel { UserId = 1, TaskName = Task.TaskName, Description = Task.Description, Status = Task.Status };
                dbContext.TaskTable.Add(tasks);
                dbContext.SaveChanges();
                TaskList.Add(tasks);
                LoadTask();
                MessageBox.Show("Task added successfully");
                /*Application.Current.Windows.OfType<AddTaskModal>().FirstOrDefault()?.Close();*/
            }
            else
            {
                MessageBox.Show("Please enter all fields");
            }
        }
        public bool Can(object parameter)
        {
            return true;
        }

        // Delete task
        public void Remove(object parameter)
        {
            if (SelectedTask != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to remove the task?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    dbContext.TaskTable.Remove(SelectedTask);
                    dbContext.SaveChanges(true);
                    TaskList.Remove(SelectedTask);
                    TaskList.Remove(SelectedTask);
                    SelectedTask = null;
                    LoadTask();
                    Reset();
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
                Reset();
                MessageBox.Show("Task Updated Successfully");
                LoadTask();
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
