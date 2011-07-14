using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rrraaawwrrr.Services
{
    public interface IHeroService
    {
        Tuple<Models.Hero, Models.HeroAttributes> CreateHero(Models.Hero newHero, Models.HeroAttributes newAttributes);
        Tuple<Models.Hero, Models.HeroAttributes> EditHero(Models.Hero newHero, Models.HeroAttributes newAttributes);
        Models.Hero GetHero(int id);
        Models.HeroAttributes GetHeroAttributes(int id);
    }

    public class HeroService : IHeroService
    {
        private Models.DungeonDataContainer _container;

        public HeroService()
        {
            _container = new Models.DungeonDataContainer();
        }

        public Tuple<Models.Hero, Models.HeroAttributes> CreateHero(Models.Hero newHero, Models.HeroAttributes newAttributes)
        {
            newHero.HeroAttribute = newAttributes;
            _container.Heroes.AddObject(newHero);
            _container.HeroAttributes.AddObject(newAttributes);
            _container.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            return (new Tuple<Models.Hero, Models.HeroAttributes>(newHero, newAttributes));
        }

        public Models.Hero GetHero(int id)
        {
            Models.Hero hero;
            hero = new Models.Hero();
            hero.HeroId = id;
            hero.EntityKey = _container.CreateEntityKey("Heroes", hero);
            hero = (Models.Hero)_container.GetObjectByKey(hero.EntityKey);
            return (hero);
        }

        public Models.HeroAttributes GetHeroAttributes(int id)
        {
            Models.HeroAttributes heroattributes;
            heroattributes = new Models.HeroAttributes();
            heroattributes.HeroId = id;
            heroattributes.EntityKey = _container.CreateEntityKey("HeroAttributes", heroattributes);
            heroattributes = (Models.HeroAttributes)_container.GetObjectByKey(heroattributes.EntityKey);
            return (heroattributes);
        }

        public Tuple<Models.Hero, Models.HeroAttributes> EditHero(Models.Hero editHero, Models.HeroAttributes editAttributes)
        {
            _container.Heroes.AddObject(editHero);
            _container.HeroAttributes.AddObject(editAttributes);
            _container.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            return (new Tuple<Models.Hero, Models.HeroAttributes>(editHero, editAttributes));
        }
    }
}