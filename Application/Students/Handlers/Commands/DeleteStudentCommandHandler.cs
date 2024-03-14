using Application.Students.Commands;
using Domain.Students.Repositories;
using MediatR;

namespace Application.Students.Handlers.Commands
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentToDelete = await _studentRepository.GetById(request.Id, cancellationToken);

            if (studentToDelete == null)
            {
                throw new Exception($"Student with ID {request.Id} not found.");
            }

            return await _studentRepository.DeleteStudent(studentToDelete, cancellationToken);
        }
    }
}
