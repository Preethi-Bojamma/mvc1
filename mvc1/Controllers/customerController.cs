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
    [Authorize]
    public class customerController : Controller
    {
     
        private ApplicationDbContext dbContext = null;
        public customerController()
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
        
        [AllowAnonymous]
        // GET: customer
        public ActionResult Index()
        {
            var customers = dbContext.Customers.Include(z=>z.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult CDisplay()
        {
            MovieCustomerViewModel mcvm = new MovieCustomerViewModel();
            customer c = new customer { CName = "Surya" };
            List<MovieB> movie = new List<MovieB>
            {
                new MovieB{Name="Kappan"},
                new MovieB{Name="Theri"},
                new MovieB{Name="Matilda"},
                new MovieB{Name="Aashique"},
            };
            mcvm.cm = c;
            mcvm.mb = movie;
            return View(mcvm);
        }

        public ActionResult Details(int id)
        {
            var c1 = dbContext.Customers.Include(c=>c.MembershipType).ToList().SingleOrDefault(a => a.ID == id);
            return View(c1);
        }
   


        public List<customer> GetCustomer()
        {
            List<customer> c1 = new List<customer>
            {
                new customer{ID=1,CName="Preethi",BirthDate=Convert.ToDateTime("01/01/2000"),Gender="Female"},
                  new customer{ID=2,CName="Sajan",BirthDate=Convert.ToDateTime("10/12/1995"),Gender="Male"},
                    new customer{ID=3,CName="Prajwal",BirthDate=Convert.ToDateTime("27/03/2000"),Gender="Male"},
            };
            return (c1);

        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var ctm = new customer();
            ViewBag.Gender = ListGender();
            ViewBag.MembershipTypeId = ListMembership();
            return View(ctm);

        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ctm =dbContext.Customers.SingleOrDefault(c=>c.ID==id);
            if (ctm != null)
            {
                ViewBag.Gender = ListGender();
                ViewBag.MembershipTypeId = ListMembership();
                return View(ctm);
            }
            else
            return HttpNotFound("Customer Not Found");

        }



        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult EditCustomer(customer customerFromView)
        {
            if (ModelState.IsValid)
            {
                var customerInDB = dbContext.Customers.FirstOrDefault(c => c.ID == customerFromView.ID);
                customerInDB.CName = customerFromView.CName;
                customerInDB.City = customerFromView.City;
                customerInDB.Gender = customerFromView.Gender;
                customerInDB.BirthDate = customerFromView.BirthDate;
                customerInDB.MembershipTypeId = customerFromView.MembershipTypeId;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "customer");
            }
            else
            {
                ViewBag.Gender = ListGender();
                ViewBag.MembershipTypeId = ListMembership();
                return View(customerFromView);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var ctm = dbContext.Customers.SingleOrDefault(c => c.ID == id);
            if (ctm != null)
            {
                ViewBag.Gender = ListGender();
                ViewBag.MembershipTypeId = ListMembership();
                return View(ctm);
            }
            else
                return HttpNotFound("Customer Not Found");

        }



        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Delete(customer customerFromView)
        {
            
                var customerInDB = dbContext.Customers.FirstOrDefault(c => c.ID == customerFromView.ID);
                dbContext.Customers.Remove(customerInDB );
                dbContext.SaveChanges();
                return RedirectToAction("Index", "customer");
            
        }


        public IEnumerable<SelectListItem> ListGender()
        {
            var gender = new List<SelectListItem>
            {
                new SelectListItem{Text="Select a gender",Value="0",Disabled=true,Selected=true},
                new SelectListItem{Text="Male",Value="1" },
                new SelectListItem{Text="Female",Value="2" },
                new SelectListItem{Text="Others",Value="3" },
            };
            return gender;
        }

        [NonAction]
        public IEnumerable<SelectListItem> ListMembership()
        {
            //var membership = (from m in dbContext.membershiptypes.AsEnumerable()
            //                  select new SelectListItem
            //                  {
            //                      Text = m.Type,
            //                      Value = m.Id.ToString()
            //                  }).ToList();

            //membership.Insert(0, new SelectListItem { Text = "---Select---", Value = "0" });
            var mship = dbContext.membershiptypes.AsEnumerable().Select(m => new SelectListItem() { Text = m.Type, Value = m.Id.ToString() }).ToList();
            mship.Insert(0, new SelectListItem { Text = "---Select---", Value = "0",Disabled=true,Selected=true});
            return mship;
        }


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(customer customerFromView)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Gender = ListGender();
                ViewBag.MembershipTypeId = ListMembership();
                return View(customerFromView);
            }
            dbContext.Customers.Add(customerFromView);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "customer");

        }
    }
}