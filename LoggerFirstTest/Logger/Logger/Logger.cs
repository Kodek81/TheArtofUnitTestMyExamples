using System;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace Logger
{
    public sealed class JobLogger

    {
        
        private static readonly JobLogger Instance = new JobLogger();
      
        //filters
        private bool _errorEnabled;
        
        private bool _logEnabled;
        
        private bool _warningEnabled;

        public static JobLogger GetInstance
        {
            get { return Instance; }
        }

       
        public bool ErrorEnabled
        {
            set { _errorEnabled = value; }
        }

        public bool WarningEnabled
        {
            set { _warningEnabled = value; }
        }

        public bool LogEnabled
        {
            set { _logEnabled = value; }
        }
        
       
        private static void ConsoleLog(Log logEntry)
        {
            Console.ForegroundColor = logEntry.ForegroundColor;
            Console.WriteLine(logEntry.LogTime + logEntry.Message);
        }

        public bool IsValidFilename(string testName)
        {
            var containsABadCharacter =
                new Regex("[" + Regex.Escape(Path.GetInvalidFileNameChars().ToString()) + "]");
            return !(containsABadCharacter.IsMatch(testName));
        }

       

        private bool IsvalidFlag(ELogflag logflag)
        {
            switch (logflag)
            {
                case ELogflag.Error:
                    return _errorEnabled;
                    break;
                case ELogflag.Warning:
                    return _warningEnabled;
                    break;
                case ELogflag.Log:
                    return _logEnabled;
                    break;
                default:
                    return false;
                    break;
            }
        }


        public void LogMessage(Log logEntry)
        {
            if (IsvalidFlag(logEntry.FlagLogflag))
            {
                logEntry.Message = logEntry.Message.Trim();


                if (string.IsNullOrEmpty(logEntry.Message))
                {
                    Console.WriteLine("Error or Warning or Information must be specified");
                    return;
                }

                ConsoleLog(logEntry);
            }
            else
                Console.WriteLine("Invalid configuration");
        }
    }
}