using Asp_Rocky.Models;
using Asp_Rocky_DataAccess.Data;
using Asp_Rocky_DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp_Rocky_DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        
    }
}
