using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data.Abstract;

namespace UnitOfWorkDemo.Entities
{
    public class Pearson
    {
        public Pearson()
        {
            this.Orders = new List<Order>();
        }
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual IList<Order> Orders { get; set;}

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", Id.ToString(), FirstName, LastName); ;
        }
    }
}
