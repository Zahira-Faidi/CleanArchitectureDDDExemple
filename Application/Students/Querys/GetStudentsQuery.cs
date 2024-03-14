using Application.Students.Models;
using Domain.Students.Entities;
using MediatR;

namespace Application.Students.Querys
{
    public class GetStudentsQuery : IRequest<IEnumerable<Student>>
    {

    }

}
