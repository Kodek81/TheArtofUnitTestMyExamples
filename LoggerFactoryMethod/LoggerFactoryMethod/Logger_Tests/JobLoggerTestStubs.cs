using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Logger;
using NUnit.Framework;


namespace Logger_Tests
{
 
    [TestFixture]
    public class JobLoggerTestStubs
    {
     
        [Test]
        public void Initialize()
        {
            StubExtensionManager stubManager = new StubExtensionManager();
            ExtensionManagerFactory.SetManagerInstance(stubManager);
            JobLoggerFactoryMehtod logger = new JobLoggerFactoryMehtod();
            Log entry = new Log();
            entry.Message = "this is an entry";
            bool result = logger.SaveEntrytoFile(entry);
            Assert.IsTrue(result);
            
        }
        

        internal class StubExtensionManager : IExtensionManager
        {
            public bool SaveEntrytoFile(Log logEntry)
            {
                return true;
            }

            public bool IsValidFilename(string testName)
            {
                return true;
            }


        }
    }

}