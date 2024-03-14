using Application.Students.Commands;
using Domain.Students.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Handlers.Commands
{
    public class EditStudentCommandHandler : IRequestHandler<EditStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;
        public EditStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<bool> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingStudent = await _studentRepository.GetById(request.Id, cancellationToken);
                
                // Validation

                if (existingStudent == null)
                {
                    throw new Exception($"Student with id {request.Id} not found");
                }

                existingStudent.Name = request.Name;
                existingStudent.Age = request.Age;

                var result = await _studentRepository.UpdateStudent(existingStudent, cancellationToken);

                // Résultat 
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update student: {ex.Message}", ex);
            }
        }
    }
}
