using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurfsProject.Data;
using SurfsProject.Models;

namespace SurfsProject.Controllers
{
    public class ViewUserController : Controller
    {
        private readonly SurfsProjectContext _context;

        public ViewUserController(SurfsProjectContext context)
        {
            _context = context;
        }

        // GET: ViewUser
        public async Task<IActionResult> Index(
             string sortOrder,
             string currentFilter,
             string searchString,
             int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["TypeSortParm"] = sortOrder == "Type" ? "Type_desc" : "Type";
            ViewData["LengthSortParm"] = sortOrder == "Length" ? "Length_desc" : "Length";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var Surfboard = from s in _context.Surfboard
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            { 
                 Surfboard.Where(s => s.Equipment.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    Surfboard = Surfboard.OrderByDescending(s => s.Name);
                    break;
                case "Type_desc":
                    Surfboard = Surfboard.OrderByDescending(s => s.Type);
                    break;
                case "Type":
                    Surfboard = Surfboard.OrderBy(s => s.Type);
                    break;
                case "Length_desc":
                    Surfboard = Surfboard.OrderByDescending(s => s.Length);
                    break;
                case "Length":

                    Surfboard = Surfboard.OrderBy(s => s.Length);
                    break;
                default:
                    Surfboard = Surfboard.OrderBy(s => s.Name);
                    break;

            }
            Surfboard = Surfboard.OrderBy(s => s.Name);

            int pageSize = 5;
            return View(await PaginatedList<Surfboard>.CreateAsync(Surfboard.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: ViewUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Surfboard == null)
            {
                return NotFound();
            }

            var board = await _context.Surfboard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        


        // GET: ViewUser/Edit/5
        public async Task<IActionResult> Rent(int? id)
        {
            
            if (id == null || _context.Surfboard == null)
            {
                return NotFound();
            }

            var Surfboard = await _context.Surfboard.FindAsync(id);
            if (Surfboard == null)
            {
                return NotFound();
            }
            else  
                    {
                Surfboard.Reserved= true;
                        _context.SaveChanges();
                    }
            return RedirectToAction(nameof(Index));

        }

        


        // POST: ViewUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Rent(int id, [Bind("ID, Reserved")] Board board)
        //{
        //    if (id != board.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(board);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BoardExists(board.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(board);
        //}
        private bool BoardExists(int id)
        {
            return (_context.Surfboard?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
