using Asp_Rocky.Models;
using Asp_Rocky_DataAccess.Data;
using Asp_Rocky_DataAccess.Repository.IRepository;
using Asp_Rocky_Models;
using Asp_Rocky_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp_Rocky_DataAccess.Repository
{
    public class InquiyHeaderRepository : Repository<InquiryHeader>, IInquiryHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public InquiyHeaderRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(InquiryHeader obj)
        {
            _db.InquiryHeader.Update(obj);
        }
    }
}
