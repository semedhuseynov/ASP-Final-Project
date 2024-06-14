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

            HomeVM model = new()
			{
				SliderInfos = sliderInfos,
				Sliders=sliders,
				Featurs=featurs
			};

			return View(model);
		}

	}
}

