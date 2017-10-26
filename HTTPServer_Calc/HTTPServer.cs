using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTTPServer_Calc
{
    public class HTTPServer
    {
        HttpListener listener = null;

        public HTTPServer(string uri)
        {
            listener = new HttpListener();
            listener.Prefixes.Add(uri);
        }

        public void Start()
        {
            listener.Start();
            Console.WriteLine("Listening...");

            while (true)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    Receiver(context);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
        }

        private void Receiver(HttpListenerContext context)
        {
            string a = "";
            string b = "";
            string op = "";

            a = context.Request.QueryString["num1"];
            b = context.Request.QueryString["num2"];
            op = context.Request.QueryString["opr"];
            string data = Calc(a, b, op).ToString();

            context.Response.ContentType = "text/plain";
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.ContentLength64 = data.Length;
            context.Response.OutputStream.Write(Encoding.ASCII.GetBytes(data), 0, data.Length);
            context.Response.OutputStream.Close();
        }

        public int Calc(string a, string b, string op)
        {
            int res = 0;
            int num1 = Convert.ToInt32(a);
            int num2 = Convert.ToInt32(b);
            switch (op)
            {
                case "plus":
                    res = num1 + num2;
                    break;
                case "-":
                    res = num1 - num2;
                    break;
                case "*":
                    res = num1 * num2;
                    break;
                case "/":
                    res = num1 / num2;
                    break;
            }
            return res;
        }
    }
}
