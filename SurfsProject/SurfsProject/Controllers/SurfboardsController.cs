using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurfsProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurfsProject.Data;
using SurfsProject.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace SurfsProject.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SurfboardsController : Controller
    {
        private readonly SurfsProjectContext _context;

        public SurfboardsController(SurfsProjectContext context)
        {
            _context = context;
        }

        // GET: Surfboards
        public async Task<IActionResult> Index(
             string sortOrder,
             string currentFilter,
             string searchString,
             int? pageNumber)
        {
            //add Volume, Type, Price, Equipment here
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewData["LengthSortParm"] = sortOrder == "Length" ? "Length_desc" : "Length";
            ViewData["WidthSortParm"] = sortOrder == "Width" ? "Width_desc" : "Width";
            ViewData["ThicknessSortParm"] = sortOrder == "Thickness" ? "Thickness_desc" : "Thickness";
            ViewData["VolumeSortParm"] = sortOrder == "Volume" ? "Volume_desc" : "Volume";
            ViewData["TypeSortParm"] = sortOrder == "Type" ? "Type_desc" : "Type";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "Price_desc" : "Price";
            ViewData["EquipmentSortParm"] = sortOrder == "Equipment" ? "Equipment_desc" : "Equipment";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;  

            var surfboards = from s in _context.Surfboard
                             select s;
            //if (!String.IsNullOrEmpty(searchString))
            {
                //add Length, Width, Volume, Type, Price, Equipment
                //surfboards = surfboards.Where(s => s.Name.Contains(searchString)); 
                                            //|| Length.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name":
                    surfboards = surfboards.OrderBy(s => s.Name);
                break;  
                case "Name_desc":
                    surfboards = surfboards.OrderByDescending(s => s.Name);
                    break;
                case "Length":
                    surfboards = surfboards.OrderBy(s => s.Length);
                    break;
                case "Length_desc":
                    surfboards = surfboards.OrderByDescending(s => s.Length);
                    break;
                case "Width":
                    surfboards = surfboards.OrderBy(s => s.Width);
                    break;
                case "Width_desc":
                    surfboards = surfboards.OrderByDescending(s => s.Width);
                    break;
                case "Thickness":
                    surfboards = surfboards.OrderBy(s => s.Thickness);
                    break;
                case "Thickness_desc":
                    surfboards = surfboards.OrderByDescending(s => s.Thickness);
                    break;
                case "Volume":
                    surfboards = surfboards.OrderBy(s => s.Volume);
                    break;
                case "Volume_desc":
                    surfboards = surfboards.OrderByDescending(s => s.Volume);
                    break;
                case "Type":
                    surfboards = surfboards.OrderBy(s => s.Type);
                    break;
                case "Type_desc":
                    surfboards = surfboards.OrderByDescending(s => s.Type);
                    break;
                case "Price":
                    surfboards = surfboards.OrderBy(s => s.Price);
                    break;
                case "Price_desc":
                    surfboards = surfboards.OrderByDescending(s => s.Price);
                    break;
                case "Euqipment":
                    surfboards = surfboards.OrderBy(s => s.Equipment);
                    break;
                case "Equipment_desc":
                    surfboards = surfboards.OrderByDescending(s => s.Equipment);
                    break;

            }

            int pageSize = 5;
            return View(await PaginatedList<Surfboard>.CreateAsync(surfboards.AsNoTracking(), pageNumber ?? 1 , pageSize));

            
    }
            // GET: Surfboards/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Surfboard == null)
            {
                return NotFound();
            }

            var surfboard = await _context.Surfboard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surfboard == null)
            {
                return NotFound();
            }

            return View(surfboard);
        }

        // GET: Surfboards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Surfboards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Length,Width,Thickness,Volume,Type,Price,Equipment")] Surfboard surfboard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surfboard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(surfboard);
        }

        // GET: Surfboards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Surfboard == null)
            {
                return NotFound();
            }

            var surfboard = await _context.Surfboard.FindAsync(id);
            if (surfboard == null)
            {
                return NotFound();
            }
            return View(surfboard);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Length,Width,Thickness,Volume,Type,Price,Equipment")] Surfboard surfboard, byte[] rowVersion)
        //{
        //    if (id != surfboard.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(surfboard);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SurfboardExists(surfboard.Id))
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
        //    return View(surfboard);
        //}

        //// POST: Surfboards/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Length,Width,Thickness,Volume,Type,Price,Equipment")] Surfboard surfboard, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surfboardToUpdate = await _context.Surfboard.FirstOrDefaultAsync(s => s.Id == id);

            if (surfboardToUpdate == null)
            {
                Surfboard deletedSurfboard = new Surfboard();
                await TryUpdateModelAsync(deletedSurfboard);
                ModelState.AddModelError(string.Empty,
                    "Unable to save changes. The department was deleted by another user.");
              
                
                return View(deletedSurfboard);
            }

            _context.Entry(surfboardToUpdate).Property("RowVersion").OriginalValue = rowVersion;

            if (await TryUpdateModelAsync<Surfboard>(
                surfboardToUpdate,
                "",
                s => s.Name, s => s.Length, s => s.Width, s => s.Thickness, s=> s.Volume, s=>s.Type, s=> s.Price, s => s.Equipment, s => s.RowVersion))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Surfboard)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                            "Unable to save changes. The department was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Surfboard)databaseEntry.ToObject();

                        if (databaseValues.Name != clientValues.Name)
                        {
                            ModelState.AddModelError("Name", $"Current value: {databaseValues.Name}");
                        }
                        if (databaseValues.Length != clientValues.Length)
                        {
                            ModelState.AddModelError("Length", $"Current value: {databaseValues.Length:c}");
                        }
                        if (databaseValues.Width != clientValues.Width)
                        {
                            ModelState.AddModelError("Width", $"Current value: {databaseValues.Width:d}");
                        }
                        if (databaseValues.Thickness != clientValues.Thickness)
                        {
                            ModelState.AddModelError("Thickness", $"Current value: {databaseValues.Thickness}");
                        }

                        if (databaseValues.Volume != clientValues.Volume)
                        {
                            ModelState.AddModelError("Volume", $"Current value: {databaseValues.Volume}");
                        }

                        if (databaseValues.Type != clientValues.Type)
                        {
                            ModelState.AddModelError("Type", $"Current value: {databaseValues.Type}");
                        }

                        if (databaseValues.Price != clientValues.Price)
                        {
                            ModelState.AddModelError("Price", $"Current value: {databaseValues.Price}");
                        }

                        if (databaseValues.Equipment != clientValues.Equipment)
                        {
                            ModelState.AddModelError("Equipment", $"Current value: {databaseValues.Equipment}");
                        }

                        if (databaseValues.RowVersion != clientValues.RowVersion)
                        {
                            ModelState.AddModelError("RowVersion", $"Current value: {databaseValues.RowVersion}");
                        }

                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was modified by another user after you got the original value. The "
                                + "edit operation was canceled and the current values in the database "
                                + "have been displayed. If you still want to edit this record, click "
                                + "the Save button again. Otherwise click the Back to List hyperlink.");
                        surfboardToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
            //ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", departmentToUpdate.InstructorID);
            return View(surfboardToUpdate);
        }

        // GET: Surfboards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Surfboard == null)
            {
                return NotFound();
            }

            var surfboard = await _context.Surfboard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surfboard == null)
            {
                return NotFound();
            }

            return View(surfboard);
        }

        // POST: Surfboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Surfboard == null)
            {
                return Problem("Entity set 'SurfsProjectContext.Surfboard'  is null.");
            }
            var surfboard = await _context.Surfboard.FindAsync(id);
            if (surfboard != null)
            {
                _context.Surfboard.Remove(surfboard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurfboardExists(int id)
        {
          return (_context.Surfboard?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
