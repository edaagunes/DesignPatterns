﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepositoryDesignPattern.BusinessLayer.Abstract;
using RepositoryDesignPattern.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryDesignPattern.PresentationLayer.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public ProductController(IProductService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}

		public IActionResult Index()
		{
			var values = _productService.TGetList();
			return View(values);
		}

		public IActionResult Index2()
		{
			var values=_productService.TProductListWithCategory();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddProduct()
		{
			List<SelectListItem> values = (from x in _categoryService.TGetList()
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryId.ToString()
										   }).ToList();
			ViewBag.v=values;
			return View();
		}
		[HttpPost]
		public IActionResult AddProduct(Product product)
		{
			_productService.TInsert(product);
			return RedirectToAction("Index2");
		}

		public IActionResult DeleteProduct(int id)
		{
			var values = _productService.TGetById(id);
			_productService.TDelete(values);
			return RedirectToAction("Index2");
		}

		[HttpGet]
		public IActionResult UpdateProduct(int id)
		{
			List<SelectListItem> value = (from x in _categoryService.TGetList()
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryId.ToString()
										   }).ToList();
			ViewBag.v = value;

			var values = _productService.TGetById(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult UpdateProduct(Product product)
		{
			_productService.TUpdate(product);
			return RedirectToAction("Index2");
		}
	}
}
