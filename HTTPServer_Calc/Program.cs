using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPServer_Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            HTTPServer server = new HTTPServer("http://localhost:8808/");
            server.Start();
        }
    }
}
