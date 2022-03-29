using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Dto.Request;

namespace ApiWithNetCore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DirectionController : ControllerBase
    {
        private readonly IDirectionService service;

        public DirectionController(IDirectionService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.ListDirectionAsync());
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var direction = await service.GetDirectionAsync(id);

            if (direction == null)
                return NotFound();

            return Ok(direction);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoDirectionResquest request)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            int result = await service.CreateDirectionAsync(request);

            return Created($"/{result}",
                new { 
                    Id = result                
                });
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, DtoDirectionResquest resquest)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            int result = await service.UpdateDirectionAsync(id, resquest);

            if (result == 0)
                return NotFound();

            return Accepted(new
            {
                Id = result
            });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Deleted(int id)
        {
            bool result = await service.DeleteDirectionAsycn(id);

            if (result == false)
                return NotFound();

            return Accepted(new
            {
                result = result
            });
        }
    }
}
