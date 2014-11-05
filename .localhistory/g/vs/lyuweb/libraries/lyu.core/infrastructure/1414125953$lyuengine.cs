using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Lyu.Core.Configuration;
using Lyu.Core.Infrastructure.DependencyManagement;

namespace Lyu.Core.Infrastructure
{
    public class LyuEngine:IEngine
    {
        private ContainerManager _containerManager;

        

        public void Initialize(LyuConfig config)
        {
            RegisterDependencies(config);

            //startup tasks
            if (!config.IgnoreStartupTasks)
            {
                RunStartupTasks();
            }
        }

        protected virtual void RunStartupTasks()
        {

        }

        protected virtual void RegisterDependencies(LyuConfig config)
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();

            var typeFinder = new WebAppTypeFinder(config);
            builder = new ContainerBuilder();
            builder.RegisterInstance(config).As<LyuConfig>().SingleInstance();
            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            builder.Update(container);

            builder=new ContainerBuilder();
            var drtypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            var drInstances = new List<IDependencyRegistrar>();

            foreach (var drtype in drtypes)
            {
                drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drtype));
            }

        }

        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }

        public T[] ResolveAll<T>()
        {
            return ContainerManager.ResolveAll<T>();
        }

        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
        }
    }
}
