using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer_Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPServer server = new TCPServer("127.0.0.1", 8808);
            server.Start();
        }
    }
}
