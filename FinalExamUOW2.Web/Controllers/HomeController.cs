using FinalExamUOW2.Data.Interfaces;
using FinalExamUOW2.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalExamUOW2.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserList(int id, int page = 1, int pageSize = 2)
        {
            X.PagedList.PagedList<User> result = new X.PagedList.PagedList<User>(_unitOfWork.UserRepository.List(), page, pageSize);
            return View(result);
        }
    }
}
