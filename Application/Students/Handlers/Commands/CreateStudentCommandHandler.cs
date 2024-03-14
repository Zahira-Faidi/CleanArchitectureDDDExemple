using Application.Students.Commands;
using Domain.Students.Entities;
using Domain.Students.Repositories;
using MediatR;

namespace Application.Students.Handlers.Commands
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;
        public CreateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
              
            var student = new StudentEntity
            {
                Id = request.Id,
                Name = request.Name,
                Age = request.Age,
            };
            var result = _studentRepository.CreateStudent(student, cancellationToken);
            
            return Task.FromResult(result);
        }
    }
}
