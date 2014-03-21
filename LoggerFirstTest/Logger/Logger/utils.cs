using System;

namespace Logger
{
    public enum ELogflag
    {
        Log,
        Error,
        Warning,
        Init
    }


    public class Log
    {
        public Log(string message)
        {
            Message = message;
            LogDate =  DateTime.Now.Year*10000 + DateTime.Now.Month*100 + DateTime.Now.Day;
            LogTime = DateTime.Now.ToString("hh:mm:ss.fff tt");
            FlagLogflag = ELogflag.Init;
            ForegroundColor = ConsoleColor.Gray;
        }

        public string Message { get; set; }
        public string LogTime { get; set; }
        public long LogDate { get; set; }
        public ELogflag FlagLogflag { get; set; }
        public ConsoleColor ForegroundColor { get; set; }

        public void SetFlag(ELogflag flagLog)
        {
            FlagLogflag = flagLog;
            switch (flagLog)
            {
                case ELogflag.Error:
                    ForegroundColor = ConsoleColor.Red;
                    break;
                case ELogflag.Warning:
                    ForegroundColor = ConsoleColor.Yellow;
                    break;
                case ELogflag.Log:
                    ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
    }




}