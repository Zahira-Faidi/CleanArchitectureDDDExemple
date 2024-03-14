using Application.Students.Querys;
using Domain.Students.Entities;
using Domain.Students.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Handlers.Querys
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentEntity>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentEntity> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetById(request.Id, cancellationToken);
        }
    }
}
