using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Planner.Models;

namespace Planner.Controllers
{
    public class PlansController : Controller
    {
        private readonly PlannerContext _context;

        public PlansController(PlannerContext context)
        {
            _context = context;
        }

        // GET: plans
        public async Task<IActionResult> Index(string planTheme, string searchString, string sortOrder)
        {

            //test sort
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            
            


            // Use LINQ to get list of themes.
            IQueryable<string> themeQuery = from m in _context.Plan
                                            orderby m.Theme
                                            select m.Theme;

            var plans = from m in _context.Plan
                        select m;


            if (!string.IsNullOrEmpty(searchString))
            {
                plans = plans.Where(s => s.Theme.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(planTheme))
            {
                plans = plans.Where(x => x.Theme == planTheme);
            }

            var planThemeVM = new ThemeViewModel
            {
                Themes = new SelectList(await themeQuery.Distinct().ToListAsync()),
                Plans = await plans.ToListAsync()

            };

            return View(planThemeVM);
            


        }

        // GET: plans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // GET: plans/Create
        public IActionResult Create()
        {
            return View(new Plan
            {
                
                Date = DateTime.Now,
                
            }
                );
        }

        // POST: plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Theme,OpeningSong,OpeningPrayer,Conducting,SacramentHymn,Speaker1,TalkTopic1,Speaker2,TalkTopic2,ClosingSong,ClosingPrayer")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }

        // GET: plans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            return View(plan);
        }

        // POST: plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Theme,OpeningSong,OpeningPrayer,Conducting,SacramentHymn,Speaker1,TalkTopic1,Speaker2,TalkTopic2,ClosingSong,ClosingPrayer")] Plan plan)
        {
            if (id != plan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!planExists(plan.Id))
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
            return View(plan);
        }

        // GET: plans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // POST: plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plan = await _context.Plan.FindAsync(id);
            _context.Plan.Remove(plan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool planExists(int id)
        {
            return _context.Plan.Any(e => e.Id == id);
        }
    }
}
