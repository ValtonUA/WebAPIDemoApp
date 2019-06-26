using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class TextFileLogger : ILogger
    {
        public string Filename { get; private set; } 

        public TextFileLogger(string filename)
        {
            Filename = filename;
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