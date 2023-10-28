using DietProject.Application.Contract.IServices;
using DietProject.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DietProject.Presantation.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodService service;
        public FoodController(IFoodService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetAll());
        }

        public IActionResult FoodAdd()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> FoodAdd(FoodVM vm)
        {
            await service.AddAsync(vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> FoodDelete(Guid id)
        {
            var model = await service.GetAsyncById(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> FoodDelete(FoodVM Food)
        {

            await service.DeleteAsync(Food);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> FoodUpdate(Guid id)
        {
            var model = await service.GetAsyncById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult FoodUpdate(FoodVM Food)
        {
            service.Update(Food);
            return RedirectToAction("Index");
        }







    }
}
