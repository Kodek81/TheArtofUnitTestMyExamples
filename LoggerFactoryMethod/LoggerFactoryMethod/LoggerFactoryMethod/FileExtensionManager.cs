using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Logger
{
    public class FileExtensionManager:IExtensionManager
    {

        private string LocationPath { get; set; }

        private static bool IsValidFilename(string testName)
        {
            var containsABadCharacter =
                new Regex("[" + Regex.Escape(Path.GetInvalidFileNameChars().ToString()) + "]");
            return !(containsABadCharacter.IsMatch(testName));
        }

        public bool SaveEntrytoFile(Log logEntry)
        {
            bool result=false;
            try
            {
                string file = "LogFile" + logEntry.LogDate + ".txt";
                if ((Directory.Exists(LocationPath)) && (IsValidFilename(file)))
                {
                    string location = Path.Combine(LocationPath, file);
                    using (StreamWriter oFile = File.AppendText(location))
                    {
                        oFile.WriteLine(logEntry.LogTime + logEntry.Message);
                    }
                    result= true;
                }
            }
            catch
            {
                Console.WriteLine("SaveLogtoFile: Error writing the file");
                return false;
            }
            return result;
        }
    }
}
