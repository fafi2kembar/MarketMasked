#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarketMasked.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System.Web;  
using PagedList;
using PagedList.Mvc;
using MarketMasked.Models; 

namespace MarketMasked.Controllers
{
    public class NftController : Controller
    {
        private readonly MarketMaskedNftContext _context;

        private readonly IWebHostEnvironment _hostEnvironment;
        public NftController(MarketMaskedNftContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Nft
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            var nft = from m in _context.Nft
                 select m;
            switch (sortOrder)
            {
                case "name_desc":
                    nft = nft.OrderByDescending(s => s.Name);
                    break;
                default:
                    nft = nft.OrderBy(s => s.Name);
                    break;
            }
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                nft = nft.Where(s => s.Name!.Contains(searchString));
            }
            int pageSize = 5;
            return View(await PaginatedList<Nft>.CreateAsync(nft.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Nft/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nft = await _context.Nft
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nft == null)
            {
                return NotFound();
            }

            return View(nft);
        }

        // GET: Nft/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nft/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageFile")] Nft nft)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(nft.ImageFile.FileName);
                string extension = Path.GetExtension(nft.ImageFile.FileName);
                nft.ImageName=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Nftstore/", fileName);
                using (var fileStream = new FileStream(path,FileMode.Create))
                {
                    await nft.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(nft);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nft);
        }

        // GET: Nft/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nft = await _context.Nft.FindAsync(id);
            if (nft == null)
            {
                return NotFound();
            }
            return View(nft);
        }

        // POST: Nft/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageFile")] Nft nft)
        {
            if (id != nft.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     //Save image to wwwroot/image
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string v = Path.GetFileNameWithoutExtension(nft.ImageFile.FileName);
                    string fileName = v;
                    string extension = Path.GetExtension(nft.ImageFile.FileName);
                    nft.ImageName=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Nftstore/", fileName);
                    using (var fileStream = new FileStream(path,FileMode.Create))
                    {
                        await nft.ImageFile.CopyToAsync(fileStream);
                    }

                    _context.Update(nft);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NftExists(nft.Id))
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
            return View(nft);
        }

        // GET: Nft/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nft = await _context.Nft
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nft == null)
            {
                return NotFound();
            }

            return View(nft);
        }

        // POST: Nft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nft = await _context.Nft.FindAsync(id);
            //delete image from wwwroot/image
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath,"nftstore",nft.ImageName);
            if (System.IO.File.Exists(imagePath))
            System.IO.File.Delete(imagePath);
            //delete the record
            _context.Nft.Remove(nft);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NftExists(int id)
        {
            return _context.Nft.Any(e => e.Id == id);
        }
    }
}
