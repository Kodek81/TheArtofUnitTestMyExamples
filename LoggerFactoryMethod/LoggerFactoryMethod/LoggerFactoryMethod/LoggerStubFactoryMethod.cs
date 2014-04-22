using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace Logger
{
    public class JobLoggerFactoryMehtod

    {
        private IExtensionManager _fileManager;
        public JobLoggerFactoryMehtod()
        {
           _fileManager = ExtensionManagerFactory.Create();
        }
  
        // LOG TO FILE
        public bool SaveEntrytoFile(Log logEntry)
        {
            return _fileManager.SaveEntrytoFile(logEntry);
        }
      
}