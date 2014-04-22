using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public interface IExtensionManager
    {
         bool SaveEntrytoFile(Log logEntry);
         bool IsValidFilename(string testName);
    }
}
