using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DAL.Commands.Abstractions;

namespace StudentSystem.DAL.Commands.ApplicationUser
{
    public class GetAllUsersCommand : BaseDbCommand<List<Entities.ApplicationUser>>
    {
        public GetAllUsersCommand(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public override List<Entities.ApplicationUser> Execute()
        {
            return dbContext.Users.ToList();
        }

        public override async Task<List<Entities.ApplicationUser>> ExecuteAsync()
        {
            return await dbContext.Users.ToListAsync();
        }
    }
}
