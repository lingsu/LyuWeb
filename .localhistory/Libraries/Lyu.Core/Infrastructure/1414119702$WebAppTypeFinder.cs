using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyu.Core.Infrastructure
{
    public class WebAppTypeFinder : AppDomainTypeFinder
    {
        #region Fields

        private bool _ensureBinFolderAssembliesLoaded = true;
        private bool _binFolderAssembliesLoaded = false;

        #endregion


    }
}
