using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZT_5_Server
{
    public class ServerLog
    {

        public ServerLog()
        {
            log = new List<string>();
        }

        public void Add(string message)
        {
            log.Add(message);
        }

        public void Clear()
        {
            log.Clear();
        }

        public bool IsEmpty()
        {
            return log.Count == 0;
        }

        public List<string> Messages
        {
            get { return log; }
        }
        private List<string> log;
    }
}
