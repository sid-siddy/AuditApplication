using AuditManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagement.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class AuditController : ControllerBase
    {
        private readonly ILogger<AuditController> _logger;
        private IDataAccess<Auditors> ctx;
        //public AuditController()
        //{
        //    this.ctx = new DataAccessRepository<Auditors>();
        //}
        public AuditController(ILogger<AuditController> logger, IDataAccess<Auditors> dataAccess)
        {
            _logger = logger;
            ctx = dataAccess;
        }
        [Authorize]
        [HttpGet]
        public IEnumerable<Auditors> GetAuditors()
        {
          return ctx.GetAll();
        }
        [HttpPost]
        public void PostAuditors(Auditors a)
        {
             ctx.Insert(a);
        }
        [HttpPut]
        public void updateAuditors( Auditors b)
        {
           ctx.Update(b);
        }
        [HttpDelete]
        public void DeleteAuditor(int Id)
        {
            ctx.Delete(Id);
        }
    }
}
