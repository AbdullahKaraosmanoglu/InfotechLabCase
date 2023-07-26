﻿using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;

        public CustomerController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            if (dbContextInfotechLabCase.TblCustomer == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForCustomer });
            }

            var customerList = await dbContextInfotechLabCase.TblCustomer.ToListAsync();

            return Ok(new {Message=BaseClass.GetCustomers,ResponseData=customerList});
        }

        [HttpGet]
        [Route("{customerId:int}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerByCustomerId(int customerId)
        {
            if (dbContextInfotechLabCase.TblCustomer == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForCustomer });
            }
            var customer = await dbContextInfotechLabCase.TblCustomer.FindAsync(customerId);

            if (customer == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForCustomerId });
            }
            return Ok(new { Message = BaseClass.ProfileFound, ResponseData = customer });
        }

        [HttpPost]
        [Route("CreateCustomer/")]
        public async Task<ActionResult<CustomerModel>> CreateCustomer([FromBody] CustomerModel customerModel)
        {

            dbContextInfotechLabCase.TblCustomer.Add(customerModel);
            await dbContextInfotechLabCase.SaveChangesAsync();

            return Ok(new { Message = BaseClass.CreateCustomerSuccess, customerModel });

        }

        [HttpPut]
        [Route("UpdateCustomer/")]
        public async Task<IActionResult> UpdateCustomerByCustomerId(int customerId, CustomerModel customerModel)
        {
            if (customerId != customerModel.CustomerId)
            {
                return BadRequest(new { Message = BaseClass.BadRequest });
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
                    return NotFound(new { Message = BaseClass.DataEntryNotFoundForCustomerId });
                }
                else
                {
                    throw;
                }
            }
            return Ok(new { Message = BaseClass.UpdateProfileSuccess });
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
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForCustomer });
            }

            var customer = await dbContextInfotechLabCase.TblCustomer.FindAsync(customerId);

            if (customer == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForCustomerId });
            }

            customer.IsActive = BaseClass.IsActive.Passive.GetHashCode();

            await dbContextInfotechLabCase.SaveChangesAsync();

            return Ok(new { Message = BaseClass.DeleteProfileSuccess });
        }
    }
}