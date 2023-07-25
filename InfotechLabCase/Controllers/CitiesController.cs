﻿using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;
        public CitiesController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }
        /// <summary>
        /// Bütün Şehirleri Dönen Api
        /// </summary>
        /// <returns>cityList</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityModel>>> GetCities()
        {
            if (dbContextInfotechLabCase.TblCity == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpert });
            }
            var city = await dbContextInfotechLabCase.TblCity.ToListAsync();

            return await dbContextInfotechLabCase.TblCity.ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateCity/")]
        public async Task<ActionResult<List<CityModel>>> CreateCity(CityModel cityModel)
        {
            if (cityModel != null)
            {
                await dbContextInfotechLabCase.TblCity.AddAsync(cityModel);
                await dbContextInfotechLabCase.SaveChangesAsync();
                return Ok(new { Message = BaseClass.CreateCitySuccess, ResponseData = cityModel });
            }
            return BadRequest(new { Message = BaseClass.BadRequest });
        }
    }
}
