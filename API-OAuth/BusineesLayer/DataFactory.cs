using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Models;
using System.Data.Entity;


namespace BusineesLayer
{
   public class DataFactory<C,T> : IOperations<T>
        where T : class
        where C : DataBaseCTX, new()  // It must be a class (reference type) and must have a public parameter-less default constructor.
    {

        private C _Data = new C();

        public C _pdata
        {
            get { return _Data; }
            set { _Data = value; }
        }

        public T Add(T Entity)
        {
            T ReturnObj = null;
            _Data.Set<T>().Add(Entity);
            if (_Data.SaveChanges() > 0)
            {
                ReturnObj = Entity;
            }
            return ReturnObj; 
        }

        public bool AddRange(List<T> Entities)
        {
            bool Flag = false;
            _Data.Set<T>().AddRange(Entities);
            if (_Data.SaveChanges() > 0)
            {
                Flag = true;
            }
            return Flag;
        }

        public int Count()
        {
            return _Data.Set<T>().Count();
        }

        public bool Delete(int id)
        {
            bool DFlag = false;
            T Obj = _Data.Set<T>().Find(id);
            _Data.Entry(Obj).State = EntityState.Deleted;
            if (_Data.SaveChanges()>0)
            {
                DFlag = true;
            }
            return DFlag; 
        }

        public bool Delete(T EntityToDelete)
        {
            bool DFalgo = false; 
            if (EntityToDelete != null)
            {
                _Data.Entry(EntityToDelete).State = EntityState.Deleted;
                if (_Data.SaveChanges() > 0 )
                {
                    DFalgo = true;
                }
            }
            return DFalgo; 
        }

        public bool DeleteEntity(T EntityToDelete)
        {
            throw new NotImplementedException();
        }

        public T FindBy(Expression<Func<T, bool>> Condition)
        {
            T query = _Data.Set<T>().Where(Condition).Single();
            return query;
        }


        public IQueryable<T> FindListBy(Expression<Func<T, bool>> Condition) //FindBy(x => x.Some.Equals(somevlue))
        {
            IQueryable<T> query = _Data.Set<T>().Where(Condition);
            return query;
        }


        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _Data.Set<T>();
            return query;
        }

        public T GetById(int id)
        {
            return _Data.Set<T>().Find(id);
        }

        public void Save()
        {
            _Data.SaveChanges();
        }

        public bool Update(T EntityToUpdate)
        {
            bool result = false;
            _Data.Entry(EntityToUpdate).State = EntityState.Modified; 
            if (_Data.SaveChanges() > 0)
            {
                result = true;
            }

            return result;
        }
    }
}
