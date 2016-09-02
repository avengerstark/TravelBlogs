﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using TravelBlogs.DAL.EF;
using TravelBlogs.DAL.Entities;
using TravelBlogs.DAL.Interfaces;

namespace TravelBlogs.DAL.Repositories
{
    public class RegionRepository : IRegionRepository
    {

        private BlogContext db;

        public RegionRepository(BlogContext context)
        {
            db = context;
        }


         // Реализуем интерфейс

        public IEnumerable<Region> GetAll()
        {
            return db.Regions;
        }

        public Region Get(int id)
        {
            return db.Regions.Find(id);
        }

        public IEnumerable<Region> Find(Func<Region, bool> predicate)
        {
            return db.Regions.Where(predicate).ToList();
        }

        public void Create(Region item)
        {
            db.Regions.Add(item);
        }

        public void Update(Region item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Region region = db.Regions.Find();
            if (region != null)
            {
                db.Regions.Remove(region);
            }
        }



        public IEnumerable<Place> GetPlaces(int regionId)
        {
            return db.Places.Where(p => p.RegionId == regionId).ToList();
        }

    }
}