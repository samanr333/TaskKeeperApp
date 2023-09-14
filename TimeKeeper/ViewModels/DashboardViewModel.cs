using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TimeKeeper.DataContext;
using TimeKeeper.Models;
using TimeKeeper.Services;
using Syncfusion.UI.Xaml.Charts;
using System.Linq;

namespace TimeKeeper.ViewModels
{
    public class DashboardViewModel : BindableBase, INotifyPropertyChanged
    {
        private IEventAggregator _eventAggregator;
        private readonly AppDbContext dbContext;
        private int _totalTask;
        public class PieChartData
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
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

        public int TotalTask
        {
            get { return _totalTask; }
            set
            {
                _totalTask = value;
                OnPropertyChanged(nameof(TotalTask));
            }
        }
        private int _pendingTask;
        public int PendingTask
        {
            get { return _pendingTask; }
            set
            {
                _pendingTask = value;
                OnPropertyChanged(nameof(PendingTask));
            }
        }
        private int _inprogressTask;
        public int InprogressTask
        {
            get { return _inprogressTask; }
            set
            {
                _inprogressTask = value;
                OnPropertyChanged(nameof(InprogressTask));
            }
        }
        private int _doneTask;
        public int DoneTask
        {
            get { return _doneTask; }
            set
            {
                _doneTask = value;
                OnPropertyChanged(nameof(DoneTask));
            }
        }
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
        // For chart
        public ObservableCollection<PieChartData> Counts { get; set; }

        public DashboardViewModel(DataServices services, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            dbContext = new AppDbContext();
            User = new UserModel();
            Task = new TaskModel();
            _services = services;
            _eventAggregator.GetEvent<PubSubEvent<TaskModel>>().Subscribe(AddTaskCount);
            _eventAggregator.GetEvent<PubSubEvent<TaskModel>>().Subscribe(DeleteTaskCount);
            User = _services.GetSharedData();
            Task = _services.GetSharedUpdatedTaskData();
            Counts = new ObservableCollection<PieChartData>();
            TaskCounts();
        }

        private void DeleteTaskCount(TaskModel model)
        {
            TaskCounts();
        }

        private void AddTaskCount(TaskModel model)
        {
            TaskCounts();
        }
        private void UpdateTaskCount(TaskModel model)
        {
            TaskCounts();
        }

        public void TaskCounts()
        {
            TotalTask = dbContext.TaskTable.Count(task => task.UserId == User.UserId);
            PendingTask = dbContext.TaskTable.Count(task => task.UserId == User.UserId && task.Status == "Pending");
            InprogressTask = dbContext.TaskTable.Count(task => task.UserId == User.UserId && task.Status == "In Progress");
            DoneTask = dbContext.TaskTable.Count(task => task.UserId == User.UserId && task.Status == "Done");
            Counts.Clear();
            Counts.Add(new PieChartData { Name = "Pending", Value = PendingTask });
            Counts.Add(new PieChartData { Name = "In Progress", Value = InprogressTask });
            Counts.Add(new PieChartData { Name = "Done", Value = DoneTask });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
