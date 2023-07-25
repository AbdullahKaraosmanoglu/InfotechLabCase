using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;
        public DistrictController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistrictModel>>> GetDistricts()
        {
            if (dbContextInfotechLabCase.TblDistrict == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpert });
            }

            return await dbContextInfotechLabCase.TblDistrict.ToListAsync();
        }

        [HttpPost]
        [Route("CreateDistrict/")]
        public async Task<ActionResult<List<DistrictModel>>> CreateDistrict(DistrictModel districtModel)
        {
            if (districtModel != null)
            {
                await dbContextInfotechLabCase.TblDistrict.AddAsync(districtModel);
                await dbContextInfotechLabCase.SaveChangesAsync();
                return Ok(new { Message = BaseClass.CreateDistrictSuccess, ResponseData = districtModel });
            }
            return BadRequest(new { Message = BaseClass.BadRequest });
        }
    }
}
