﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab4.Data;
using Lab4.Models;
using Lab4.Models.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MessagePack.Formatters;

namespace Lab4.Controllers
{
    public class NewsBoardsController : Controller
    {
        private readonly NewsDbContext _context;

       

        public NewsBoardsController(NewsDbContext context)
        {
            _context = context;
        }

        // GET: NewsBoards
        public async Task<IActionResult> Index()
        {

            var viewModel = new NewsBoardViewModel
            { 
                NewsBoards = await _context.NewsBoards.ToListAsync()

            };
              return View(viewModel);


        }

        // GET: NewsBoards/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NewsBoards == null)
            {
                return NotFound();
            }

            var newsBoard = await _context.NewsBoards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsBoard == null)
            {
                return NotFound();
            }

            return View(newsBoard);
        }

        // GET: NewsBoards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsBoards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Fee")] NewsBoard newsBoard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsBoard);
        }

        // GET: NewsBoards/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NewsBoards == null)
            {
                return NotFound();
            }

            var newsBoard = await _context.NewsBoards.FindAsync(id);
            if (newsBoard == null)
            {
                return NotFound();
            }
            return View(newsBoard);
        }

        // POST: NewsBoards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Fee")] NewsBoard newsBoard)
        {
            if (id != newsBoard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsBoardExists(newsBoard.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(newsBoard);
        }

        // GET: NewsBoards/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NewsBoards == null)
            {
                return NotFound();
            }

            var newsBoard = await _context.NewsBoards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsBoard == null)
            {
                return NotFound();
            }
            
            var newsList = _context.News.Where(x=>x.NewsBoardID.Equals(id)).Count();

            ViewBag.newsCount = newsList;
            return View(newsBoard);
        }

        // POST: NewsBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NewsBoards == null)
            {
                return Problem("Entity set 'NewsDbContext.NewsBoards'  is null.");
            }
            var newsBoard = await _context.NewsBoards.FindAsync(id);
            if (newsBoard != null)
            {
                _context.NewsBoards.Remove(newsBoard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<ActionResult> Select(string id)
        {
            if (id == null || _context.NewsBoards == null)
            {
                return NotFound();
            }

            var title = await _context.NewsBoards.FindAsync(id);

            if (title == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var clients = await (from c in _context.Clients
                                 join s in _context.Subscriptions on c.Id equals s.ClientId
                                 join n in _context.NewsBoards on s.NewsBoardId equals n.Id
                                 where n.Title.Equals(title.Title)
                                 select c).ToListAsync();

            // Render the partial view in the Index view
            return PartialView("_Select",clients);
        }


        private bool NewsBoardExists(string id)
        {
          return _context.NewsBoards.Any(e => e.Id == id);
        }
    }
}
