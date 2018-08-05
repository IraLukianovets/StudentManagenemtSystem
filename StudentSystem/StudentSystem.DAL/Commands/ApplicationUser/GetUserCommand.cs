using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DAL.Commands.Abstractions;

namespace StudentSystem.DAL.Commands.ApplicationUser
{
    public class GetUserCommand : BaseDbCommand<Entities.ApplicationUser>
    {
        public string Username { get; set; }

        public GetUserCommand(ApplicationDbContext dbContext, string username) : base(dbContext)
        {
            Username = username;
        }

        public override Entities.ApplicationUser Execute()
        {
            return dbContext.Users.FirstOrDefault(user => user.Username.Equals(Username));
        }

        public override Task<Entities.ApplicationUser> ExecuteAsync()
        {
            return dbContext.Users.Include(user => user.Role).FirstOrDefaultAsync(user => user.Username.Equals(Username));
        }
    }
}
