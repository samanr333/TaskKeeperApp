using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
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
        private DataServices _services;
        public DashboardViewModel(DataServices services)
        {
            dbContext = new AppDbContext();
            User = new UserModel();
            _services = services;
            User = _services.GetSharedData();
            TaskCount();
            PendingTaskCount();
            InprogressTaskCount();
            DoneTaskCount();
        }
        public void TaskCount()
        {
            var totaltask = dbContext.TaskTable.Count(task => task.UserId == User.UserId); ;
            TotalTask = totaltask;
        }
        public void PendingTaskCount()
        {
            var totalpendingtask = dbContext.TaskTable.Count(task => task.UserId == User.UserId && task.Status == "Pending"); 
            PendingTask = totalpendingtask;
        }
        public void InprogressTaskCount()
        {
            var totalinprogresstask = dbContext.TaskTable.Count(task => task.UserId == User.UserId && task.Status == "In Progress");
            InprogressTask = totalinprogresstask;
        }
        public void DoneTaskCount()
        {
            var totalDonetask = dbContext.TaskTable.Count(task => task.UserId == User.UserId && task.Status == "Done");
            DoneTask = totalDonetask;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
