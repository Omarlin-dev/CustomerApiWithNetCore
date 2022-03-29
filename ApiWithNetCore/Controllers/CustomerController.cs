using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Services;
using Dto.Request;

namespace ApiWithNetCore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.ListCustomer());
        }
        
        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await service.GetAsync(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]
        DtoCustomerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int response = await service.CreateAsync(request);

            return Created($"/{response}",
                new { 
                    Id = response
                    });
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, 
            DtoCustomerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int response = await service.UpdateAsync(id, request);

            return Accepted(new
            {
                Id = response
            });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await service.DeleteAsync(id);

            if (result == false)
                return NotFound();

            return Accepted(new { 
                Id = id            
            });
        }
    }
}
