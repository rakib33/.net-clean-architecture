using TopUp.Application.Common.CustomMediator;
using TopUp.Domain.Entities;

namespace TopUp.Application.Features.Students.Queries
{
    public record GetStudentsQuery() : IRequest<IEnumerable<Student>>;
}
