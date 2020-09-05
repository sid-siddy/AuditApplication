using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagement
{
     public interface IDataAccess<T> where T : class
     {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        // void Save();
        //IEnumerable<T> GetAuditors();
        //T GetAuditor(U id);
        //int AddAuditor(T b);
        //int UpdateAuditor(U id, T b);
        //int DeleteAuditor(U id);
    }
}
