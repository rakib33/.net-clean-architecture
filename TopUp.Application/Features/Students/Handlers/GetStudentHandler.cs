using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Students.Queries;
using TopUp.Domain.Entities;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Features.Students.Handlers
{

    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, IEnumerable<Student>>
    {
        private readonly IStudentRepository _repo;
        public GetStudentsHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken = default)
        {
            return await _repo.GetAllAsync(cancellationToken);
        }
    }
}
