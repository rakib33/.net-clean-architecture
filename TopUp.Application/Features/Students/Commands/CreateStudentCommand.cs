
using TopUp.Application.Common.CustomMediator;

namespace TopUp.Application.Features.Students.Commands
{
    public record CreateStudentCommand : IRequest<long>
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Email { get; set; } = "";
    };
}
