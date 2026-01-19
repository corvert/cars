using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Data
{
    public class CarsContext :DbContext
    {

        public DbSet<Cars> Cars { get; set; }
    }
}
