using StudentSystem.DAL.Commands.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentSystem.DTO;

using Microsoft.EntityFrameworkCore;
using StudentSystem.DTO.Enumerations;

namespace StudentSystem.DAL.Commands.ApplicationUser
{
    public class CreateUserCommand : BaseDbCommand<bool>
    {
        public RegisterUserDTO User { get; set; }

        public CreateUserCommand(ApplicationDbContext dbContext, RegisterUserDTO user) : base(dbContext)
        {
            User = user;
        }

        public override bool Execute()
        {
            dbContext.Users.Add(new Entities.ApplicationUser
            {
                Username = User.Email,
                Email = User.Email,
                Password = User.Password,
                Role = new Entities.Role {Name = UserRoles.User}
            });

             dbContext.SaveChanges();

            return true;
        }

        public override async Task<bool> ExecuteAsync()
        {
            await dbContext.Users.AddAsync(new Entities.ApplicationUser
            {
                Username = User.Email,
                Email = User.Email,
                Password = User.Password,
                Role = new Entities.Role { Name = UserRoles.User }
            });

            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
