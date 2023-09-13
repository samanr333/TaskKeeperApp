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
            /*TaskCount();*/
        }
        public void TaskCount()
        {
            User = _services.GetSharedData();
            var totaltask = dbContext.UserTable.Count(task => task.UserId == User.UserId);
            TotalTask = totaltask;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
