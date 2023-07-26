using InfotechLabCase.Data;
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

        /// <summary>
        /// Bütün Müşterileri Getiren Api
        /// </summary>
        /// <returns>customerList</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            if (dbContextInfotechLabCase.TblCustomer == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForCustomer });
            }

            var customerList = await dbContextInfotechLabCase.TblCustomer.ToListAsync();

            return Ok(new { Message = BaseClass.GetCustomers, ResponseData = customerList });
        }

        /// <summary>
        /// CustomerId'ye Göre Müşteri Getiren Api
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>customer</returns>
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

        /// <summary>
        /// Müşteri Oluşturan Api
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns>customerModel</returns>
        [HttpPost]
        [Route("CreateCustomer/")]
        public async Task<ActionResult<CustomerModel>> CreateCustomer([FromBody] CustomerModel customerModel)
        {

            dbContextInfotechLabCase.TblCustomer.Add(customerModel);
            await dbContextInfotechLabCase.SaveChangesAsync();

            return Ok(new { Message = BaseClass.CreateCustomerSuccess, customerModel });

        }

        /// <summary>
        /// Müşterinin Profil Bilgilerini Güncellemesini Sağlayan Api
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="customerModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Müşterinin Mevcut Olup ve ya Aktif Olup Olmadığını Kontrol Eden Bool Tipinde Method
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>true or false</returns>
        private bool CustomerAvailable(int customerId)
        {
            return (dbContextInfotechLabCase.TblCustomer?.Any(x => x.CustomerId == customerId)).GetValueOrDefault();
        }

        /// <summary>
        /// Müşterinin Profilini Aktiften Pasife Çeken Api
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
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
