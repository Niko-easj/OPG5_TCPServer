using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using CykelLib;
using Newtonsoft.Json;

namespace TCPKlient
{
    class KlientWorker
    {
        public void Start()
        {
            //Den skal hedde "localhost"...
            TcpClient socket = new TcpClient("localhost", 4646);

            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());

            //id 1-5 er optaget i listen
            Cykel cykel = new Cykel(66,"sølv",3333,12);

            String json = JsonConvert.SerializeObject(cykel);

            sw.WriteLine("Gem");
            sw.WriteLine(json);

            sw.Flush();

        }
    }
}
