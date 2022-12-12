using Asp_Rocky_DataAccess.Data;
using Asp_Rocky.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp_Rocky_DataAccess.Repository;
using Asp_Rocky_DataAccess.Repository.IRepository;
using Asp_Rocky_Utility;

namespace Asp_Rocky.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository  _catRepo;

        public CategoryController(ICategoryRepository CatRepo)
        {
            _catRepo = CatRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _catRepo.GetAll();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _catRepo.Add(obj);
                _catRepo.Save();
                TempData[WC.Success] = "Категория успешно добавлена";
                return RedirectToAction("Index");
            }
            TempData[WC.Error] = "Ошибка при добавлении категории";
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _catRepo.Find(id.GetValueOrDefault());
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _catRepo.Update(obj);
                _catRepo.Save();
                TempData[WC.Success] = "Категория успешно изменена";
                return RedirectToAction("Index");
            }
            TempData[WC.Error] = "Ошибка при обновлении категории";
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _catRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _catRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                TempData[WC.Error] = "Ошибка при удалении категории";
                return NotFound();
            }
            _catRepo.Remove(obj);
            _catRepo.Save();
            TempData[WC.Success] = "Категория успешно удалена";
            return RedirectToAction("Index");
        }
    }
}
