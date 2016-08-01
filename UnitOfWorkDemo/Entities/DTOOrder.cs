using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Entities
{
    class DTOOrder : Order
    {
        public string Pearson
        {
            get
            {
                return base.ToString();
            }
        }
    }
}
