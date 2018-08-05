using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentSystem.DAL;

namespace StudentSystem.API.Services
{
    public class BaseService
    {
        protected ApplicationDbContext dbContext { get; set; }

        protected BaseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
