using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class TextFileLogger : ILogger
    {
        public static string Filename { get; private set; }

        public int TestField { get; set; }

        static TextFileLogger _instance;
        static object _syncLock = new object();

        TextFileLogger() { }

        TextFileLogger(string filename)
        {
            Filename = filename;
            TestField = 0;
        }

        public static TextFileLogger GetInstance()
        {
            if (_instance == null)
            {
                throw new Exception("Instance of class TextFileLogger is not created.");
            }

            return _instance;
        }

        public static void CreateInstance(string filename)
        {
            if (_instance != null)
            {
                throw new Exception("Instance of class TextFileLogger already created.");
            }
            else
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                        _instance = new TextFileLogger(filename);
                }
            }
        }

        public void Log(string message)
        {
            using (StreamWriter file = new StreamWriter(Filename, true))
            {
                file.WriteLine(message);
            }
        }
    }
}