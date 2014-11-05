using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
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


        #region Properties
        public bool EnsureBinFolderAssembliesLoaded
        {
            get { return _ensureBinFolderAssembliesLoaded; }
            set { _ensureBinFolderAssembliesLoaded = value; }
        }

        #endregion


        #region Methods

        public virtual string GetBinDirectory()
        {
            if (HostingEnvironment.IsHosted)
            {
                //hosted
                return HttpRuntime.BinDirectory;
            }
            else
            {
                //not hosted. For example, run either in unit tests
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        public override IList<Assembly> GetAssemblies()
        {

            return base.GetAssemblies();
        }

        #endregion
    }
}
