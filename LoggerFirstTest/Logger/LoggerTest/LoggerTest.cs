using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Logger;
namespace LoggerTest
{

    [TestFixture]
    public class LoggerTest
    {
        private JobLogger logger = null;
        

        [SetUp]
        public void Setup()
        {
            logger = new JobLogger();
            
        }

        [Test]
        public void IsValidFilename_validFileLowerCased_ReturnsTrue()
        {
            bool result = logger.IsValidFilename("whatever.slf");

            Assert.IsTrue(result, "filename should be valid!");
        }

       
    }
}