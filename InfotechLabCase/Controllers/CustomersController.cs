using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;

        public CustomersController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            if (dbContextInfotechLabCase.TblCustomer == null)
            {
                return NotFound();
            }

            return await dbContextInfotechLabCase.TblCustomer.ToListAsync();
        }

        [HttpGet]
        [Route("{customerId:int}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerByCustomerId(int customerId)
        {
            if (dbContextInfotechLabCase.TblCustomer == null)
            {
                return NotFound();
            }
            var customer = await dbContextInfotechLabCase.TblCustomer.FindAsync(customerId);

            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerModel>> CreateCustomer(CustomerModel customerModel)
        {

            dbContextInfotechLabCase.TblCustomer.Add(customerModel);
            await dbContextInfotechLabCase.SaveChangesAsync();

            return Ok(customerModel);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerByCustomerId(int customerId, CustomerModel customerModel)
        {
            if (customerId != customerModel.CustomerId)
            {
                return BadRequest();
            }
            dbContextInfotechLabCase.Entry(customerModel).State = EntityState.Modified;

            try
            {
                await dbContextInfotechLabCase.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerAvailable(customerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        private bool CustomerAvailable(int customerId)
        {
            return (dbContextInfotechLabCase.TblCustomer?.Any(x => x.CustomerId == customerId)).GetValueOrDefault();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomerByCustomerId(int customerId)
        {
            if (dbContextInfotechLabCase.TblCustomer == null)
            {
                return NotFound();
            }

            var customer = await dbContextInfotechLabCase.TblCustomer.FindAsync(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            dbContextInfotechLabCase.Remove(customer);

            await dbContextInfotechLabCase.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("{customerModel}")]
        public async Task<IActionResult> CustomerLoginByCustomerEmailAndCustomerPassword([FromBody] CustomerModel customerModel)
        {
            var customerEmail = await dbContextInfotechLabCase.TblCustomer.FirstOrDefaultAsync(x=>x.CustomerEmail==customerModel.CustomerEmail);
            var customerPassword = await dbContextInfotechLabCase.TblCustomer.FirstOrDefaultAsync(x=>x.CustomerPassword==customerModel.CustomerPassword);

            if (customerEmail==null||customerPassword==null)
            {
                return Unauthorized();
            }

            return Ok();
        }
    }
}
