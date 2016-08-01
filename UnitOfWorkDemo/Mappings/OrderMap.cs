using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Entities;

namespace UnitOfWorkDemo.Mappings
{
    class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Subject);
            Map(x => x.Price);
            References(x => x.Pearson)
                .LazyLoad().Cascade.None()
                .Column("PersonId");
            Table("[Order]");
        }
    }
}
