using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace Rrraaawwrrr.Controllers
{
    public class HeroController : Controller
    {

        private Services.IHeroService _heroService;

        public static void InitializeRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "HeroRouteDetail", // Route name
                "HeroDetail/{id}", // URL with parameters
                new { controller = "Hero", action = "Details" }, // Parameter defaults
                new { id = @"\d+" }
            );
            routes.MapRoute(
                "HeroRouteEdit", // Route name
                "HeroEdit/{id}", // URL with parameters
                new { controller = "Hero", action = "Details" }, // Parameter defaults
                new { id = @"\d+" }
            );
        }

        protected override void Initialize(RequestContext requestContext)
        {
            if (_heroService == null) { _heroService = new Services.HeroService(); }
            base.Initialize(requestContext);
        }

        //
        // GET: /Hero/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /HeroDetail/5
        public ActionResult Details(int id)
        {
            Tuple<Models.Hero, Models.HeroAttributes> detailsHero;
            Models.Hero currentHero;
            Models.HeroAttributes currentAttributes;
            currentHero = _heroService.GetHero(id);
            currentAttributes = _heroService.GetHeroAttributes(id);
            detailsHero = new Tuple<Models.Hero, Models.HeroAttributes>(currentHero, currentAttributes);
            return View(detailsHero);
        }

        //
        // GET: /Hero/Create
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> heroClasses;
            Tuple<Models.Hero, Models.HeroAttributes> createHero;
            Models.Hero newHero = new Models.Hero();
            Models.HeroAttributes newAttributes = new Models.HeroAttributes();
            newHero.HeroName = "Noob Noob";
            createHero = new Tuple<Models.Hero, Models.HeroAttributes>(newHero,newAttributes);
            heroClasses = new List<SelectListItem>();
            heroClasses.Add(new SelectListItem() { Text = "Peasant", Value = "Peasant" });
            heroClasses.Add(new SelectListItem() { Text = "Vagrant", Value = "Vagrant" });
            heroClasses.Add(new SelectListItem() { Text = "Warrior", Value = "Warrior" });
            ViewData["HeroClasses"] = heroClasses;
            return View(createHero);
        }

        [HttpPost]
        public ActionResult Create(FormCollection values)
        {
            Tuple<Models.Hero, Models.HeroAttributes> createHero;
            Models.Hero newHero;
            Models.HeroAttributes newAttributes;
            newHero = new Models.Hero()
            {
                HeroName = values["Item1.HeroName"],
                HeroId = int.Parse(values["Item1.HeroId"]),
                Class = values["Item1.Class"],
                Description = values["Item1.Description"],
            };
            newAttributes = new Models.HeroAttributes()
            {
                HeroId = int.Parse(values["Item1.HeroId"]),
                Life = int.Parse(values["Item2.Life"]),
                Strength = int.Parse(values["Item2.Strength"]),
                Agility = int.Parse(values["Item2.Agility"]),
                Intelligence = int.Parse(values["Item2.Intelligence"]),
                Wisdom = int.Parse(values["Item2.Wisdom"]),
                Charm = int.Parse(values["Item2.Charm"])
            };
            createHero = _heroService.CreateHero(newHero, newAttributes);

            if (ModelState.IsValid)            
            {
                RouteValueDictionary heroRouteValues = new RouteValueDictionary();
                heroRouteValues.Add("id", createHero.Item1.HeroId);
                return RedirectToRoute("HeroRouteDetail", heroRouteValues);
            }
            return View(values);
        }

        //
        // GET: /HeroDetail/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: /Hero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection values)
        {
            /*
            if (ModelState.IsValid)
            {
                RouteValueDictionary heroRouteValues = new RouteValueDictionary();
                edithero = _heroService.EditHero(
                    values.HeroId,
                    values.Description,

                    );
                heroRouteValues.Add("action", "Details");
                heroRouteValues.Add("id", newhero.HeroId);
                return RedirectToRoute("HeroRoute", heroRouteValues);
            }
            return View(values);
             */
            return View();
        }

        //
        // GET: /Hero/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Hero/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
