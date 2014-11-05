using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lyu.Core.Configuration
{
    public class LyuConfig:IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            var config = new LyuConfig();
            var dynamicDiscoveryNode = section.SelectSingleNode("DynamicDiscovery");
            if (dynamicDiscoveryNode != null && dynamicDiscoveryNode.Attributes != null)
            {
                var attribute = dynamicDiscoveryNode.Attributes["Enabled"];
                if (attribute != null)
                    config.DynamicDiscovery = Convert.ToBoolean(attribute.Value);
            }

            var engineNode = section.SelectSingleNode("Engine");
            if (engineNode != null && engineNode.Attributes != null)
            {
                var attribute = engineNode.Attributes["Type"];
                if (attribute != null)
                    config.EngineType = attribute.Value;
            }

            var startupNode = section.SelectSingleNode("Startup");
            if (startupNode != null && startupNode.Attributes != null)
            {
                var attribute = startupNode.Attributes["IgnoreStartupTasks"];
                if (attribute != null)
                    config.IgnoreStartupTasks = Convert.ToBoolean(attribute.Value);
            }

            var themeNode = section.SelectSingleNode("Themes");
            if (themeNode != null && themeNode.Attributes != null)
            {
                var attribute = themeNode.Attributes["basePath"];
                if (attribute != null)
                    config.ThemeBasePath = attribute.Value;
            }

            var userAgentStringsNode = section.SelectSingleNode("UserAgentStrings");
            if (userAgentStringsNode != null && userAgentStringsNode.Attributes != null)
            {
                var attribute = userAgentStringsNode.Attributes["databasePath"];
                if (attribute != null)
                    config.UserAgentStringsPath = attribute.Value;
            }

            return config;
        }

        public bool DynamicDiscovery { get; private set; }

        public string EngineType { get; private set; }

        public string ThemeBasePath { get; private set; }

        public bool IgnoreStartupTasks { get; private set; }

        public string UserAgentStringsPath { get; private set; }
    }
}
