using DietProject.Application.Contract.IServices;
using DietProject.Application.Services;
using DietProject.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DietProject.Presantation.Controllers
{
    public class MealController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMealService _mealService;
        private readonly IFoodService _foodService;
        public MealController(IUserService _userService, IMealService _mealService, IFoodService _foodService)
        {
            this._userService = _userService;
            this._mealService = _mealService;
            this._foodService = _foodService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateMeal(Guid id)
        {
            var user = await _userService.GetAsyncById(id);
            var mealvm = new MealVM() { UserId=user.Id,User=user};
            mealvm.Foods = _foodService.GetAll(); 
            return View(mealvm);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMeal(MealVM mealVM)
        {

            mealVM.User= await _userService.GetAsyncById(mealVM.UserId);
            await _mealService.AddAsync(mealVM);
            return RedirectToAction("GetMeal");
        }
    }
}
