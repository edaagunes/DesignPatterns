using DesignPattern.BusinessLayer.Abstract;
using DesignPattern.EntityLayer.Concrete;
using DesignPattern.UnitOfWorkDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPattern.UnitOfWorkDesignPattern.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICustomerService _customerService;

        public DefaultController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerViewModel model)
        {
            var value1 = _customerService.TGetById(model.SenderId);
            var value2 = _customerService.TGetById(model.ReceiverId);

            value1.CustomerBalance -= model.Amount;
            value1.CustomerBalance += model.Amount;

            List<Customer> modifiedCustomers = new List<Customer>()
            {
                value1,
                value2
            };

            _customerService.TMultiUpdate(modifiedCustomers);
            return View();
        }
    }
}
