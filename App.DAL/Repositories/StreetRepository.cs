using App.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    class StreetRepository : GenericRepository<Street>
    {
        public StreetRepository(DbContext context) : base(context)
        { }
    }
}
