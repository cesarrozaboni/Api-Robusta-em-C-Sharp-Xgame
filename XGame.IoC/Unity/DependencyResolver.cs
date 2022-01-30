using Microsoft.Practices.Unity;
using prmToolkit.NotificationPattern;
using System.Data.Entity;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Repositories.Base;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Services;
using XGame.Infra.Persistense;
using XGame.Infra.Persistense.Repositories;
using XGame.Infra.Persistense.Repositories.Base;
using XGame.Infra.Transactions;

namespace XGame.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, XGameContext>(new HierarchicalLifetimeManager());
            //unity of work
            container.RegisterType<IUnityOfWork, UnityOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //servide de domain

            container.RegisterType<IServiceJogador, ServiceJogador>(new HierarchicalLifetimeManager());
            
            container.RegisterType<IServiceJogo, ServiceJogo>(new HierarchicalLifetimeManager());


            //repository

            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            //realiza o mapeamento da interface com a classe concreta
            container.RegisterType<IRepositoryJogador, RepositoryJogador>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryJogo, RepositoryJogo>(new HierarchicalLifetimeManager());
        }
    }
}
