using MediatR;

namespace Application.Students.Commands
{
    public class CreateStudentCommand: IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
