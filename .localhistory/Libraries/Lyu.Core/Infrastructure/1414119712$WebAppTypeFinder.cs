using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyu.Core.Configuration;

namespace Lyu.Core.Infrastructure
{
    public class WebAppTypeFinder : AppDomainTypeFinder
    {
        #region Fields

        private bool _ensureBinFolderAssembliesLoaded = true;
        private bool _binFolderAssembliesLoaded = false;

        #endregion

        #region Ctor

        public WebAppTypeFinder(LyuConfig config)
        {
            this._ensureBinFolderAssembliesLoaded = config.DynamicDiscovery;
        }

        #endregion

    }
}
