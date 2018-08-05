using System.Threading.Tasks;

namespace StudentSystem.DAL.Commands.Abstractions
{
    public abstract class BaseDbCommand<TEntity>
    {
        protected ApplicationDbContext dbContext { get; set; }

        protected BaseDbCommand(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public abstract TEntity Execute();

        public abstract Task<TEntity> ExecuteAsync();

        //реалізувати 2 метода
    }
}
