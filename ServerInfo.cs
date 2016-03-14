using System.Collections.Generic;

namespace KZT_5_Server
{
    /*
    Current state of task.
    */
    public class ServerInfo
    {
        private ServerClients clients = new ServerClients();
        private Matrix<byte> leftMatrix = new Matrix<byte>();
        private Matrix<byte> rightMatrix = new Matrix<byte>();
        private Matrix<byte> resultMatrix = new Matrix<byte>();
        private CompletedRowsInfo completedRowsInfo = new CompletedRowsInfo();
        private FreeRowsInfo freeRowsInfo = new FreeRowsInfo();
        private ServerLog log = new ServerLog();

        public ServerClients Clients
        {
            get { return clients; }
        }

        public CompletedRowsInfo CompletedRowsInfo
        {
            get { return completedRowsInfo; }
        }

        public FreeRowsInfo FreeRowsInfo
        {
            get { return freeRowsInfo; }
        }

        public Matrix<byte> LeftMatrix
        {
            get { return leftMatrix; }
            set { leftMatrix = value; }
        }

        public Matrix<byte> RightMatrix
        {
            get { return rightMatrix; }
            set { rightMatrix = value; }
        }

        public Matrix<byte> ResultMatrix
        {
            get { return resultMatrix; }
            set { resultMatrix = value; }
        }

        public ServerLog Log
        {
            get { return log; }
        }
    }
}
