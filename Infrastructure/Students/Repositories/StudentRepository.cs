using Domain.Students.Entities;
using Domain.Students.Repositories;

namespace Infrastructure.Students.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private List<StudentEntity> _students = new List<StudentEntity>
        {
            new StudentEntity { Id = 1, Name = "Student1", Age = 16 },
            new StudentEntity { Id = 2, Name = "Student2", Age = 22 },
            new StudentEntity { Id = 3, Name = "Student3", Age = 23 },
            new StudentEntity { Id = 4, Name = "Student4", Age = 27 },
            new StudentEntity { Id = 5, Name = "Student5", Age = 20 },
        };

        public bool CreateStudent(StudentEntity student, CancellationToken cancellationToken)
        {
            _students.Add(student); return true;
        }

        public Task<List<StudentEntity>> GetAll(CancellationToken cancellationToken)
        {
            return Task.FromResult(_students);
        }
        // Get Student By Id
        public Task<StudentEntity> GetById(int id, CancellationToken cancellationToken)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            return Task.FromResult(student);
        }
        // Delete
        public Task<bool> DeleteStudent(StudentEntity student, CancellationToken cancellationToken)
        {
            try
            {
                _students.Remove(student);
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
        // Update
        public Task<bool> UpdateStudent(StudentEntity student, CancellationToken cancellationToken)
        {

                var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
                if (existingStudent == null)
                {
                    Console.WriteLine("Student not found");
                }

                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;

                return Task.FromResult(true);
          

        }
    }
}
