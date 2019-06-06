using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        // GET: /<controller>/

        public ItemController(ApplicationDbContext context)
        {
            _context = context;

        }

        // return View("Index", _context.Items.ToList<Item>());
        public IActionResult Index()
        {
            return View("Index", _context.Items.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        //_context.Add<Item>(item);
        [HttpPost]
        public IActionResult Create(Item item)
        {

            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // seems like this'd be slow
        //_context.Items.Remove(_context.Items.Find(Id));
        //Item item = (Item)_context.Items.Where<Item>(i => i.Id == Id);
        public IActionResult Delete(int id)
        {

            Item item = (Item)_context.Items.FirstOrDefault(i => i.Id == id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
