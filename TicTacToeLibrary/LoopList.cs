using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class LoopList<T> : List<T>
    {

        private int index = 0;

        public LoopList()
        {
            
        }

        public void Reset()
        {
            index = 0;
        }

        public T GetCurrent()
        {
            return this[index];
        }

        public T GetNext()
        {
            index += 1;
            if (index >= Count)
            {
               index = 0;
            }
            return this[index];
        }

    }

}
