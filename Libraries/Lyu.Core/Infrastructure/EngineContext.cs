using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Lyu.Core.Configuration;

namespace Lyu.Core.Infrastructure
{
    public class EngineContext
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(bool forceRecreate)
        {
            if (Singleton<IEngine>.Instance == null || forceRecreate)
            {
                var config = ConfigurationManager.GetSection("LyuConfig") as LyuConfig;
                Singleton<IEngine>.Instance = CreateEngineInstance(config);
                Singleton<IEngine>.Instance.Initialize(config);
            }
            return Singleton<IEngine>.Instance;
        }

        private static IEngine CreateEngineInstance(LyuConfig config)
        {
            if (config !=null && !string.IsNullOrEmpty(config.EngineType))
            {
                var engineType = Type.GetType(config.EngineType);
                if (engineType == null)
                {
                    throw new ConfigurationErrorsException("这类型" + config.EngineType + "无法找到，请检查/configuration/lyu/engine[@engineType] 配置");
                }
                if (!typeof(IEngine).IsAssignableFrom(engineType))
                {
                    throw new ConfigurationErrorsException("这类型" + config.EngineType +
                                                           "没有继承'Lyu.Core.Infrastructure.IEngine'请检查/configuration/lyu/engine[@engineType] 配置");
                }
                return Activator.CreateInstance(engineType) as IEngine;
            }

            return new LyuEngine();
        }
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }
        #region Properties

        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Initialize(false);
                }
                return Singleton<IEngine>.Instance;
            }
        }

        #endregion
    }
}
