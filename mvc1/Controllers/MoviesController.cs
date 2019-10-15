using mvc1.Models;
using mvc1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace mvc1.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext dbContext = null;
        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
           if(disposing)
            {
                dbContext.Dispose();
            }
        }
        // GET: Movies
        public ActionResult Index()
        {
            var mb = dbContext.movies.Include(z => z.Genre).ToList();
            return View(mb);
        }
        public ActionResult Display()
        {
            CustomerMovieViewModel viewModel = new CustomerMovieViewModel();
            MovieB mv = new MovieB { Name = "kappan" };
            List<customer> customers = new List<customer>
            {
                new customer{CName="Preethi"},
                 new customer{CName="Sajan"},
                  new customer{CName="Prajwal"},
                   new customer{CName="Manu"},
            };
            viewModel.Movie = mv;
            viewModel.Customers = customers;
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var mb = dbContext.movies.Include(z => z.Genre).ToList().SingleOrDefault(a=>a.ID==id);
            return View(mb);
        }
        public List<MovieB> GetMovie()
        {
            List<MovieB> mb = new List<MovieB>
            {
            new MovieB{ ID=1, Name="Kappan", ReleaseDate=Convert.ToDateTime("20/10/2019")/*, Genre="Action"*/ },
            new MovieB{ ID=2, Name="Theri", ReleaseDate=Convert.ToDateTime("15/09/2018")/*, Genre="Family"*/ },
            new MovieB{ ID=3, Name="Samar", ReleaseDate=Convert.ToDateTime("10/08/2014")/*, Genre="Thriller" */}
            };
            return (mb);
        }

        [HttpGet]
        public ActionResult Create()
        {
           ViewBag.GenreId= ListGenre();
            return View();
        }

        [HttpPost]
        public ActionResult Create(MovieB moviebFromView)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.GenreId = ListGenre();
                return View(moviebFromView);
            }
            
               
            dbContext.movies.Add(moviebFromView);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [NonAction]
        public IEnumerable<SelectListItem> ListGenre()
        {
          
            var gen= dbContext.genres.AsEnumerable().Select(m => new SelectListItem() { Text = m.Name, Value = m.Id.ToString() }).ToList();
            gen.Insert(0, new SelectListItem { Text = "---Select---", Value = "0", Disabled = true, Selected = true });
            return gen;
        }
    }
}