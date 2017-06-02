using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer
{
    interface IOperations<T> where T : class
    {
        IQueryable<T> GetAll();   //
        T GetById(int id);
        T FindBy(Expression<Func<T, bool>> Condition);
        T Add(T Entity);
        bool AddRange(List<T> Entities);   
        bool Delete(int id);
        bool DeleteEntity(T EntityToDelete);
        bool Update(T EntityToUpdate);
        void Save();
        int Count();

        DbSqlQuery<T> QueryData(string SP, SqlParameter[] Params);
    }
}



// IQueryable bring only filtered data from server to the client ; 
// IEnumerable bring all data from server to clint (High-performance); 