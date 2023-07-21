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
            if (dbContextInfotechLabCase.TblCustomer==null)
            {
                return NotFound();
            }
            return await dbContextInfotechLabCase.TblCustomer.ToListAsync();
        }

        [HttpGet]
        [Route("{customerId:int}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerByCustomerId(int customerId)
        {
            if (dbContextInfotechLabCase.TblCustomer==null)
            {
                return NotFound();
            }
            var customer = await dbContextInfotechLabCase.TblCustomer.FindAsync(customerId);

            if (customer==null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerModel>> CreateCustomer(CustomerModel customer)
        {
            dbContextInfotechLabCase.TblCustomer.Add(customer);
            await dbContextInfotechLabCase.SaveChangesAsync();

            return Ok(customer);
            
        }
    }
}
