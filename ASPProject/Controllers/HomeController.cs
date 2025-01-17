﻿using System;
using ASPProject.Data;
using ASPProject.Models;
using ASPProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			List<SliderInfo> sliderInfos = await _context.SliderInfos.ToListAsync();
            List<Slider> sliders = await _context.Sliders.ToListAsync();
			List<Featur> featurs = await _context.Featurs.ToListAsync();
			List<Fact> facts = await _context.Facts.ToListAsync();
			List<SelectedProduct> selectedProducts = await _context.SelectedProducts.ToListAsync();
			List<Offer> offers = await _context.Offers.ToListAsync();
			Dictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);
			List<Category> categories = await _context.Categories.ToListAsync();
			List<Product> products = await _context.Products.Include(m=>m.ProductImage).ToListAsync();

            HomeVM model = new()
			{
				SliderInfos = sliderInfos,
				Sliders=sliders,
				Featurs=featurs,
				Facts=facts,
                SelectedProducts = selectedProducts,
				Offers=offers,
                Settings = settings,
				Categories=categories,
				Products=products
			};

			return View(model);
		}

	}
}

