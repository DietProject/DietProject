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
        private readonly IMealDetailService _mealDetailService;

        public MealController(IUserService _userService,
                              IMealService _mealService,
                              IFoodService _foodService,
                              IMealDetailService _mealDetailService)
        {
            this._userService = _userService;
            this._mealService = _mealService;
            this._foodService = _foodService;
            this._mealDetailService = _mealDetailService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateMeal(Guid id)
        {
            var user = await _userService.GetAsyncById(id);
            var createMeal = new CreateMealVM() { UserId = user.Id, User = user };
            createMeal.Foods = _foodService.GetAll();
            return View(createMeal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeal(CreateMealVM createMeal)
        {
            var mealVM = new MealVM
            {
                UserId = createMeal.UserId,
                MealType = createMeal.MealType,
                MealDate = createMeal.MealDate
            };

            // Veri tekrarnı önlemek, Meals tablosunda mevcutta UserId, MealType, MealDate girişi yapılmamışsa yeni Meal eklemeli.
            var containResult = _mealService.GetAll().FirstOrDefault(x => x.User.Id == mealVM.UserId &&
                                                                x.MealType == mealVM.MealType &&
                                                                x.MealDate == mealVM.MealDate);
            if (containResult == null)
            {
                var result = await _mealService.CreateAsync(mealVM);
                var mealDetail = new MealDetailVM
                {
                    MealId = result.Id,
                    FoodId = createMeal.SelectedFoodId,
                    Amount = createMeal.Amount,
                };
                await _mealDetailService.AddAsync(mealDetail);
                return RedirectToAction("Index", "User");
            }
            else
            {
                var mealDetail = new MealDetailVM
                {
                    MealId = containResult.Id,
                    FoodId = createMeal.SelectedFoodId,
                    Amount = createMeal.Amount,
                };
                await _mealDetailService.AddAsync(mealDetail);
                return RedirectToAction("Index", "User");

            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult EditUserMeal(Guid id)
        {
            //var user = await _userService.GetAsyncById(id);
            MealVM editMeal = new MealVM() { UserId = id };
            //createMeal.Foods = _foodService.GetAll();

            return View(editMeal);
        }

        [HttpPost]
        public IActionResult EditUserMeal(MealVM mealVM)
        {
            var result = _mealService.GetAll().FirstOrDefault(x => x.User.Id == mealVM.UserId &&
                x.MealType == mealVM.MealType &&
                x.MealDate == mealVM.MealDate);

            IEnumerable<MealDetailVM> list = _mealDetailService.GetAll().Where(x => x.MealId == result.Id);

            return View("EditListMeal", list);
        }


        public async Task<IActionResult> DeleteMeal(Guid id)
        {
            var result = await _mealDetailService.GetAsyncById(id);
            result.Food = await _foodService.GetAsyncById(result.FoodId);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMeal(MealDetailVM mealDetailVM)
        {
            await _mealDetailService.DeleteAsync(mealDetailVM);

            return RedirectToAction("Index", "User");
        }


        public async Task<IActionResult> UpdateMeal(Guid id)
        {
            var result = await _mealDetailService.GetAsyncById(id);
            result.Food = await _foodService.GetAsyncById(result.FoodId);

            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateMeal(MealDetailVM mealDetailVM)
        {
            _mealDetailService.Update(mealDetailVM);
            return RedirectToAction("Index", "User");
        }

    }
}
