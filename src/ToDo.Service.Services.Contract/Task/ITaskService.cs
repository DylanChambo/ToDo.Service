﻿namespace ToDo.Service.Services.Contract.Task;

public interface ITaskService
{
    IEnumerable<Entities.Task> GetAll();

    Task<bool> Create(Entities.Task task);

    Task<bool> Update(Entities.Task task);

    Task<bool> Delete(int Id);
}