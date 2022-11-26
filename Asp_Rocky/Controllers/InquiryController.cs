using Asp_Rocky_DataAccess.Data;
using Asp_Rocky.Models;
using Asp_Rocky.Models.ViewModel;
using Asp_Rocky_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using Asp_Rocky_DataAccess.Repository.IRepository;
using Asp_Rocky_Models;
using System;

namespace Asp_Rocky.Controllers
{


    public class InquiryController : Controller
    {
        private readonly IInquiryDetailRepository _inqDRepo;
        private readonly IInquiryHeaderRepository _inqHrepo;

        public InquiryController(IInquiryDetailRepository inqDRepo, IInquiryHeaderRepository inqHrepo)
        {
            _inqDRepo = inqDRepo;
            _inqHrepo = inqHrepo;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
