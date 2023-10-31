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
        public MealController(IUserService _userService, IMealService _mealService)
        {
            this._userService = _userService;
            this._mealService = _mealService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateMeal(Guid id)
        {
            var user = await _userService.GetAsyncById(id);
            var mealvm = new MealVM() { UserId=user.Id,User=user};
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
