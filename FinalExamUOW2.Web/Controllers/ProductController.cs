using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalExamUOW2.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalExamUOW2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id, int page = 1, int pageSize = 3)
        {
            var productList = _unitOfWork.ProductRepository.GetByCategoryId(id);
            X.PagedList.PagedList<FinalExamUOW2.Data.Models.Product> model = new X.PagedList.PagedList<FinalExamUOW2.Data.Models.Product>(productList.Where(x => x.CategoryID == id), page, pageSize);
            return View(model);
        }
    }
}