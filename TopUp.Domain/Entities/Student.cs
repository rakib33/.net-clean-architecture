using DoctorBooking.Domain.Entities;

namespace TopUp.Domain.Entities
{
    public class Student : BaseEntity<long>
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public string Email { get; set; } = default!;
    }
}
