using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{


    internal class CategoryRepositoty
    {
        MySuperMarketContext _MySuperMarketContext;
        public CategoryRepositoty(MySuperMarketContext _mySuperMarketContext)
        {
            _MySuperMarketContext = _mySuperMarketContext;
        }
    }
}
