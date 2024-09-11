using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net8_ddd_sample.domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual Product[] Products { get; set; }
    }
}
