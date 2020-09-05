using AuditManagement;
using AuditManagement.Controllers;
using AuditManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Xunit;

namespace web_api_tests
{
    public class AuditTests
    {
        AuditController _controller;
        IDataAccess<Auditors> _service;

        public AuditTests()
        {
            _service = new IDataAccessFake();
            _controller = new AuditController(null,_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAuditors();

            bool count = _service.GetAll().Count() > 0;

            // Assert
           
            Assert.True(count);
        }
        //[Fact]
        //public void Test1()
        //{

        //}
    }
}
