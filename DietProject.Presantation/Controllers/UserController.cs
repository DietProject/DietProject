using DietProject.Application.Contract.IRepository;
using DietProject.Application.Contract.IServices;
using DietProject.Application.Services;
using DietProject.Application.ViewModels;
using DietProject.Infrastructure.Persistence;
using DietProject.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DietProject.Presantation.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService service;
		public UserController(IUserService service)
		{
			this.service = service;
		}
		public IActionResult Index()
		{
			return View(service.GetAll());
		}
		public IActionResult UserAdd()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UserAdd(UserVM vm)
		{
			await service.AddAsync(vm);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> UserDelete(Guid id)
		{
			var model = await service.GetAsyncById(id);
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> UserDelete(UserVM user)
		{
		
              await service.DeleteAsync(user);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> UserUpdate(Guid id)
		{
			var model =await service.GetAsyncById(id);
			return View(model);
		}

		[HttpPost]
		public IActionResult UserUpdate(UserVM user)
		{
			service.Update(user);
			return RedirectToAction("Index");
		}
	}
}
