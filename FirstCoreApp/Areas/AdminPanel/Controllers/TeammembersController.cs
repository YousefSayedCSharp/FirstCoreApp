using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstCoreApp.Models;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace FirstCoreApp.Controllers
{
    [Authorize(Roles ="SuperAdmin")]
    [Area("AdminPanel")]
    public class TeammembersController : Controller
    {
        private readonly NewsContext _context;
        private readonly IHostEnvironment _host;

        public TeammembersController(
            NewsContext context,
            IHostEnvironment host
            )
        {
            _context = context;
            this._host = host;
        }

        // GET: Teammembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teammembers.ToListAsync());
        }

        // GET: Teammembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teammember = await _context.Teammembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teammember == null)
            {
                return NotFound();
            }

            return View(teammember);
        }

        // GET: Teammembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teammembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teammember teammember)
        {
            if (ModelState.IsValid)
            {
                UploadPhoto(teammember);
                _context.Add(teammember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teammember);
        }

        // GET: Teammembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teammember = await _context.Teammembers.FindAsync(id);
            if (teammember == null)
            {
                return NotFound();
            }
            return View(teammember);
        }

        // POST: Teammembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Teammember teammember)
        {
            if (id != teammember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UploadPhoto(teammember);
                    _context.Update(teammember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeammemberExists(teammember.Id))
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
            return View(teammember);
        }

        // GET: Teammembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teammember = await _context.Teammembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teammember == null)
            {
                return NotFound();
            }

            return View(teammember);
        }

        // POST: Teammembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teammember = await _context.Teammembers.FindAsync(id);
            _context.Teammembers.Remove(teammember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeammemberExists(int id)
        {
            return _context.Teammembers.Any(e => e.Id == id);
        }

        public void UploadPhoto(Teammember model)
        {
            if (model.File != null)
            {
                string uploadsFolder = Path.Combine(_host.ContentRootPath, "wwwroot/Images/Teammembers");
                string uniqueFileName = Guid.NewGuid() + Path.GetExtension(model.File.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                model.File.CopyTo(new FileStream(filePath, FileMode.Create));

                model.Image = uniqueFileName;
            }//end if
        }// end function 
    }
}
