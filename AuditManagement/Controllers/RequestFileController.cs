using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuditManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AuditManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestFileController : ControllerBase
    {
        private readonly ILogger<RequestFileController> _logger;
        private IDataAccess<AuditRequest> ctx;
        QueueClient queueClient;
        public RequestFileController(ILogger<RequestFileController> logger, IDataAccess<AuditRequest> dataAccess)
        {
            _logger = logger;
            ctx = dataAccess;
        }
        [HttpGet]
        public IEnumerable<AuditRequest> GetRequests()
        {
            return ctx.GetAll();
        }
        [HttpPost]
        public void PostRequests(AuditRequest a)
        {
            ctx.Insert(a);
            Addrequesttotheclient(a);
        }
        [HttpPut]
        public void PutRequests(AuditRequest b)
        {
            ctx.Update(b);
        }
        [HttpDelete]
        public void DeleteRequest(int Id)
        {
            ctx.Delete(Id);
        }
        [NonAction]
        public AuditRequest GetById(object id)
        {
            return ctx.GetById(id);
        }
        [NonAction]
        public void Addrequesttotheclient(AuditRequest areq)
        {
            string connectionStringServiceBus = "Endpoint=sb://auditclientsvcbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gdscIK81jFx39jlud7mcAXPw7WdftY4YqTAJvElo7KM=";
            string queueName = "audittoclientqueue";

            SendMessage(connectionStringServiceBus, queueName, areq).GetAwaiter().GetResult();
        }
        [NonAction]
        static async Task SendMessage(string connectionStringServiceBus, string queueName, AuditRequest areq)
        {
            QueueClient queueClient = new QueueClient(connectionStringServiceBus, queueName);

            string messageBody = JsonConvert.SerializeObject(areq);
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));
            await queueClient.SendAsync(message);
            await queueClient.CloseAsync();
        }
    }
}
