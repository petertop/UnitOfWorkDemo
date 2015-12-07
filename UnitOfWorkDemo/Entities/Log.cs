using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Entities
{
    public class Log
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Created { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", Id.ToString(),Created.ToShortTimeString(),Description); ;
        }
    }
}
