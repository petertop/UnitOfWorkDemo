using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using UnitOfWorkDemo.Entities;

namespace UnitOfWorkDemo.Mappings
{
    // http://www.kode-blog.com/2014/04/fluent-nhibernate-tutorial-c-windows-crud-example/
    // ToDo http://stackoverflow.com/questions/1381187/simple-fluentnhibernate-parent-child-mapping
    class PearsonMap : ClassMap<Pearson>
    {
        public PearsonMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            HasMany(x => x.Orders)
                .KeyColumn("OrdersId")
                .Inverse()
                .Cascade.All();
            Table("Pearson");
        }
    }
}
