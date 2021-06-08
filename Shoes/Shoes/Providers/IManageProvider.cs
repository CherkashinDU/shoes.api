using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shoes.Models;

namespace Shoes.Providers
{
    public interface IManageProvider
    {
        Task<ShoesModel> Create(ShoesCreateModel model);
        Task<ShoesModel> Get(Guid id);
        Task Delete(Guid id);
        Task<IEnumerable<ShoesModel>> GetAll();
        Task<ShoesModel> Update(ShoesUpdateModel model);
    }
}
