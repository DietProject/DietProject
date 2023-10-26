using DietProject.Application.Contract.IRepository;
using DietProject.Application.Contract.IServices;
using DietProject.Application.Services;
using DietProject.Application.ViewModels;
using DietProject.Infrasturucture.Persistence;
using DietProject.Infrasturucture.Repositories;
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
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin(UserVM vm)
        {
            service.AddAsync(vm);
            return RedirectToAction("Index");
        }
    }
}
