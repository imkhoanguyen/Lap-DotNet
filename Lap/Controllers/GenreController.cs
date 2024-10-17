using Application.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lap.Controllers
{
    public class GenreController : Controller
    {
        private readonly IUnitOfWork _unit;
        public GenreController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _unit.Genre.GetAllAsync();
            return View(genres);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Genre genre)
        {
            if(!ModelState.IsValid) 
                return View(genre);
            _unit.Genre.Add(genre);
            if(await _unit.Complete())
                return RedirectToAction("Index"); 
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var genre = await _unit.Genre.GetAsync(g => g.Id == id);
            if (genre == null)
                return NotFound("Genre not found");

            return View(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Genre genre)
        {
            if(!ModelState.IsValid)
                return View(genre);

            var genreFromDb = _unit.Genre.GetAsync(g => g.Id == genre.Id);
            if (genre == null)
                return BadRequest("Genre not found");

            _unit.Genre.Update(genre);

            if (await _unit.Complete())
                return RedirectToAction("Index");

            return View(genre);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _unit.Genre.GetAsync(g => g.Id == id);
            if (genre == null)
                return NotFound("Genre not found");

            return View(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Genre genre)
        {
            var genreFromDb = _unit.Genre.GetAsync(g => g.Id == genre.Id);
            if (genre == null)
                return BadRequest("Genre not found");

            _unit.Genre.Remove(genre);

            if (await _unit.Complete())
                return RedirectToAction("Index");

            return View(genre);
        }
    }
}
