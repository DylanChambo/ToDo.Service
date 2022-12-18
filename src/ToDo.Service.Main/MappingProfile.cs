using AutoMapper;
using ToDo.Service.Entities;
using ToDo.Service.Requests.Models;

namespace ToDo.Service.Main;

/// <summary>
/// Mapping profile for Automapper.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Entities.Task, TaskModel>();
    }
}