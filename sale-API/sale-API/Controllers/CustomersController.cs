using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sale_API.Models;
using sale_API.Repository.Interfaces;

namespace sale_API.Controllers
{
    //[Authorize]
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customer;

        public CustomersController(ICustomerRepository customer)
        {
            _customer = customer;
        }

        //get all post
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return Ok(await _customer.GetCustomersAsync());
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersAll()
        {
            return Ok(await _customer.GetCustomersAsync());
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {

            return Ok(await _customer.GetCustomersByIDAsync(id));

        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            /*// modelBuilder = new ModelBuilder(); 
            Customer customer1 = await _customer.GetCustomersByIDAsync(id);

            EntityState.Modified.CompareTo(customer1);*/

            return Ok(await _customer.PutCustomerAsync(id, customer));
        }

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
           // customer.CustomerID = 2;
            return Ok(await _customer.PostCustomerAsync(customer));
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            return Ok(await _customer.DeleteCustomerAsync( id));
        }
    }
}
