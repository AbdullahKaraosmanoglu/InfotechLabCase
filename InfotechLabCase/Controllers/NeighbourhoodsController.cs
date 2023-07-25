using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighbourhoodsController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;
        public NeighbourhoodsController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NeighbourhoodModel>>> GetNeigbourhood()
        {
            if (dbContextInfotechLabCase.TblNeighbourhood == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpert });
            }

            return await dbContextInfotechLabCase.TblNeighbourhood.ToListAsync();
        }

        [HttpPost]
        [Route("CreateNeighbourhood/")]
        public async Task<ActionResult<List<NeighbourhoodModel>>> CreateNeighbourhoodC(/*int districtId,*/ NeighbourhoodModel neighbourhoodModel)
        {
            if (neighbourhoodModel != null )
            {
                await dbContextInfotechLabCase.TblNeighbourhood.AddAsync(neighbourhoodModel);
                await dbContextInfotechLabCase.SaveChangesAsync();
                return Ok(new { Message = "mahalle eklendi", ResponseData = neighbourhoodModel });
            }
            return BadRequest(new { Message = BaseClass.BadRequest });
        }
    }
}
