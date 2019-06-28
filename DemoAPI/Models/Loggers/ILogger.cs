using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public interface ILogger // Just for working with DI
    {
        void Log(string message);
    }
}
