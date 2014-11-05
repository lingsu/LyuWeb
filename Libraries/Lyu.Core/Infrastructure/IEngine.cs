using System;
using System.Collections.Generic;
using Lyu.Core.Configuration;
using Lyu.Core.Infrastructure.DependencyManagement;

namespace Lyu.Core.Infrastructure
{
    public interface IEngine
    {
        ContainerManager ContainerManager { get; }
        void Initialize(LyuConfig config);
        T Resolve<T>() where T : class;
        object Resolve(Type type);
        T[] ResolveAll<T>();
    }
}
