using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZT_5_Server
{
    public class FreeRowsInfo
    {
        public FreeRowsInfo()
        {
            freeRows = new HashSet<int>();
        }

        public void Add(int row)
        {
            freeRows.Add(row);
        }

        public void Remove(int row)
        {
            freeRows.Remove(row);
        }

        public bool IsFree(int row)
        {
            return freeRows.Contains(row);
        }

        public void Clear()
        {
            freeRows.Clear();
        }

        public bool IsEmpty()
        {
            return freeRows.Count == 0;
        }

        public int CountOfFreeRows()
        {
            return freeRows.Count;
        }

        public HashSet<int> FreeRows
        {
            get { return freeRows; }
        }
        private HashSet<int> freeRows;
    }
}
