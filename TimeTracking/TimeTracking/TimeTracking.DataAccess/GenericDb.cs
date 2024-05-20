﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.DataAccess.Interfaces;
using TimeTracking.Domain.Models;

namespace TimeTracking.DataAccess
{
    public class GenericDb<T> : IGenericDb<T> where T : BaseEntity
    {
        public int IdCounter { get; set; }
        private List<T> _db;

        public GenericDb()
        {
            _db = new List<T>();
            IdCounter = 1;
        }
        public int Add(T entity)
        {
            entity.Id = IdCounter++;
            _db.Add(entity);

            return entity.Id;
        }

        public List<T> GetAll()
        {
            return _db;
        }

        public T GetById(int id)
        {
     
            return _db.FirstOrDefault(x => x.Id == id);
        }

        public bool RemoveById(int id)
        {
            try
            {
                T entity = GetById(id);
                _db.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                T dbEntity = GetById(entity.Id);
                dbEntity = entity;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<T> FilterBy(Func<T, bool> filterCondition)
        {
            return _db.Where(filterCondition).ToList();
        }
    }
}
