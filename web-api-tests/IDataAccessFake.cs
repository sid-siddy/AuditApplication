using AuditManagement;
using AuditManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_api_tests
{
    class IDataAccessFake : IDataAccess<Auditors>
    {
        private readonly List<Auditors> _auditors;

        public IDataAccessFake()
        {
            _auditors = new List<Auditors>()
            {
                new Auditors() { Id = 1, Name = "Siddhartha", Password="abc", City = "Hyderabad" },
                new Auditors() { Id = 2, Name = "Abhishek", Password="abhi", City = "Chennai" }
            };
        }
        public IEnumerable<Auditors> GetAll()
        {
            return _auditors;
        }
        public Auditors GetById(object id)
        {
            return _auditors.Where(x=> x.Id == (int)id).FirstOrDefault();
        }
        public void Insert(Auditors a)
        {
            //return _auditors.Add(); Where(x => x.Id == (int)id).FirstOrDefault();
        }
        public void Update(Auditors b)
        {
          //  ctx.Update(b);
        }
        public void Delete(object Id)
        {
            var existing = _auditors.First(x => x.Id == (int)Id);
            _auditors.Remove(existing);
           // ctx.Delete(Id);
        }
    }
}
