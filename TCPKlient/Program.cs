using System;
using System.Dynamic;

namespace TCPKlient
{
    class Program
    {
        static void Main(string[] args)
        {
            KlientWorker worker = new KlientWorker();
            worker.Start();

            Console.ReadLine();
        }
    }
}
