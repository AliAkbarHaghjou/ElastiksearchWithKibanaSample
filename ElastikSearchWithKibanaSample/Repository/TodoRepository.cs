using ElastikSearchWithKibanaSample.Context;
using ElastikSearchWithKibanaSample.Entities;
using ElastikSearchWithKibanaSample.Interfaces;

namespace ElastikSearchWithKibanaSample.Repository
{
    public class TodoRepository : BaseRepository<Todo>, ITodoRepository
    {
        public TodoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
