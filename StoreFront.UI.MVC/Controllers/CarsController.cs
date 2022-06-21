using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFront.DATA.EF.Models;
using Microsoft.AspNetCore.Authorization;
using StoreFront.UI.MVC.Utilites;
using System.Drawing;
//using X.PagedList;

namespace StoreFront.UI.MVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly StoreFrontContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CarsController(StoreFrontContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Cars
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cars = _context.Cars.Where(p => p.StatusId != 4);
              //.Include(p => p.Make).Include(p => p.Model).Include(p => p.Year).Include(p => p.ExteriorColor).Include(p => p.Miles).Include(p => p.Miles).Include(p => p.VinNumber).Include(p => p.InteriorColor).Include(p => p.Description);
            return View(await cars.ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Discountinued()
        {
            var cars = _context.Cars.Where(p => p.StatusId != 3);

          //.Include(p => p.Make).Include(p => p.Model).Include(p => p.Year).Include(p => p.ExteriorColor).Include(p => p.Miles).Include(p => p.Miles).Include(p => p.VinNumber).Include(p => p.InteriorColor).Include(p => p.Description);
            return View(await cars.ToListAsync());
        }

        public async Task<IActionResult> TiledProducts()
        {

            var cars = _context.Cars.Where(p => p.StatusId != 4);
         //.Include(p => p.Make).Include(p => p.Model).Include(p => p.Year).Include(p => p.ExteriorColor).Include(p => p.Miles).Include(p => p.Miles).Include(p => p.VinNumber).Include(p => p.InteriorColor).Include(p => p.Description);
            return View(await cars.ToListAsync());
        }
        //GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductStatuses == null)
            {
                return NotFound();
            }

            var productStatus = await _context.ProductStatuses
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (productStatus == null)
            {
                return NotFound();
            }

            return View(productStatus);
        }

        // GET: Cars/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
            {
                ViewData["StatusId"] = new SelectList(_context.ProductStatuses, "StatusId", "StatusName");
                ViewData["StyleId"] = new SelectList(_context.BodyStyles, "StyleId", "StyleName");
                return View();
            }

            // POST: Cars/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("CarId,Make,Model,Year,ExteriorColor,Miles,VinNumber,InteriorColor,Description,StatusId,StyleId, ProductImage")] Car car)
            {
                if (ModelState.IsValid)
                {

                #region File Upload - CREATE
                string oldImageName = "noimage.png";
                if (car.Image != null)
                {
                    string ext = Path.GetExtension(car.Image.FileName);
                    string[] validExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    if (validExts.Contains(ext.ToLower()) && car.Image.Length < 4_194_303)
                    {
                        car.ProductImage = Guid.NewGuid() + ext;
                        string webRootPath = _webHostEnvironment.WebRootPath;
                        string fullImagePath = webRootPath + "/images/";



                        using (var memoryStream = new MemoryStream())
                        {
                            await car.Image.CopyToAsync(memoryStream);
                            using (var img = Image.FromStream(memoryStream))
                            {
                                int maxImageSize = 500;
                                int maxThumbSize = 100;
                                ImageUtility.ResizeImage(fullImagePath, car.ProductImage, img, maxImageSize, maxThumbSize);
                            }
                        }
                    }
                }
                else
                {
                    car.ProductImage = "noimage.png";
                }
                #endregion

                _context.Add(car);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["StatusId"] = new SelectList(_context.ProductStatuses, "StatusId", "StatusName", car.StatusId);
                ViewData["StyleId"] = new SelectList(_context.BodyStyles, "StyleId", "StyleName", car.StyleId);
                return View(car);
            }

        // GET: Cars/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null || _context.Cars == null)
                {
                    return NotFound();
                }

                var car = await _context.Cars.FindAsync(id);
                if (car == null)
                {
                    return NotFound();
                }
                ViewData["StatusId"] = new SelectList(_context.ProductStatuses, "StatusId", "StatusName", car.StatusId);
                ViewData["StyleId"] = new SelectList(_context.BodyStyles, "StyleId", "StyleName", car.StyleId);
                return View(car);
            }

            // POST: Cars/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind
         ("CarId,Make,Model,Year,ExteriorColor,Miles,VinNumber,InteriorColor,Description,StatusId,StyleId, ProductImage, Image")] Car car)
            {
                if (id != car.CarId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                #region EDIT File Upload
                //retain old image file name so we can delete if a new file was uploaded
                string oldImageName = car.ProductImage;

                //Check if the user uploaded a file
                if (car.Image != null)
                {
                    //get the file's extension
                    string ext = Path.GetExtension(car.Image.FileName);

                    //list valid extensions
                    string[] validExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //check the file's extension against the list of valid extensions
                    if (validExts.Contains(ext.ToLower()) && car.Image.Length < 4_194_303)
                    {
                        //generate a unique file name
                        car.ProductImage = Guid.NewGuid() + ext;
                        //build our file path to save the image
                        string webRootPath = _webHostEnvironment.WebRootPath;
                        string fullPath = webRootPath + "/images/";

                        //Delete the old image
                        if (oldImageName != "noimage.png")
                        {
                            ImageUtility.Delete(fullPath, oldImageName);
                        }

                        //Save the new image to webroot
                        using (var memoryStream = new MemoryStream())
                        {
                            await car.Image.CopyToAsync(memoryStream);
                            using (var img = Image.FromStream(memoryStream))
                            {
                                int maxImageSize = 500;
                                int maxThumbSize = 100;
                                ImageUtility.ResizeImage(fullPath, car.ProductImage, img, maxImageSize, maxThumbSize);
                            }
                        }

                    }
                }
                #endregion

                try
                {
                        _context.Update(car);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CarExists(car.CarId))
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
                ViewData["StatusId"] = new SelectList(_context.ProductStatuses, "StatusId", "StatusName", car.StatusId);
                ViewData["StyleId"] = new SelectList(_context.BodyStyles, "StyleId", "StyleName", car.StyleId);
                return View(car);
            }

        // GET: Cars/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null || _context.Cars == null)
                {
                    return NotFound();
                }

                var car = await _context.Cars
                    .Include(c => c.Status)
                    .Include(c => c.Style)
                    .FirstOrDefaultAsync(m => m.CarId == id);
                if (car == null)
                {
                    return NotFound();
                }

                return View(car);
            }

            // POST: Cars/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
            {
                if (_context.Cars == null)
                {
                    return Problem("Entity set 'StoreFrontContext.Cars'  is null.");
                }
                var car = await _context.Cars.FindAsync(id);
                if (car != null)
                {
                    _context.Cars.Remove(car);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool CarExists(int id)
            {
                return (_context.Cars?.Any(e => e.CarId == id)).GetValueOrDefault();
            }
        }
    }
