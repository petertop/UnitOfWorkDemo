using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Services;

namespace UnitOfWorkDemo
{
    public static class IoCWrapper
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IMessageService>().Use<MessageServiceB>();
                x.For<IDataRepository>().Use<DataRepository>();
            });
            return ObjectFactory.Container;
        }


    }
}
