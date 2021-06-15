using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shoes.Models;
using Shoes.Providers;

namespace Shoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManageController : ControllerBase
    {
        private readonly IManageProvider _shoesProvider;

        public ManageController(IManageProvider shoesProvider)
        {
            _shoesProvider = shoesProvider;
        }

        [HttpPost]
        public Task<ShoesModel> Create(ShoesCreateModel model)
        {
            return _shoesProvider.Create(model);
        }

        [HttpGet]
        public Task<IEnumerable<ShoesModel>> GetAll()
        {
            return _shoesProvider.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _shoesProvider.Get(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut]
        public Task<ShoesModel> Update(ShoesUpdateModel model)
        {
            return _shoesProvider.Update(model);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task Delete(Guid id)
        {
            return _shoesProvider.Delete(id);
        }
    }
}
