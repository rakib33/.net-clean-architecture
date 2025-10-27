using Microsoft.EntityFrameworkCore;
using TopUp.Domain.Entities;
using TopUp.Domain.Interfaces;
using TopUp.Infrastructure.Persistence.Context;

namespace TopUp.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default) =>  await _context.Students.ToListAsync(cancellationToken);
        
        public async Task<Student?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => await _context.Students.FindAsync(id, cancellationToken);

        public async Task AddAsync(Student student, CancellationToken cancellationToken = default)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Student student, CancellationToken cancellationToken = default)
        {

            _context.Students.Update(student);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
       
    }
}
