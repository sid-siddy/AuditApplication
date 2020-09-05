using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuditManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly ILogger<PortfolioController> _logger;
        private IDataAccess<AuditClientPortfolio> ctx;
        public PortfolioController(ILogger<PortfolioController> logger, IDataAccess<AuditClientPortfolio> dataAccess)
        {
            _logger = logger;
            ctx = dataAccess;
        }
        [HttpGet]
        public IEnumerable<AuditClientPortfolio> GetAuditors()
        {
            return ctx.GetAll();
        }
        [HttpPost]
        public void PostAuditors(AuditClientPortfolio a)
        {
            ctx.Insert(a);
        }
        [HttpPut]
        public void updateAuditors(AuditClientPortfolio b)
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
