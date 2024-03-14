using Domain.Students.Entities;

namespace Domain.Students.Repositories
{
    public interface IStudentRepository
    {
        bool CreateStudent(StudentEntity student, CancellationToken cancellationToken);
        Task<List<StudentEntity>> GetAll(CancellationToken cancellationToken);
        Task<StudentEntity> GetById(int id, CancellationToken cancellationToken);
        Task<bool> DeleteStudent(StudentEntity student, CancellationToken cancellationToken);
        Task<bool> UpdateStudent(StudentEntity existingStudent, CancellationToken cancellationToken);
    }
}