using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CykelLib;
using Newtonsoft.Json;

namespace TCPServer
{
    class ServerWorker
    {
        private static List<Cykel> _cykel = new List<Cykel>()
        {
            new Cykel(1,"lilla",1200,7),
            new Cykel(2,"blå",1600,3),
            new Cykel(3,"grøn",800,32),
            new Cykel(4,"orange",2300,15),
            new Cykel(5,"guld",5000,21)
        };

        public void Start()
        {
            //Establishing a server + port
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);
            server.Start();

            //Looping connecting to a client
            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();

                Task.Run((() =>
                {
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                }));
            }
        }

        public void DoClient(TcpClient socket)
        {
            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());
            
            //klienten skal skriver valgmulighed, fx "HentAlle"
            string strSvar = sr.ReadLine();
            Console.WriteLine(strSvar);

            if (strSvar == "HentAlle")
            {
                HentAlle();
            }
            else
            {
                if (strSvar == "Hent")
                {
                    int id = Convert.ToInt32(strSvar);
                    Hent(id);
                }
                else
                {
                    if (strSvar == "Gem")
                    {
                        string nyCykel = strSvar;
                        Gem(nyCykel);
                    }
                }
            }

            void HentAlle()
            {
                string strSend = "";
                foreach (Cykel c in _cykel)
                {
                    strSend = strSend + "  " + JsonConvert.SerializeObject(c);
                }
                sw.WriteLine(strSend);
                sw.Flush();
            }

            void Hent(int id)
            {
                Cykel c1 = _cykel.Find(cykel => cykel.Id == id);
                string send = JsonConvert.SerializeObject(c1);

                sw.WriteLine(send);
                sw.Flush();
            }

            void Gem(string s)
            { 
                Cykel cykel = JsonConvert.DeserializeObject<Cykel>(s);
                _cykel.Add(cykel);

                Console.WriteLine("Object Saved");
                sw.Flush();
            }
        }
    }
}
