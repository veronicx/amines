﻿using AminesStream.Models.Domain;
using AminesStream.Repositories.Abstractions;
using AminesStream.Repositories.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AminesStream.Controllers
{
    [Authorize(Roles="Admin")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService; 
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _genreService.Add(model);
            if (result)
            {
                TempData["msg"] = "The movie has been added";
                return RedirectToAction(nameof(Add));
            } else
            {
                TempData["msg"] = "There was problem with adding the movie";
                return View(model);
            }
               
        }

        public IActionResult Edit(int id)
        {
            var data = _genreService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _genreService.Update(model);
            if (result)
            {
                TempData["msg"] = "Update successfully";
                return RedirectToAction(nameof(GenreList));
            }
            else
            {
                TempData["msg"] = "There was problem with updating";
                return View(model);
            }

        }

        public IActionResult GenreList()
        {
            var data = _genreService.List().ToList();
            return View(data);
        }

        public IActionResult Update(int id)
        {
            var result = _genreService.Delete(id);
  
                return RedirectToAction(nameof(GenreList));
        }

    }

}

