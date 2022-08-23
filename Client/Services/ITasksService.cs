﻿using Stroom.Shared.Models;

namespace Stroom.Client.Services
{
    public interface ITasksService
    {
        public Task<TaskDto[]> GetAsync();
        public Task<TaskDto> GetAsync(int taskId);
    }
}