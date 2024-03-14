using Application.Students.Models;
using Application.Students.Querys;
using AutoMapper;
using Domain.Students.Repositories;
using MediatR;

namespace Application.Students.Handlers.Querys
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<Student>>
    {
        public readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GetStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            //validation

            //donné -> faire appelle à l'infrastructure
            var resultData = await _studentRepository.GetAll(cancellationToken);
            List<Student> students = new List<Student>();
            foreach (var result in resultData)
            {
                Student s = new Student();
                students.Add(s.ToModel(result));
            }
            //réponse
            return students;
        }
    }
}
