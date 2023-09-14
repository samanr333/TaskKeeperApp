using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TimeKeeper.Command;
using TimeKeeper.DataContext;
using TimeKeeper.Models;
using TimeKeeper.Services;
using TimeKeeper.Views;

namespace TimeKeeper.ViewModels
{
    public class UpdateTaskModalViewModel : BindableBase, INotifyPropertyChanged
	{
        private IEventAggregator _eventAggregator;
        public AppDbContext dbContext;
        private DataServices _services;
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
        private TaskModel _updatedtask;
        public TaskModel UpdatedTask
        {
            get { return _updatedtask; }
            set
            {
                _updatedtask = value;
                OnPropertyChanged(nameof(UpdatedTask));
            }
        }
        public ICommand UpdateCommand { get; set; }
        public List<string> StatusList { get; set; }
        public UpdateTaskModalViewModel(DataServices services, EventAggregator eventAggregator)
        {
            StatusList = new List<string>
            {
                "Pending",
                "In Progress",
                "Done"
            };
            _eventAggregator = eventAggregator;
            _services = services;
            dbContext = new AppDbContext();
            Task = new TaskModel();
            Task = _services.GetSharedTaskData();
            UpdatedTask = new TaskModel();
            UpdateCommand = new RelayCommand(Update, CanUpdate);
        }
        /*public void Update(object parameter)
        {
            if (Task != null)
            {
                UpdatedTask.Status = Task.Status;
                TaskModel tasks = new TaskModel {UserId = Task.UserId, TaskId = Task.TaskId ,TaskName = Task.TaskName, Description = Task.Description, Status = UpdatedTask.Status, TaskCreateDate = Task.TaskCreateDate, TaskUpdatedDate = DateTime.UtcNow};
                dbContext.TaskTable.Update(tasks);
                dbContext.SaveChanges();
                _eventAggregator.GetEvent<PubSubEvent<TaskModel>>().Publish(tasks);
                Task = null;
                MessageBox.Show("Task Updated Successfully");
                Application.Current.Windows.OfType<UpdateTaskModal>().FirstOrDefault()?.Close();
            }
        }*/
        public void Update(object parameter)
        {
            if (Task != null)
            {
                UpdatedTask.Status = Task.Status;
                TaskModel updatedTask = new TaskModel
                {
                    UserId = Task.UserId,
                    TaskId = Task.TaskId,
                    TaskName = Task.TaskName,
                    Description = Task.Description,
                    Status = UpdatedTask.Status,
                    TaskCreateDate = Task.TaskCreateDate,
                    TaskUpdatedDate = DateTime.Now // Set TaskUpdatedDate to the current date and time
                };

                dbContext.TaskTable.Update(updatedTask);
                dbContext.SaveChanges();

                _eventAggregator.GetEvent<PubSubEvent<TaskModel>>().Publish(updatedTask);
                MessageBox.Show("Task Updated Successfully");
                Application.Current.Windows.OfType<UpdateTaskModal>().FirstOrDefault()?.Close();
            }
        }

        public bool CanUpdate(object parameter)
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
