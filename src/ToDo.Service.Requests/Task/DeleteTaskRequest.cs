using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Service.Requests.Task
{
    public class DeleteTaskRequest : IRequest<bool>
    {
        public DeleteTaskRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
