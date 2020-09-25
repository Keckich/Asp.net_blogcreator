﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PostContext db;
        public HomeController(ILogger<HomeController> logger, PostContext context)
        {
            _logger = logger;
            db = context;
        }

        public async Task<IActionResult> Index(string searchString, string postCategory)
        {
            var posts = from p in db.Posts select p;
            IQueryable<string> categoryQuery = from p in db.Categories orderby p.Title select p.Title;   
            if (!String.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(s => s.Title.Contains(searchString));
            }
            
            if (!String.IsNullOrEmpty(postCategory))
            {
                posts = posts.Where(p => p.Category.Title == postCategory);
            }

            var postCategoryVm = new CategoryViewModel
            {
                Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Posts = await posts.ToListAsync()
            };
            return View(postCategoryVm);
        }

        public IActionResult Details(int id)
        {
            var post = db.Posts.Find(id);
            return View(post);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}