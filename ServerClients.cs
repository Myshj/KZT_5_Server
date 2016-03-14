using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZT_5_Server
{
    public class ServerClients
    {
        public ServerClients()
        {
            clients = new HashSet<ClientInfo>();
        }

        public void Add(ClientInfo client)
        {
            clients.Add(client);
        }

        public void Remove(ClientInfo client)
        {
            clients.Remove(client);
        }

        public int CountOfClients()
        {
            return clients.Count;
        }

        public HashSet<ClientInfo> Clients
        {
            get { return clients; }
        }
        private HashSet<ClientInfo> clients;
    }
}
