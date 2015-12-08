using NHibernate;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Data.Abstract;
using UnitOfWorkDemo.Services;

namespace UnitOfWorkDemo
{
    public static class IoCWrapper
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                // Services
                x.For<IMessageService>()
                    .Use<MessageServiceB>();

                // NHibernate SessionFactory
                x.For<INHibernateSessionFactory>()
                    .Use<NHibernateFactory>();

                // Repository
                x.For<IPearsonRepository>()
                    .Use<InMemoryDataRepository>().Named("InMemoryRepo")
                    .Ctor<EnumRepositoryType>()
                        .Is(ctx => EnumRepositoryType.InMemory);

                x.For<IPearsonRepository>()
                    .Use<NHibernateDataRepository>().Named("NHibRepo")
                    .Ctor<EnumRepositoryType>()
                        .Is(ctx => EnumRepositoryType.NHibernate);


                x.For<IPearsonRepository>()
                    .Use<NHibernateLighDataRepository>().Named("NHibRepoLight")
                    .Ctor<ISession>()
                        .Is(ctx => NHibernateStaticFactory.CreateSessionFactory().OpenSession());

                // UnitOfWork
                x.For<IUnitOfWork>()
                .Use<UnitOfWork>().Named("BasicUOWNHib");

                x.For<IUnitOfWorkGeneric>()
                .Use<UnitOfWorkGeneric>().Named("GenericUOW");

                x.For<IUnitOfWork>()
                .Use<UnitOfWorkNhibernate>().Named("LightUOW")
                .Ctor<ISession>()
                     .Is(ctx => NHibernateStaticFactory.CreateSessionFactory().OpenSession());
            });

            return ObjectFactory.Container;
        }

    }
}
