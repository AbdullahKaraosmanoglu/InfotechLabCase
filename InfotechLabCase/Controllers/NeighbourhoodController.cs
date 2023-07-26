using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighbourhoodController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;
        public NeighbourhoodController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }

        /// <summary>
        /// Bütün Mahalleleri Getiren Api.
        /// </summary>
        /// <returns>neighbourhoodList</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NeighbourhoodModel>>> GetNeigbourhood()
        {
            if (dbContextInfotechLabCase.TblNeighbourhood == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpert });
            }
            var neighbourhoodList = await dbContextInfotechLabCase.TblNeighbourhood.ToListAsync();
            return Ok(new { Message = BaseClass.GetNeighbourdhoods, ResponseData = neighbourhoodList });
        }

        /// <summary>
        /// Yeni Bir Mahalle Oluşturan Api
        /// </summary>
        /// <param name="neighbourhoodModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateNeighbourhood/")]
        public async Task<ActionResult<List<NeighbourhoodModel>>> CreateNeighbourhoodC(/*int districtId,*/ NeighbourhoodModel neighbourhoodModel)
        {
            if (neighbourhoodModel != null)
            {
                await dbContextInfotechLabCase.TblNeighbourhood.AddAsync(neighbourhoodModel);
                await dbContextInfotechLabCase.SaveChangesAsync();
                return Ok(new { Message = BaseClass.CreateNeighbourhood, ResponseData = neighbourhoodModel });
            }
            return BadRequest(new { Message = BaseClass.BadRequest });
        }
    }
}
