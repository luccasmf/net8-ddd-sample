using net8_ddd_sample.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net8_ddd_sample.domain.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
