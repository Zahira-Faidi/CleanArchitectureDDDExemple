using Domain.Students.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Querys
{
    public class GetStudentByIdQuery : IRequest<StudentEntity>
    {
        public int Id { get; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
