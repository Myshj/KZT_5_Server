using System.Net.Sockets;

namespace KZT_5_Server
{
    /*
    What does server know about client.
    */
    public class ClientInfo
    {
        public ClientInfo(string name = "", Socket socket = null, bool isFree = true, int currentRow = -1)
        {
            this.name = name;

            this.socket = socket;

            this.isFree = isFree;

            this.currentRow = currentRow;
        }    

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Socket Socket
        {
            get { return socket; }
            set { socket = value; }
        }

        public bool IsFree
        {
            get { return isFree; }
            set { isFree = value; }
        }

        public int CurrentRow
        {
            get { return currentRow; }
            set { currentRow = value; }
        }

        private string name;
        private Socket socket;
        private bool isFree = true;
        private int currentRow = -1;
    }
}
