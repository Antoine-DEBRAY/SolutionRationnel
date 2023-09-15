using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationnel
{
    public class RationnelEnum : IEnumerator
    {
        public Rationnel[] _rationnel;
        int position = -1;
        public RationnelEnum(Rationnel[] list)
        {
            _rationnel = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _rationnel.Length);
        }

        public void Reset()
        {
            position = -1;
        }
        public object Current
        {
            get
            {
                try
                {
                    return _rationnel[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
