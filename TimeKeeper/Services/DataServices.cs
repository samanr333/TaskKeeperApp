﻿using TimeKeeper.Models;

namespace TimeKeeper.Services
{
    public class DataServices
    {
        private UserModel _sharedData;
        public UserModel GetSharedData()
        {
            return _sharedData;
        }
        public void SetSharedData(UserModel data)
        {
            _sharedData = data;
        }


        private TaskModel _sharedTaskData;
        public TaskModel GetSharedTaskData()
        {
            return _sharedTaskData;
        }
        public void SetSharedTaskData(TaskModel data)
        {
            _sharedTaskData = data;
        }

    }
}
