﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using TravelBlogs.DAL.EF;
using TravelBlogs.DAL.Entities;
using TravelBlogs.DAL.Interfaces;

namespace TravelBlogs.DAL.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private BlogContext db;

        public PlaceRepository(BlogContext context)
        {
            db = context;
        }


        // Реализуем интерфейс

        public IEnumerable<Place> GetAll()
        {
            return db.Places;
        }

        public Place Get(int id)
        {
            return db.Places.Find(id);
        }

        public IQueryable<Place> Find(Expression<Func<Place, bool>> predicate)
        {
            return db.Places.Where(predicate);
        }

        public void Create(Place item)
        {
            db.Places.Add(item);
        }

        public void Update(Place item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Place place = db.Places.Find(id);
            if (place != null)
            {
                db.Places.Remove(place);
            }
        }


        public IQueryable<Place> GetPlaces(int regionId)
        {
            return db.Places.Where(p => p.RegionId == regionId);
        }
   
    }
}
