
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Students.Commands;
using TopUp.Domain.Entities;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Features.Students.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand,long>
    {
        private readonly IStudentRepository _repo;
        public CreateStudentHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<long> Handle(CreateStudentCommand request, CancellationToken cancellationToken = default)
        {
            var student = new Student { Name = request.Name, Age = request.Age };
            await _repo.AddAsync(student, cancellationToken); // pass token down to db
            return student.Id;
        }
    }
}
