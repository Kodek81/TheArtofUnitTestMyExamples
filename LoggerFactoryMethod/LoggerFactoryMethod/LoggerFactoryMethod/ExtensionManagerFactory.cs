using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public class ExtensionManagerFactory
    {
        private static IExtensionManager _manager = new FileExtensionManager();

        public static IExtensionManager Create()
        {
            return _manager;
        }

        public static void SetManagerInstance(IExtensionManager value)
        {
            _manager = value;
        }
    }
}
