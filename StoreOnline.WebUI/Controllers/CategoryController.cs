using Microsoft.AspNetCore.Mvc;
using StoreOnline.Service.Contracts;
using StoreOnline.Service.Models;
using StoreOnline.WebUI.Extentions;
using StoreOnline.WebUI.Models;
using System.Collections.Generic;

namespace StoreOnline.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = ((List<Service.Models.CategoryModel>)categoryService.GetAll().Data)
                                                                              .ConvertCategoryModelToModel();
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var categoryModel = ((CategoryModel)this.categoryService.GetById(id).Data)
                                              .ConvertFromCategoryModelToCategory();

            return View(categoryModel);
        }

        // GET: CategoryController  /Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category CategoryModel)
        {
            try
            {
                Service.Dtos.CategorySaveDto categorySaveDto = new Service.Dtos.CategorySaveDto()
                {
                    UserId = 1,
                    AuditDate = System.DateTime.Now,
                    creation_date = CategoryModel.creation_date,
                    CategoriesName = CategoryModel.CategoriesName,
                    CategoriesDescription = CategoryModel.CategoriesDescription
                };

                categoryService.SaveCategory(categorySaveDto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {

            var student = (Service.Models.CategoryModel)categoryService.GetById(id).Data;

            Models.Category Modelcategory = new Models.Category()
            {
                CategoryId = student.CategoryId,
                creation_date = student.creation_date,
                CategoriesName = student.CategoriesName,
                CategoriesDescription = student.CategoriesDescription
            };

            return View(Modelcategory);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category categoryModel)
        {
            try
            {
                var myModel = categoryModel;

                Service.Dtos.CategoryUpdateDto categoryUpdate = new Service.Dtos.CategoryUpdateDto()
                {
                    CategoryId = categoryModel.CategoryId,
                    AuditDate = System.DateTime.Now,
                    depositDate = categoryModel.creation_date,
                    CategoriesName = categoryModel.CategoriesName,
                    CategoriesDescription = categoryModel.CategoriesDescription,
                    UserId = 1
                };

                categoryService.UpdateCategory(categoryUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
