using System.Collections.Generic;
using System.Threading.Tasks;
using Jour.Database.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Jour.Database.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly JourContext _context;

        public ExerciseRepository(JourContext context)
        {
            _context = context;
        }
        
        public async Task<List<Exercise>> GetAll()
        {
            List<Exercise> result = await _context.Exercises.ToListAsync();
            return result;
        }
    }
}