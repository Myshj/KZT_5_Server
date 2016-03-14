using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZT_5_Server
{
    public class CompletedRowsInfo
    {
        public CompletedRowsInfo()
        {
            completedRows = new HashSet<int>();
        }

        public void Add(int row)
        {
            completedRows.Add(row);
        }

        public void Remove(int row)
        {
            completedRows.Remove(row);
        }

        public bool IsCompleted(int row)
        {
            return completedRows.Contains(row);
        }
        
        public int CountOfCompletedRows()
        {
            return completedRows.Count;
        }        

        public void Clear()
        {
            completedRows.Clear();
        }

        public HashSet<int> CompletedRows
        {
            get { return completedRows; }
        }
        private HashSet<int> completedRows;
    }
}
