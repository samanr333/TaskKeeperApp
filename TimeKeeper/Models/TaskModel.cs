using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace TimeKeeper.Models
{
    public class TaskModel
    {
        private int _taskId;
        private string _taskName;
        private DateTime _taskCreateDate;
        private string _description;
        private string _status;
        private int _userId; // Foreign key to relate tasks to users
        private UserModel _user; // Navigation property to access the associated user

        [Key]
        public int TaskId
        {
            get => _taskId;
            set
            {
                if (_taskId != value)
                {
                    _taskId = value;
                    OnPropertyChanged(nameof(TaskId));
                }
            }
        }

        public string TaskName
        {
            get => _taskName;
            set
            {
                if (_taskName != value)
                {
                    _taskName = value;
                    OnPropertyChanged(nameof(TaskName));
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public DateTime TaskCreateDate
        {
            get => _taskCreateDate;
            set
            {
                if (_taskCreateDate != value)
                {
                    _taskCreateDate = value;
                    OnPropertyChanged(nameof(TaskCreateDate));
                }
            }
        }
        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        // Foreign key to relate tasks to users
        public int UserId
        {
            get => _userId;
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged(nameof(UserId));
                }
            }
        }

        // Navigation property to access the associated user
        public UserModel User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
