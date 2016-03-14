using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZT_5_Server
{
    public class Matrix<type>
    {
        public Matrix()
        {
            matrix = new List<List<type>>();
        }

        public Matrix(int countOfRows, int countOfColumns)
        {
            matrix = new List<List<type>>(countOfRows);


            for(var i = 0; i < countOfRows; i++)
            {
                matrix.Add(new List<type>(new type[countOfColumns]));
            }
        }

        public type GetAt(int row, int column)
        {
            return matrix[row][column];
        }

        public void SetAt(int row, int column, type newValue)
        {
            matrix[row][column] = newValue;
        }

        public List<type> GetRow(int row)
        {
            return matrix[row];
        }

        public int CountOfRows
        {
            get { return matrix.Count; }
        }

        public int CountOfColumns
        {
            get { return CountOfRows > 0 ? matrix[0].Count : 0; }
        }

        private List<List<type>> matrix;
    }
}
