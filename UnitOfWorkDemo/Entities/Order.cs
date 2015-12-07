using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data.Abstract;

namespace UnitOfWorkDemo.Entities
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual string Subject { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Pearson Pearson { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", Id.ToString(),Subject,Price.ToString());
        }
    }
}
