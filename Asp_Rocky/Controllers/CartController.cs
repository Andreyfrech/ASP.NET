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
    [Authorize]
    public class CartController : Controller
    {
       
        private readonly IApplicationUserRepository _userRepo;
        private readonly IProductRepository _prodRepo;
        private readonly IInquiryHeaderRepository _inqHRepo;
        private readonly IInquiryDetailRepository _inqDRepo;

        [BindProperty]
        public ProductUserVM ProductUserVM { get; set; }
        public CartController(IProductRepository prodRepo, IApplicationUserRepository userRepo,
            IInquiryDetailRepository inqDRepo, IInquiryHeaderRepository inqHRepo)
        {
            _userRepo = userRepo;
            _prodRepo = prodRepo;
            _inqDRepo = inqDRepo;
            _inqHRepo = inqHRepo;
        }

        public IActionResult Index()
        {
            List<ShoppingCart> shoppingCartsList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
            {
                //session exsits
                shoppingCartsList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
            }

            List<int> prodInCart = shoppingCartsList.Select(i => i.ProductId).ToList();
           // IEnumerable<Product> productList = _db.Product.Where(u => prodInCart.Contains(u.Id));
            
           // IEnumerable<Product> productList = _db.Product.Where(u => prodInCart.Contains(u.Id)).ForEach(item => item.CountInCart = prodInCart.Count);//First(prod => prod == item.Id).Count);
            IEnumerable<Product> Allproduct = _prodRepo.GetAll();
            var productList = from scl in shoppingCartsList join Ap in Allproduct on scl.ProductId equals Ap.Id select new { ProductId = scl.ProductId, Name = Ap.Name, Category = Ap.Category, Description = Ap.Description, Image = Ap.Image, Price = Ap.Price, Count = scl.Count }.ToExpando();
            return View(productList);
        }

        public IActionResult Remove(int id)
        {
            List<ShoppingCart> shoppingCartsList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
            {
                //session exsits
                shoppingCartsList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
            }

            shoppingCartsList.Remove(shoppingCartsList.FirstOrDefault(u => u.ProductId == id));
            HttpContext.Session.Set(WC.SessionCart, shoppingCartsList);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            return RedirectToAction(nameof(Summary));
        }

        public IActionResult Summary()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            List<ShoppingCart> shoppingCartsList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
            {
                //session exsits
                shoppingCartsList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
            }

            List<int> prodInCart = shoppingCartsList.Select(i => i.ProductId).ToList();
            List<int> countProd = shoppingCartsList.Select(i => i.Count).ToList();
            IEnumerable<Product> productList = _prodRepo.GetAll(u => prodInCart.Contains(u.Id));

            ProductUserVM = new ProductUserVM()
            {
                ApplicationUser = _userRepo.FirstOrDefault(u => u.Id == claim.Value),
                ProductList = productList.ToList(),
                CountProduct = countProd
            };

            return View(ProductUserVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public IActionResult SummaryPost(ProductUserVM ProductUserVM)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            InquiryHeader inquiryHeader = new InquiryHeader()
            {
                ApplicationUserId = claim.Value,
                FullName = ProductUserVM.ApplicationUser.FullName,
                Email = ProductUserVM.ApplicationUser.Email,
                PhoneNumber = ProductUserVM.ApplicationUser.PhoneNumber,
                InquiryDate = DateTime.Now
            };

            _inqHRepo.Add(inquiryHeader);
            _inqHRepo.Save();

            foreach(var prod in ProductUserVM.ProductList)
            {
                InquiryDetail inquiryDetail = new InquiryDetail()
                {
                    InquiryHeaderId = inquiryHeader.Id,
                    ProductId = prod.Id
                };
                _inqDRepo.Add(inquiryDetail);
            }
            _inqDRepo.Save();

            return RedirectToAction(nameof(InquiryConfirmation));
        }

        public IActionResult InquiryConfirmation()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }
    public static class Extensions
    {
        public static ExpandoObject ToExpando(this object anonymousObject)
        {
            IDictionary<string, object> anonymousDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(anonymousObject);
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (var item in anonymousDictionary)
                expando.Add(item);
            return (ExpandoObject)expando;
        }
    }
}
