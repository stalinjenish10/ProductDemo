using Microsoft.AspNetCore.Mvc;
using ProductDemo.Models;
using ProductDemo.Repository.Interface;
using ProductDemo.Utilities;

namespace ProductDemo.Controllers
{
    [SessionCheck]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public IActionResult Index()
        {
            var products = _productRepository.GetProducList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int userId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
                    _productRepository.AddProduct(product, userId);
                    TempData["Success"] = "Product Added Successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    throw;
                }
            }
            return View(product);
        }



        public IActionResult Edit(int Id)
        {
            var product = _productRepository.GetProductById(Id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int userId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
                    _productRepository.UpdateProduct(product, userId);
                    TempData["Success"] = "Product Updated Successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    throw;
                }
            }
            return View(product);
        }

        public JsonResult DeleteProduct(int Id)
        {
            _productRepository.DeletProduct(Id);
            return Json(new { status = "Success" });
        }

    }
}
