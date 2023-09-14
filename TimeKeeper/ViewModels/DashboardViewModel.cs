using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TimeKeeper.DataContext;
using TimeKeeper.Models;
using TimeKeeper.Services;

namespace TimeKeeper.ViewModels
{
    public class DashboardViewModel : BindableBase, INotifyPropertyChanged
    {
        private IEventAggregator _eventAggregator;
        private readonly AppDbContext dbContext;
        private int _totalTask;
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
        public ObservableCollection<int> Counts = new ObservableCollection<int>();
        private DataServices _services;
        public DashboardViewModel(DataServices services, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            dbContext = new AppDbContext();
            User = new UserModel();
            _services = services;
            _eventAggregator.GetEvent<PubSubEvent<TaskModel>>().Subscribe(AddTaskCount);
            _eventAggregator.GetEvent<PubSubEvent<TaskModel>>().Subscribe(UpdateTaskCount);
            User = _services.GetSharedData();
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
            TotalTask = dbContext.TaskTable.Count(task => task.UserId == User.UserId); ;
            PendingTask = dbContext.TaskTable.Count(task => task.UserId == User.UserId && task.Status == "Pending");
            InprogressTask = dbContext.TaskTable.Count(task => task.UserId == User.UserId && task.Status == "In Progress");
            DoneTask = dbContext.TaskTable.Count(task => task.UserId == User.UserId && task.Status == "Done");
            Counts = new ObservableCollection<int>() { PendingTask, InprogressTask, DoneTask };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
