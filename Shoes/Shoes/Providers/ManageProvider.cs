using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shoes.Models;

namespace Shoes.Providers
{
    public class ManageProvider : IManageProvider
    {
        private readonly List<ShoesModel> _entities = new List<ShoesModel>();
        public Task<ShoesModel> Create(ShoesCreateModel model)
        {
            var entity = new ShoesModel
            {
                Id = Guid.NewGuid(),
                Brand = model.Brand,
                Name = model.Name,
                Category = model.Category,
                Price = model.Price
            };

            _entities.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<ShoesModel>> GetAll()
        {
            return Task.FromResult<IEnumerable<ShoesModel>>(_entities.OrderBy(o => o.Name));
        }

        public Task<ShoesModel> Get(Guid id)
        {
            var entity = _entities.FirstOrDefault(i => i.Id == id);
            return Task.FromResult(entity);
        }

        public Task Delete(Guid id)
        {
            _entities.RemoveAll(i => i.Id == id);

            return Task.CompletedTask;
        }

        public async Task<ShoesModel> Update(ShoesUpdateModel model)
        {
            var entity = await Get(model.Id);
            entity.Name = model.Name;
            entity.Category = model.Category;
            entity.Price = model.Price;

            return entity;
        }
    }
}
